using eShopLite.Store.DataEntities;

using Microsoft.EntityFrameworkCore;

namespace eShopLite.Store.ProductData;

public class ProductDbContext : DbContext
{
    public ProductDbContext (DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } = default!;
}
