using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherDefinition
{
    [Table("Weather", Schema="dbo")]
    public class WeatherCondition
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public double TemperatureF { get; set; }

        public string? Condition { get; set; }
    }
}