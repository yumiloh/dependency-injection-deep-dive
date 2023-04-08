namespace DependencyInjectionExample
{
    public class WeatherForecast : IWeatherForecast
    {
        public int TemperatureC { get; set; } = Random.Shared.Next(1, 80);

    }
}