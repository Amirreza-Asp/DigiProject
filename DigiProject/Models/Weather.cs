using System.Text.Json.Serialization;

namespace DigiProject.Models
{
    public class Weather
    {
        [JsonIgnore]
        public long Id { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Generationtime_ms { get; set; }
        public int Utc_offset_seconds { get; set; }
        public string Timezone { get; set; }
        public string Timezone_abbreviation { get; set; }
        public double Elevation { get; set; }

        public HourlyUnits Hourly_units { get; set; }

        public Hourly Hourly { get; set; }
    }

    public class Hourly
    {
        public List<string> Time { get; set; }

        public List<double> Temperature_2m { get; set; }
    }

    public class HourlyUnits
    {
        public string Time { get; set; }

        public string Temperature_2m { get; set; }
    }


}
