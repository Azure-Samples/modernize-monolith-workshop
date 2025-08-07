using eShopLite.StoreCore.Data;
using eShopLite.StoreCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSystemWebAdapters();
builder.Services.AddHttpForwarder();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Entity Framework Core with In-Memory database
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseInMemoryDatabase("StoreDatabase"));

// Add StoreService and DbContext
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IStoreDbContext>(provider => provider.GetService<StoreDbContext>()!);

var app = builder.Build();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    context.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapDefaultControllerRoute();
app.MapForwarder("/{**catch-all}", app.Configuration["ProxyTo"]).Add(static builder => ((RouteEndpointBuilder)builder).Order = int.MaxValue);

app.Run();
