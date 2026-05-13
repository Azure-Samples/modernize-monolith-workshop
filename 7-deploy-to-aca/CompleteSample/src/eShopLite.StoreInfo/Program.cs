using Microsoft.EntityFrameworkCore;
using eShopLite.StoreInfo.Data;
using eShopLite.StoreInfo.Services;

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
    // Add OpenAPI services
    builder.Services.AddOpenApi();

    // Configure Entity Framework with PostgreSQL
    builder.AddNpgsqlDbContext<StoreInfoDbContext>("storeinfodb", configureDbContextOptions: options =>
    {
        // Enable sensitive data logging in development
        if (builder.Environment.IsDevelopment())
        {
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        }
    });

    // Register application services
    builder.Services.AddScoped<IStoreInfoDbContext>(provider => 
        provider.GetRequiredService<StoreInfoDbContext>());
    builder.Services.AddScoped<IStoreInfoService, StoreInfoService>();

    // Configure JSON options for System.Text.Json
    builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.SerializerOptions.WriteIndented = true;
    });

    // Configure logging
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
    
    if (builder.Environment.IsDevelopment())
    {
        builder.Logging.AddEventSourceLogger();
    }

    // Add CORS for microservices communication
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });
}

static async Task ConfigureMiddlewareAsync(WebApplication app)
{
    // Configure the HTTP request pipeline
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseCors();
    
    // Add health check endpoint
    app.MapHealthChecks("/health");

    // Map minimal API endpoints
    MapStoreEndpoints(app);

    // Initialize database
    await InitializeDatabaseAsync(app);
}

static void MapStoreEndpoints(WebApplication app)
{
    var stores = app.MapGroup("api/stores")
        .WithOpenApi();

    // GET api/stores
    stores.MapGet("/", async (IStoreInfoService storeInfoService, ILogger<Program> logger) =>
    {
        try
        {
            logger.LogInformation("GET api/stores called");
            var storeList = await storeInfoService.GetStoresAsync();
            return Results.Ok(storeList);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting stores");
            return Results.Problem("An error occurred while retrieving stores", statusCode: 500);
        }
    })
    .WithName("GetStores")
    .WithSummary("Get all stores")
    .WithDescription("Retrieves a list of all store locations")
    .Produces<IEnumerable<eShopLite.StoreInfo.Models.Store>>(200)
    .Produces(500);

    // GET api/stores/{id}
    stores.MapGet("/{id:int}", async (int id, IStoreInfoService storeInfoService, ILogger<Program> logger) =>
    {
        try
        {
            logger.LogInformation("GET api/stores/{StoreId} called", id);
            var store = await storeInfoService.GetStoreByIdAsync(id);
            
            if (store == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(store);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting store with ID: {StoreId}", id);
            return Results.Problem("An error occurred while retrieving the store", statusCode: 500);
        }
    })
    .WithName("GetStoreById")
    .WithSummary("Get store by ID")
    .WithDescription("Retrieves a specific store by its ID")
    .Produces<eShopLite.StoreInfo.Models.Store>(200)
    .Produces(404)
    .Produces(500);
}

static async Task InitializeDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<StoreInfoDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Initializing store info database...");
        await context.Database.EnsureCreatedAsync();
        logger.LogInformation("Store info database initialization completed successfully");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the store info database");
        throw;
    }
}
