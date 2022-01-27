using CompletedWeatherApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;
using WeatherDomain;

namespace CompletedWeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherConditionController : ControllerBase
    {
        private readonly WeatherConditionService _weatherConditionService;

        internal WeatherConditionController(WeatherConditionService weatherConditionService)
        {
            _weatherConditionService = weatherConditionService;
        }

        public WeatherConditionController():this(new WeatherConditionService())
        {
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<WeatherCondition>))]
        public IActionResult GetAllWeatherConditions()
        {
            try
            {
                var weatherConditions = _weatherConditionService.GetAllWeatherConditions();

                if (weatherConditions == null)
                {
                    return NotFound();
                }

                return Ok(weatherConditions);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(WeatherCondition))]
        public IActionResult GetWeatherCondition(int id)
        {
            try
            {
                if (id > 0)
                {
                    var weather = _weatherConditionService.GetWeatherCondition(id);

                    if (weather == null)
                    {
                        return NotFound();
                    }

                    return Ok(weather);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(WeatherCondition))]
        public IActionResult AddWeatherCondition(WeatherCondition weather)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdWeather = _weatherConditionService.CreateWeatherCondition(weather);

                    return Ok(createdWeather);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(WeatherCondition))]
        public IActionResult UpdateWeatherCondition(WeatherCondition weather)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedWeather = _weatherConditionService.UpdateWeatherCondition(weather);

                    return Ok(updatedWeather);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteWeatherCondition(int id)
        {
            try
            {
                _weatherConditionService.DeleteWeatherCondition(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}