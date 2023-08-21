using DependencyInjectionExample.Interfaces;
using DependencyInjectionExample.Options;
using Microsoft.Extensions.Options;

namespace DependencyInjectionExample.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly TemperatureOption _options;

        public double Temperature{ get; set; }
        public int MaximumTemperature { get; set; }

        public TemperatureService(IOptions<TemperatureOption> options)
        {
            _options = options.Value;
            MaximumTemperature = _options.MaximumTemperature;
        }

        public double GetTemperature()
        {
            if (_options.Unit == TemperatureUnit.Celsius) return 3;
            if (_options.Unit == TemperatureUnit.Fahrenheit) return 5;
            return 0;
        }
    }
}