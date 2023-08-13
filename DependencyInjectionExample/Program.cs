using DependencyInjectionExample.Interfaces;
using DependencyInjectionExample.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyInjectionExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ITemperatureService>();
            //builder.Services.AddSingleton<ITemperatureService, TemperatureService>();

            //DI overloads 
            //builder.Services.AddSingleton(typeof(ITemperatureService));
            //builder.Services.AddSingleton(typeof(ITemperatureService), new TemperatureService());
            //builder.Services.AddSingleton(typeof(ITemperatureService), typeof(TemperatureService));
            //builder.Services.AddSingleton(typeof(ITemperatureService), sp => sp.GetRequiredService<ITemperatureService>());
            //builder.Services.AddSingleton<ITemperatureService>();
            //builder.Services.AddSingleton<ITemperatureService>(new TemperatureService());
            //builder.Services.AddSingleton(sp => sp.GetRequiredService<ITemperatureService>());
            //builder.Services.AddSingleton<ITemperatureService, TemperatureService>();
            //builder.Services.AddSingleton<ITemperatureService, TemperatureService>(sp => { return new TemperatureService(); });


            //service provider overloads
            //var serviceDescriptor = new ServiceDescriptor(typeof(ITemperatureService), typeof(TemperatureService), ServiceLifetime.Singleton);
            //var serviceOptions = new ServiceProviderOptions();
            //var sp = new ServiceProvider(serviceDescriptor, serviceOptions); cannot instantiate directly

            //builder.Services.AddSingleton(sp => sp.GetService(typeof(TemperatureService)) ?? new object());
            //builder.Services.AddSingleton(sp => sp.GetService<ITemperatureService>() ?? new object());
            //builder.Services.AddSingleton(sp => sp.GetRequiredService(typeof(TemperatureService)));
            //builder.Services.AddSingleton(sp => sp.GetRequiredService<ITemperatureService>());
            //builder.Services.AddSingleton(sp => sp.GetServices(typeof(ITemperatureService)));
            //builder.Services.AddSingleton(sp => sp.GetServices<ITemperatureService>());

            //get service provider *wink wink 
            //var serviceProvider = builder.Services.BuildServiceProvider();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}