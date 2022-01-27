using WeatherDomain;
using DbWeatherCondition = WeatherDefinition.WeatherCondition;
namespace WeatherRepository.Mappers
{
    public static class WeatherConditionMapper
    {
        public static List<WeatherCondition> Map(List<DbWeatherCondition> dbWeatherConditions)
        {
            var mappedWeatherConditions = dbWeatherConditions.Select(Map).ToList();

            return mappedWeatherConditions;
        }

        public static WeatherCondition Map(DbWeatherCondition dbWeatherCondition)
        {
            var mappedWeather = new WeatherCondition();

            mappedWeather.Id = dbWeatherCondition.Id;
            mappedWeather.TimeStamp = dbWeatherCondition.CreatedDate;
            mappedWeather.TemperatureF = dbWeatherCondition.TemperatureF;
            mappedWeather.TemperatureC = (dbWeatherCondition.TemperatureF - 32) * (5.0 / 9.0);
            mappedWeather.Summary = dbWeatherCondition.Condition;

            return mappedWeather;
        }
    }
}
