using Microsoft.EntityFrameworkCore;
using eShopLite.StoreInfo.Data;
using eShopLite.StoreInfo.Models;

namespace eShopLite.StoreInfo.Services
{
    public interface IStoreInfoService
    {
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store?> GetStoreByIdAsync(int id);
    }

    public class StoreInfoService : IStoreInfoService
    {
        private readonly IStoreInfoDbContext _context;
        private readonly ILogger<StoreInfoService> _logger;

        public StoreInfoService(IStoreInfoDbContext context, ILogger<StoreInfoService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all stores");
                return await _context.Stores.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving stores");
                throw;
            }
        }

        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving store with ID: {StoreId}", id);
                return await _context.Stores.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving store with ID: {StoreId}", id);
                throw;
            }
        }
    }
}