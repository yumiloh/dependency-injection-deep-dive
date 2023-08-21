using DependencyInjectionExample.Interfaces;
using DependencyInjectionExample.Options;
using DependencyInjectionExample.Services;

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

            //you can register it this way
            builder.Services.Configure<TemperatureOption>(builder.Configuration.GetSection("Temperature"));

            //alternative
            //difference is this way can call validateDataAnnotations()
            builder.Services.AddOptions<TemperatureOption>().Bind(builder.Configuration.GetSection("Temperature"))
                            .ValidateDataAnnotations()
                            .ValidateOnStart();

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