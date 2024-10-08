using BlueOcean.Components;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<TraderApiClient>(client =>
{
    client.BaseAddress = new Uri("https://cstrader.be/api/");
});

builder.Services.AddLogging(loggingBuilder => loggingBuilder
    .AddConsole()
    .SetMinimumLevel(LogLevel.Debug));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
