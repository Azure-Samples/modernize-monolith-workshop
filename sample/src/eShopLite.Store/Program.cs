using eShopLite.Store.ApiClients;
using eShopLite.Store.Components;
using eShopLite.Store.Endpoints;
using eShopLite.Store.Extensions;
using eShopLite.Store.ProductData;
using eShopLite.Store.StoreInfoData;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails();

// Add OpenAPI services
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add database context
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ProductsContext") ?? throw new InvalidOperationException("Connection string 'ProductsContext' not found.");
    options.UseSqlite(connectionString);
});

builder.Services.AddDbContext<StoreInfoDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("StoreInfoContext") ?? throw new InvalidOperationException("Connection string 'StoreInfoContext' not found.");
    options.UseSqlite(connectionString);
});

// Add razor components
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

// Add HTTP clients
builder.Services.AddHttpClient<ProductApiClient>(client =>
{
    client.BaseAddress = new("http://localhost:8080");
});
builder.Services.AddHttpClient<StoreInfoApiClient>(client =>
{
    client.BaseAddress = new("http://localhost:8080");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
   .AddInteractiveServerRenderMode();

app.MapProductEndpoints();
app.MapStoreInfoEndpoints();

app.CreateProductDbIfNotExists();
app.CreateStoreInfoDbIfNotExists();

app.Run();
