using BlazorWebAppErrorBoundary.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAntDesign();

// HttpClient for web API calls
builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Client-side weather service
builder.Services.AddSingleton<IWeatherService, ClientWeatherService>();

await builder.Build().RunAsync();
