using eShopLite.Store.DataEntities;

namespace eShopLite.Store.StoreInfoData;

public class DbInitializer
{
    public static void Initialize(StoreInfoDbContext storeInfoDbContext)
    {
        if (storeInfoDbContext.Store.Any())
        {
            return;
        }

        var storeInfos = new List<StoreInfo>
        {
            new StoreInfo { Name = "Outdoor Store", City = "Seattle", State = "WA", Hours = "9am - 5pm" },
            new StoreInfo { Name = "Camping Supplies", City = "Portland", State = "OR", Hours = "10am - 6pm" },
            new StoreInfo { Name = "Hiking Gear", City = "San Francisco", State = "CA", Hours = "11am - 7pm" },
            new StoreInfo {Name = "Fishing Equipment", City = "Los Angeles", State = "CA", Hours = "8am - 4pm"},
            new StoreInfo {Name = "Climbing Gear", City = "Denver", State = "CO", Hours = "9am - 5pm"},
            new StoreInfo {Name = "Cycling Supplies", City = "Austin", State = "TX", Hours = "10am - 6pm"},
            new StoreInfo {Name = "Winter Sports Gear", City = "Salt Lake City", State = "UT", Hours = "11am - 7pm"},
            new StoreInfo {Name = "Water Sports Equipment", City = "Miami", State = "FL", Hours = "8am - 4pm"},
            new StoreInfo {Name = "Outdoor Clothing", City = "New York", State = "NY", Hours = "9am - 5pm"}
        };

        storeInfoDbContext.AddRange(storeInfos);
        storeInfoDbContext.SaveChanges();
    }
}
