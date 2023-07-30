using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class TemperatureService : ITemperatureService
    {
        public int TemperatureInFahrenheit { get; set; } = Random.Shared.Next(500, 1000);
    }
}