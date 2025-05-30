using BlazorWebAppErrorBoundary.Client.Models;

namespace BlazorWebAppErrorBoundary.Client.Services;

public interface IWeatherService
{
    Task<WeatherForecast[]> GetWeather(bool throwError);
}
