using DigiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiProject.Services
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WeatherService(IHttpClientFactory httpClientFactory, IServiceScopeFactory serviceScopeFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<Weather?> ExecuteAsync(double lat, double lon, CancellationToken cancellationToken)
        {
            var cachedWeather = await GetCachedDataAsync(cancellationToken);

            var client = _httpClientFactory.CreateClient();

            var weatherApiTask = FetchAndSaveAsync(client, lat, lon, CancellationToken.None);

            var completedTask = await Task.WhenAny(weatherApiTask, Task.Delay(4000, cancellationToken));

            if (completedTask != weatherApiTask)
            {
                Task.Run(async () =>
                {
                    await weatherApiTask;
                });

                return cachedWeather;
            }

            var apiWeatherData = await weatherApiTask;
            return apiWeatherData ?? cachedWeather;
        }


        private async Task<Weather?> FetchAndSaveAsync(HttpClient httpClient, double lat, double lon, CancellationToken cancellationToken)
        {
            var sendRequestAt = DateTime.Now;

            var data = await FetchDataAsync(httpClient, lat, lon, cancellationToken);

            if (data == null)
                return null;

            data.Id = sendRequestAt.Ticks;

            await SaveAsync(data, cancellationToken);

            return data;
        }


        private async Task<Weather?> FetchDataAsync(HttpClient httpClient, double lat, double lon, CancellationToken cancellationToken)
        {
            try
            {
                var response = await httpClient.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m", cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var weatherData = await response.Content.ReadFromJsonAsync<Weather>();
                    return weatherData;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private async Task SaveAsync(Weather weatherForecast, CancellationToken cancellationToken)
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<WeatherContext>();
                context.WeatherForecast.Add(weatherForecast);
                await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task<Weather?> GetCachedDataAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<WeatherContext>();

            return await context.WeatherForecast.OrderByDescending(b => b.Id).FirstOrDefaultAsync(cancellationToken);
        }

    }

}
