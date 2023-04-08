namespace DependencyInjectionExample
{
    public class WeatherForecast : IWeatherForecast
    {
        public int Temperature { get; set; } = Random.Shared.Next(1, 80);
    }
}