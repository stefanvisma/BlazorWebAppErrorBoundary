using BlazorWebAppErrorBoundary.Client.Models;
using System.Net.Http.Json;

namespace BlazorWebAppErrorBoundary.Client.Services;

public class ClientWeatherService(HttpClient httpClient) : IWeatherService
{
    public Task<WeatherForecast[]> GetWeather(bool throwError)
    {
        if (throwError)
        {
            return httpClient.GetFromJsonAsync<WeatherForecast[]>("/api/weather?throwError=true")!;
        }

        return httpClient.GetFromJsonAsync<WeatherForecast[]>("/api/weather?throwError=false")!;
    }
}
