using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eShopLite.Store.Models;
using Microsoft.Extensions.Logging;

namespace eShopLite.Store.Services
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
        private readonly IProductApiClient _productApiClient;
        private readonly IStoreInfoApiClient _storeInfoApiClient;
        private readonly ILogger<StoreService> _logger;

        public StoreService(
            IProductApiClient productApiClient,
            IStoreInfoApiClient storeInfoApiClient,
            ILogger<StoreService> logger)
        {
            _productApiClient = productApiClient ?? throw new ArgumentNullException(nameof(productApiClient));
            _storeInfoApiClient = storeInfoApiClient ?? throw new ArgumentNullException(nameof(storeInfoApiClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all products via API");
                return await _productApiClient.GetProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products via API");
                throw;
            }
        }

        public async Task<IEnumerable<StoreInfo>> GetStoresAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all stores via API");
                return await _storeInfoApiClient.GetStoresAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving stores via API");
                throw;
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving product with ID: {ProductId} via API", id);
                return await _productApiClient.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product with ID: {ProductId} via API", id);
                throw;
            }
        }

        public async Task<StoreInfo?> GetStoreByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving store with ID: {StoreId} via API", id);
                return await _storeInfoApiClient.GetStoreByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving store with ID: {StoreId} via API", id);
                throw;
            }
        }
    }
}