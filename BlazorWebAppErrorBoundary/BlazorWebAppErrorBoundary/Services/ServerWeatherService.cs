using BlazorWebAppErrorBoundary.Client.Models;
using BlazorWebAppErrorBoundary.Client.Services;

namespace BlazorWebAppErrorBoundary.Services;

public class ServerWeatherService : IWeatherService
{
    public async Task<WeatherForecast[]> GetWeather(bool throwError)
    {
        if (throwError)
        {
            // Simulate a server error by throwing an exception
            throw new Exception("Unexpected server error occurred while fetching weather data.");
        }

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();

        return forecasts;
    }
}
