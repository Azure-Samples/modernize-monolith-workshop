using Microsoft.EntityFrameworkCore;
using eShopLite.Products.Data;
using eShopLite.Products.Services;

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

    // Configure Entity Framework with SQLite
    builder.Services.AddDbContext<ProductDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
            ?? "Data Source=products.db";
        options.UseSqlite(connectionString);
        
        // Enable sensitive data logging in development
        if (builder.Environment.IsDevelopment())
        {
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        }
    });

    // Register application services
    builder.Services.AddScoped<IProductDbContext>(provider => 
        provider.GetRequiredService<ProductDbContext>());
    builder.Services.AddScoped<IProductService, ProductService>();

    // Configure JSON options for System.Text.Json
    builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.SerializerOptions.WriteIndented = true;
    });

    // Add health checks
    builder.Services.AddHealthChecks()
        .AddDbContextCheck<ProductDbContext>();

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
    MapProductEndpoints(app);

    // Initialize database
    await InitializeDatabaseAsync(app);
}

static void MapProductEndpoints(WebApplication app)
{
    var products = app.MapGroup("api/products")
        .WithOpenApi();

    // GET api/products
    products.MapGet("/", async (IProductService productService, ILogger<Program> logger) =>
    {
        try
        {
            logger.LogInformation("GET api/products called");
            var productList = await productService.GetProductsAsync();
            return Results.Ok(productList);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting products");
            return Results.Problem("An error occurred while retrieving products", statusCode: 500);
        }
    })
    .WithName("GetProducts")
    .WithSummary("Get all products")
    .WithDescription("Retrieves a list of all available products")
    .Produces<IEnumerable<eShopLite.Products.Models.Product>>(200)
    .Produces(500);

    // GET api/products/{id}
    products.MapGet("/{id:int}", async (int id, IProductService productService, ILogger<Program> logger) =>
    {
        try
        {
            logger.LogInformation("GET api/products/{ProductId} called", id);
            var product = await productService.GetProductByIdAsync(id);
            
            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting product with ID: {ProductId}", id);
            return Results.Problem("An error occurred while retrieving the product", statusCode: 500);
        }
    })
    .WithName("GetProductById")
    .WithSummary("Get product by ID")
    .WithDescription("Retrieves a specific product by its ID")
    .Produces<eShopLite.Products.Models.Product>(200)
    .Produces(404)
    .Produces(500);
}

static async Task InitializeDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Initializing products database...");
        await context.Database.EnsureCreatedAsync();
        logger.LogInformation("Products database initialization completed successfully");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the products database");
        throw;
    }
}
