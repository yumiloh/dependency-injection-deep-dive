using System.ComponentModel.DataAnnotations;

namespace DependencyInjectionExample.Options
{
    public class TemperatureOption
    {
        public TemperatureUnit Unit { get; set; }
        [Range(0, 80)]
        public int MaximumTemperature { get; set; }
    }

    public enum TemperatureUnit{
        Fahrenheit,
        Celsius
    }
}
