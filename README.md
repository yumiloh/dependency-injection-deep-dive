# Dependency Injection


## Walkthrough of the application

It is a default web api project from ASP.NET Core. The unnecessary properties of `WeatherForecast` is removed, remaining only the `Temperature` property, which is a randomly generated number from between 1 and 80.

```csharp
public class WeatherForecast : IWeatherForecast
{
    public int Temperature { get; set; } = Random.Shared.Next(1, 80);
}
```

The interface `IWeatherForecast` is generated from `WeatherForecast`. 

And in `Program.cs`, there are three different types of dependency injection registrations. Uncomment the one you would like to use and comment the rest. Then hit F5 to run the project. 

```csharp
builder.Services.AddSingleton<IWeatherForecast, WeatherForecast>();
builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();
builder.Services.AddTransient<IWeatherForecast, WeatherForecast>();
```

## What is Dependency Injection?
--Work in progress--

## Different types of Dependency Injection in ASP.NET

In ASP.NET, there are three different methods we can register our dependencies: `AddSingleton`, `AddScoped`, `AddTransient`

### AddSingleton

When we register a dependency using `AddSingleton()` , the DI container will provide us the instance in the first request, and **the same instance** is used throughout the lifetime of the application. 

You can treat it like a global constant that is used throughout the application.

Example:

```csharp
//configuration settings in Program.cs: uncomment AddSingleton

builder.Services.AddSingleton<IWeatherForecast, WeatherForecast>();
//builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();
//builder.Services.AddTransient<IWeatherForecast, WeatherForecast>();
```

```csharp
public WeatherForecastController(IWeatherForecast weatherForecast1,
                                 IWeatherForecast weatherForecast2)
{
    _weatherForecast1 = weatherForecast1;
    _weatherForecast2 = weatherForecast2;
}
```

When a concrete implementation is asked for `IWeatherForecast` for `weatherForecast1`, we are provided with an instance of `WeatherForecast`, and the same instance is provided to subsequent request (`weatherForecast2` also uses the same instance), throughout the entire lifetime. 

So, if we call the endpoint again, we will get back the same instance `weatherForecast1` received. No matter how many times we call the endpoint, the instance is the same. You will see the random number generated stays the same the entire time no matter how many requests are made. 

### AddScoped

In the context of web applications, the instances created by the container will be scoped to the lifetime of a request. For example, if we are calling a web api that has dependencies registered with `AddScoped()`, we will be getting the same instance during the request. 

If we call the endpoint again (i.e. make another web request), we will be provided with a new instance. 

```csharp
//configuration settings in Program.cs: uncomment AddScoped

//builder.Services.AddSingleton<IWeatherForecast, WeatherForecast>();
builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();
//builder.Services.AddTransient<IWeatherForecast, WeatherForecast>();
```

In the same example as the above, when we register `IWeatherForecast` as `AddScoped()`, we will be getting the same instance for `weatherForecast1` and `weatherForecast2` per web request. However, when we make a new web request, a new instance will be created, shared between both of them. 

This is why we get the same number for `weatherForecast1` and `weatherForecast2`, but we get a new random number when we call the endpoint again.

The first request: 

![Untitled](https://github.com/yumiloh/DependencyInjectionExample/blob/44c5265b13c685de443b776c595ae4dd1ee8cd9e/assets/Untitled.png)

The second request: 


![Untitled](https://github.com/yumiloh/DependencyInjectionExample/blob/44c5265b13c685de443b776c595ae4dd1ee8cd9e/assets/Untitled%201.png)

Notice how the numbers vary per request but stay the same for both instances. 

### AddTransient

We will get a new instance every time it is requested from the DI container. 

Back to the example:

```csharp
//configuration settings in Program.cs: uncomment AddTransient

//builder.Services.AddSingleton<IWeatherForecast, WeatherForecast>();
//builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();
builder.Services.AddTransient<IWeatherForecast, WeatherForecast>();
```

```csharp
public WeatherForecastController(IWeatherForecast weatherForecast1,
                                 IWeatherForecast weatherForecast2)
{
    _weatherForecast1 = weatherForecast1;
    _weatherForecast2 = weatherForecast2;
}
```

`weatherForecast1` and `weatherForecast2` each gets a new instance from the DI container. 

This is why when we call the endpoint, we get different random temperatures for both of them. 

![Untitled](https://github.com/yumiloh/DependencyInjectionExample/blob/44c5265b13c685de443b776c595ae4dd1ee8cd9e/assets/Untitled%202.png)
