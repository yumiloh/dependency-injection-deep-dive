using DependencyInjectionExample.Interfaces;
using DependencyInjectionExample.Services;

namespace DependencyInjectionExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //uncomment this to detect captive dependency in environments other than development
            //builder.Host.UseDefaultServiceProvider(options => options.ValidateScopes = true);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //where captive dependency occurs
            builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();
            builder.Services.AddSingleton<ITemperatureService, TemperatureService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}