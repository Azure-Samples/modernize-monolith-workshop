using Microsoft.EntityFrameworkCore;
using eShopLite.StoreInfo.Models;

namespace eShopLite.StoreInfo.Data
{
    public interface IStoreInfoDbContext
    {
        DbSet<Store> Stores { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }

    public class StoreInfoDbContext : DbContext, IStoreInfoDbContext
    {
        public StoreInfoDbContext(DbContextOptions<StoreInfoDbContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints
            modelBuilder.Entity<Store>(entity =>
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
            var stores = new[]
            {
                new Store { Id = 1, Name = "Adventure Gear Northwest", City = "Seattle", State = "WA", Hours = "Mon-Sat: 9AM-8PM, Sun: 10AM-6PM" },
                new Store { Id = 2, Name = "Mountain Sports Denver", City = "Denver", State = "CO", Hours = "Mon-Fri: 9AM-9PM, Sat-Sun: 8AM-8PM" },
                new Store { Id = 3, Name = "Outdoor World Austin", City = "Austin", State = "TX", Hours = "Daily: 8AM-10PM" },
                new Store { Id = 4, Name = "Trail Blazers Portland", City = "Portland", State = "OR", Hours = "Mon-Thu: 10AM-7PM, Fri-Sun: 9AM-9PM" },
                new Store { Id = 5, Name = "Summit Sports", City = "Boulder", State = "CO", Hours = "Mon-Sat: 8AM-7PM, Sun: 9AM-6PM" }
            };

            modelBuilder.Entity<Store>().HasData(stores);
        }
    }
}