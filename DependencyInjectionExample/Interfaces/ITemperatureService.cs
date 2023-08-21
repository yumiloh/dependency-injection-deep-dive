namespace DependencyInjectionExample.Interfaces
{
    public interface ITemperatureService
    {
        public int MaximumTemperature { get; set; }
        double GetTemperature();
    }
}