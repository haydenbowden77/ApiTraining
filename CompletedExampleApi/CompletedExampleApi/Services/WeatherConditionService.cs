using WeatherDomain;
using WeatherRepository;

namespace CompletedWeatherApi.Services
{
    public class WeatherConditionService
    {

        private readonly WeatherRepo _weatherRepo;

        public WeatherConditionService() : this(new WeatherRepo())
        {

        }

        public WeatherConditionService(WeatherRepo weatherRepo)
        {
            _weatherRepo = weatherRepo;
        }

        public List<WeatherCondition> GetAllWeatherConditions()
        {
            var weatherConditions = _weatherRepo.GetAllWeatherConditions();

            return weatherConditions;
        }

        public WeatherCondition GetWeatherCondition(int id)
        {
            var weatherCondition = _weatherRepo.GetWeatherCondition(id);

            if(weatherCondition.TemperatureF < 32)
            {
                weatherCondition.Summary = "Cold";
            }

            return weatherCondition;
        }

        public WeatherCondition CreateWeatherCondition(WeatherCondition weather)
        {
            var createdWeather = _weatherRepo.CreateWeatherCondition(weather);

            return createdWeather;
        }

        public WeatherCondition UpdateWeatherCondition(WeatherCondition weather)
        {
            var updatedWeather = _weatherRepo.UpdateWeatherCondition(weather);

            return updatedWeather;
        }

        public void DeleteWeatherCondition(int id)
        {
            _weatherRepo.DeleteWeatherCondition(id);
        }
    }
}
