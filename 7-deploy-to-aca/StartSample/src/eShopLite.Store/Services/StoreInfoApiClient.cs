using eShopLite.Store.Models;

namespace eShopLite.Store.Services
{
    public interface IStoreInfoApiClient
    {
        Task<IEnumerable<StoreInfo>> GetStoresAsync();
        Task<StoreInfo?> GetStoreByIdAsync(int id);
    }

    public class StoreInfoApiClient : ApiClient, IStoreInfoApiClient
    {
        public StoreInfoApiClient(HttpClient httpClient, ILogger<StoreInfoApiClient> logger) 
            : base(httpClient, logger)
        {
        }

        public async Task<IEnumerable<StoreInfo>> GetStoresAsync()
        {
            return await GetListAsync<StoreInfo>("api/stores");
        }

        public async Task<StoreInfo?> GetStoreByIdAsync(int id)
        {
            return await GetAsync<StoreInfo>($"api/stores/{id}");
        }
    }
}