using eShopLite.Store.StoreInfoData;

namespace eShopLite.Store.Extensions;

public static class StoreInfoDbContextExtensions
{
    public static void CreateStoreInfoDbIfNotExists(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<StoreInfoDbContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
    }
}
