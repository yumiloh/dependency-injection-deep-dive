using DependencyInjectionExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecast _weatherForecast1;
        private readonly IWeatherForecast _weatherForecast2;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IWeatherForecast weatherForecast1,
                                         IWeatherForecast weatherForecast2)
        {
            _logger = logger;
            _weatherForecast1 = weatherForecast1;
            _weatherForecast2 = weatherForecast2;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(1);
            return Ok(new
            {
                weatherService1 = _weatherForecast1,
                weatherService2 = _weatherForecast2,
            });
        }
    }
}