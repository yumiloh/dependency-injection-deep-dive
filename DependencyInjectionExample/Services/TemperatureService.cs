using DependencyInjectionExample.Interfaces;

namespace DependencyInjectionExample.Services
{
    public class TemperatureService : ITemperatureService
    {
        public int TemperatureInFahrenheit { get; set; } = 5;
            //= Random.Shared.Next(500, 1000);
    }
}