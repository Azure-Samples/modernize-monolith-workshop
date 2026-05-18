using eShopLite.Store.Models;

namespace eShopLite.Store.Services
{
    public interface IProductApiClient
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
    }

    public class ProductApiClient : ApiClient, IProductApiClient
    {
        public ProductApiClient(HttpClient httpClient, ILogger<ProductApiClient> logger) 
            : base(httpClient, logger)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await GetListAsync<Product>("api/products");
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await GetAsync<Product>($"api/products/{id}");
        }
    }
}