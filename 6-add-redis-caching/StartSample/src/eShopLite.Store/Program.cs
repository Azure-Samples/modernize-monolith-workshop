using eShopLite.Store.Components;
using eShopLite.Store.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Configure services
ConfigureServices(builder);

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure middleware pipeline
await ConfigureMiddlewareAsync(app);

await app.RunAsync();

static void ConfigureServices(WebApplicationBuilder builder)
{
    // Add Blazor services
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

    // Configure HTTP clients for microservices
    builder.Services.AddHttpClient<IProductApiClient, ProductApiClient>(client =>
    {
        client.BaseAddress = new Uri("https+http://eshoplite-products");
        client.Timeout = TimeSpan.FromSeconds(30);
    });

    builder.Services.AddHttpClient<IStoreInfoApiClient, StoreInfoApiClient>(client =>
    {
        client.BaseAddress = new Uri("https+http://eshoplite-storeinfo");
        client.Timeout = TimeSpan.FromSeconds(30);
    });

    // Register application services
    builder.Services.AddScoped<IStoreService, StoreService>();

    // Configure JSON options for System.Text.Json
    builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.SerializerOptions.WriteIndented = true;
    });

    // Add health checks for API dependencies
    builder.Services.AddHealthChecks()
        .AddCheck("products-api", () => Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("Products API dependency"))
        .AddCheck("storeinfo-api", () => Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("StoreInfo API dependency"));

    // Configure logging
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
    
    if (builder.Environment.IsDevelopment())
    {
        builder.Logging.AddEventSourceLogger();
    }
}

static async Task ConfigureMiddlewareAsync(WebApplication app)
{
    // Configure the HTTP request pipeline
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
    }
    else
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();
    app.UseAntiforgery();

    app.MapStaticAssets();
    
    // Add health check endpoint
    app.MapHealthChecks("/health");

    // Configure Blazor routing
    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    await Task.CompletedTask;
}
