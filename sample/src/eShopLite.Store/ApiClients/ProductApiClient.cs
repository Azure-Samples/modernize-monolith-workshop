using eShopLite.Store.DataEntities;

namespace eShopLite.Store.ApiClients;

public class ProductApiClient(HttpClient http)
{
    public async Task<IEnumerable<Product>> GetProductsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Product>? products = null;

        await foreach (var product in http.GetFromJsonAsAsyncEnumerable<Product>("/api/products", cancellationToken))
        {
            if (products?.Count >= maxItems)
            {
                break;
            }
            if (product is not null)
            {
                products ??= [];
                products.Add(product);
            }
        }

        return products ?? [];
    }
}
