using DigiProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _service;

        public WeatherController(WeatherService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] double lat, double lon, CancellationToken cancellationToken)
        {
            return Ok(await _service.ExecuteAsync(lat, lon, cancellationToken));
        }
    }
}
