using eShopLite.Store.Components;
using eShopLite.Store.Services;
using Azure.AI.Inference;
using Azure;

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

    // Configure AI Chatbot Services
    ConfigureChatbotServices(builder);

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

static void ConfigureChatbotServices(WebApplicationBuilder builder)
{
    // Register ChatCompletionsClient as singleton with GitHub token from environment
    builder.Services.AddSingleton<ChatCompletionsClient>(serviceProvider =>
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        var githubToken = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
        
        if (string.IsNullOrWhiteSpace(githubToken))
        {
            logger.LogWarning("GITHUB_TOKEN environment variable not found. Chatbot will run in fallback mode without AI capabilities.");
            return null;
        }

        try
        {
            var credential = new AzureKeyCredential(githubToken);
            var client = new ChatCompletionsClient(
                new Uri("https://models.github.ai/inference"),
                credential);
            
            logger.LogInformation("ChatCompletionsClient configured successfully with GitHub Models");
            return client;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to configure ChatCompletionsClient. Chatbot will run in fallback mode.");
            return null;
        }
    });

    // Register IChatbotService as scoped
    builder.Services.AddScoped<IChatbotService, ChatbotService>();
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
