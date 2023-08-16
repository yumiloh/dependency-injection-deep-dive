namespace DependencyInjectionExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IWeatherForecast, WeatherForecast>();
            //builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();
            //builder.Services.AddTransient<IWeatherForecast, WeatherForecast>();

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