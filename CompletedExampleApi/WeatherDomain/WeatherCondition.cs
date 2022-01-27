using System.ComponentModel.DataAnnotations;

namespace WeatherDomain
{
    public class WeatherCondition
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public double TemperatureC { get; set; }

        [Required]
        public double TemperatureF { get; set; }

        public string? Summary { get; set; }
    }
}