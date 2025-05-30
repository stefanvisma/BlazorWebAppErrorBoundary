using BlazorWebAppErrorBoundary.Client.Services;
using BlazorWebAppErrorBoundary.Components;
using BlazorWebAppErrorBoundary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddAntDesign();

// Server-side weather service
builder.Services.AddSingleton<IWeatherService, ServerWeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppErrorBoundary.Client._Imports).Assembly);

// Minimal API for obtaining weather data from /api/weather
app.MapGet("/api/weather", (bool throwError, IWeatherService weatherService) => weatherService.GetWeather(throwError));

app.Run();
