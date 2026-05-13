using eShopLite.Admin.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace eShopLite.Admin.Services;

public sealed class ProductApiClient(HttpClient httpClient)
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    private readonly string _cacheFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "product-cache.json");

    public async Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var products = await httpClient.GetFromJsonAsync<List<Product>>("api/products/", SerializerOptions, cancellationToken) ?? [];
            await SaveWorkingCopyAsync(products, cancellationToken);
            return products;
        }
        catch
        {
            return await LoadCacheAsync(cancellationToken);
        }
    }

    public async Task SaveWorkingCopyAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default)
    {
        var directory = Path.GetDirectoryName(_cacheFilePath)!;
        Directory.CreateDirectory(directory);

        await using var stream = File.Create(_cacheFilePath);
        await JsonSerializer.SerializeAsync(stream, products, SerializerOptions, cancellationToken);
    }

    public Task<ApiMutationResult> TryCreateProductAsync(Product product, CancellationToken cancellationToken = default) =>
        TrySendAsync(HttpMethod.Post, "api/products", product, "Created product in Products API.", cancellationToken);

    public Task<ApiMutationResult> TryUpdateProductAsync(Product product, CancellationToken cancellationToken = default) =>
        TrySendAsync(HttpMethod.Put, $"api/products/{product.Id}", product, "Updated product in Products API.", cancellationToken);

    public Task<ApiMutationResult> TryDeleteProductAsync(int productId, CancellationToken cancellationToken = default) =>
        TrySendAsync(HttpMethod.Delete, $"api/products/{productId}", null, "Deleted product in Products API.", cancellationToken);

    private async Task<ApiMutationResult> TrySendAsync(HttpMethod method, string relativeUrl, Product? product, string successMessage, CancellationToken cancellationToken)
    {
        try
        {
            using var request = new HttpRequestMessage(method, relativeUrl);
            if (product is not null)
            {
                request.Content = JsonContent.Create(product, options: SerializerOptions);
            }

            using var response = await httpClient.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return ApiMutationResult.Ok(successMessage);
            }

            if (response.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.MethodNotAllowed)
            {
                return ApiMutationResult.Failed("Products API is read-only in the current workshop modules. Local working copy updated.");
            }

            var details = await response.Content.ReadAsStringAsync(cancellationToken);
            return ApiMutationResult.Failed($"Products API returned {(int)response.StatusCode}: {details}");
        }
        catch (Exception ex)
        {
            return ApiMutationResult.Failed($"Could not reach Products API. Local working copy updated. {ex.Message}");
        }
    }

    private async Task<IReadOnlyList<Product>> LoadCacheAsync(CancellationToken cancellationToken)
    {
        if (!File.Exists(_cacheFilePath))
        {
            return [];
        }

        await using var stream = File.OpenRead(_cacheFilePath);
        return await JsonSerializer.DeserializeAsync<List<Product>>(stream, SerializerOptions, cancellationToken) ?? [];
    }
}
