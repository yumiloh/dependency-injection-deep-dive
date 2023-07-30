using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class WeatherForecast : IWeatherForecast
    {
        private readonly ITemperatureService _temperatureService;

        public int Temperature { get; set; } = Random.Shared.Next(1, 80);
        public int TemperatureInFahrenheit { get => _temperatureService.TemperatureInFahrenheit; set { } }

        public WeatherForecast(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }
    }
}