using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eShopLite.StoreCore.Data;
using eShopLite.StoreCore.Models;
using Microsoft.Extensions.Logging;

namespace eShopLite.StoreCore.Services
{
    public interface IStoreService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<StoreInfo>> GetStoresAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<StoreInfo?> GetStoreByIdAsync(int id);
    }

    public class StoreService : IStoreService
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<StoreService> _logger;

        public StoreService(IStoreDbContext context, ILogger<StoreService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all products");
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products");
                throw;
            }
        }

        public async Task<IEnumerable<StoreInfo>> GetStoresAsync()
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

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving product with ID: {ProductId}", id);
                return await _context.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product with ID: {ProductId}", id);
                throw;
            }
        }

        public async Task<StoreInfo?> GetStoreByIdAsync(int id)
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