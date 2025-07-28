using Microsoft.EntityFrameworkCore;
using eShopLite.StoreCore.Data;
using eShopLite.StoreCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder);

var app = builder.Build();

// Configure middleware pipeline
await ConfigureMiddlewareAsync(app);

await app.RunAsync();

static void ConfigureServices(WebApplicationBuilder builder)
{
    // Add Blazor Server services
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    // Configure Entity Framework with SQLite
    builder.Services.AddDbContext<StoreDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
            ?? "Data Source=eShopLite.db";
        options.UseSqlite(connectionString);
        
        // Enable sensitive data logging in development
        if (builder.Environment.IsDevelopment())
        {
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        }
    });

    // Register application services
    builder.Services.AddScoped<IStoreDbContext>(provider => 
        provider.GetRequiredService<StoreDbContext>());
    builder.Services.AddScoped<IStoreService, StoreService>();

    // Configure JSON options for System.Text.Json
    builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.SerializerOptions.WriteIndented = true;
    });

    // Add health checks
    builder.Services.AddHealthChecks()
        .AddDbContextCheck<StoreDbContext>();

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
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }
    else
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    // Add health check endpoint
    app.MapHealthChecks("/health");

    // Configure Blazor routing
    app.MapRazorPages();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    // Initialize database
    await InitializeDatabaseAsync(app);
}

static async Task InitializeDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Initializing database...");
        await context.Database.EnsureCreatedAsync();
        logger.LogInformation("Database initialization completed successfully");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the database");
        throw;
    }
}
