using Microsoft.EntityFrameworkCore;
using eShopLite.Store.Models;

namespace eShopLite.Store.Data
{
    public interface IStoreDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<StoreInfo> Stores { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }

    public class StoreDbContext : DbContext, IStoreDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<StoreInfo> Stores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<StoreInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
                entity.Property(e => e.City).HasMaxLength(100).IsRequired();
                entity.Property(e => e.State).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Hours).HasMaxLength(100);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            var products = new[]
            {
                new Product { Id = 1, Name = "Solar Powered Flashlight", Description = "A fantastic product for outdoor enthusiasts", Price = 19.99m, ImageUrl = "product1.png" },
                new Product { Id = 2, Name = "Hiking Poles", Description = "Ideal for camping and hiking trips", Price = 24.99m, ImageUrl = "product2.png" },
                new Product { Id = 3, Name = "Outdoor Rain Jacket", Description = "This product will keep you warm and dry in all weathers", Price = 49.99m, ImageUrl = "product3.png" },
                new Product { Id = 4, Name = "Survival Kit", Description = "A must-have for any outdoor adventurer", Price = 99.99m, ImageUrl = "product4.png" },
                new Product { Id = 5, Name = "Outdoor Backpack", Description = "This backpack is perfect for carrying all your outdoor essentials", Price = 39.99m, ImageUrl = "product5.png" },
                new Product { Id = 6, Name = "Camping Cookware", Description = "This cookware set is ideal for cooking outdoors", Price = 29.99m, ImageUrl = "product6.png" },
                new Product { Id = 7, Name = "Camping Stove", Description = "This stove is perfect for cooking outdoors", Price = 49.99m, ImageUrl = "product7.png" },
                new Product { Id = 8, Name = "Camping Lantern", Description = "This lantern is perfect for lighting up your campsite", Price = 19.99m, ImageUrl = "product8.png" },
                new Product { Id = 9, Name = "Camping Tent", Description = "This tent is perfect for camping trips", Price = 99.99m, ImageUrl = "product9.png" },
            };

            modelBuilder.Entity<Product>().HasData(products);

            var stores = new[]
            {
                new StoreInfo { Id = 1, Name = "Outdoor Store", City = "Seattle", State = "WA", Hours = "9am - 5pm" },
                new StoreInfo { Id = 2, Name = "Camping Supplies", City = "Portland", State = "OR", Hours = "10am - 6pm" },
                new StoreInfo { Id = 3, Name = "Hiking Gear", City = "San Francisco", State = "CA", Hours = "11am - 7pm" },
                new StoreInfo { Id = 4, Name = "Fishing Equipment", City = "Los Angeles", State = "CA", Hours = "8am - 4pm" },
                new StoreInfo { Id = 5, Name = "Climbing Gear", City = "Denver", State = "CO", Hours = "9am - 5pm" },
                new StoreInfo { Id = 6, Name = "Cycling Supplies", City = "Austin", State = "TX", Hours = "10am - 6pm" },
                new StoreInfo { Id = 7, Name = "Winter Sports Gear", City = "Salt Lake City", State = "UT", Hours = "11am - 7pm" },
                new StoreInfo { Id = 8, Name = "Water Sports Equipment", City = "Miami", State = "FL", Hours = "8am - 4pm" },
                new StoreInfo { Id = 9, Name = "Outdoor Clothing", City = "New York", State = "NY", Hours = "9am - 5pm" }
            };

            modelBuilder.Entity<StoreInfo>().HasData(stores);
        }
    }
}