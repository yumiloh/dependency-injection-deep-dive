using DependencyInjectionExample.Interfaces;
using DependencyInjectionExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TemperatureService _weatherForecast1;
        //private readonly IWeatherForecast _weatherForecast2;

        public WeatherForecastController(TemperatureService weatherForecast1)
        {
            _weatherForecast1 = weatherForecast1;
            //_weatherForecast2 = weatherForecast2;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return Ok(new
            {
                weatherForecast1 = _weatherForecast1,
                //weatherForecast2 = _weatherForecast2,
            });
        }
    }
}