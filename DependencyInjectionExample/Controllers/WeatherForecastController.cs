using DependencyInjectionExample.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ITemperatureService _temperatureService;

        public WeatherForecastController(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return Ok(new
            {
                temperature = _temperatureService.GetTemperature(),
                maximumTemperature = _temperatureService.MaximumTemperature
            });
        }
    }
}