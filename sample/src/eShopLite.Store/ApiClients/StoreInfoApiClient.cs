using eShopLite.Store.DataEntities;

namespace eShopLite.Store.ApiClients;

public class StoreInfoApiClient(HttpClient http)
{
    public async Task<IEnumerable<StoreInfo>> GetStoreInfoAsync(int maxStores = 10, CancellationToken cancellationToken = default)
    {
        List<StoreInfo>? storeInfo = null;

        await Task.Delay(2000);

        await foreach (var info in http.GetFromJsonAsAsyncEnumerable<StoreInfo>("/api/storeinfo", cancellationToken))
        {
            if (storeInfo?.Count >= maxStores)
            {
                break;
            }
            if (info is not null)
            {
                storeInfo ??= [];
                storeInfo.Add(info);
            }
        }
        return storeInfo ?? [];
    }
}
