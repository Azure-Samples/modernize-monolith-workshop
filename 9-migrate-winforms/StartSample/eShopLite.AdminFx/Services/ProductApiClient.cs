using eShopLite.AdminFx.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopLite.AdminFx.Services
{
    public class ProductApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _cacheFilePath;

        public ProductApiClient(string baseAddress, int timeoutSeconds)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress, UriKind.Absolute),
                Timeout = TimeSpan.FromSeconds(timeoutSeconds)
            };

            _cacheFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "product-cache.json");
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            try
            {
                var json = await _httpClient.GetStringAsync("api/products/").ConfigureAwait(false);
                var products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
                await SaveCacheAsync(products).ConfigureAwait(false);
                return products;
            }
            catch
            {
                return await LoadCacheAsync().ConfigureAwait(false);
            }
        }

        public Task SaveWorkingCopyAsync(IEnumerable<Product> products)
        {
            return SaveCacheAsync(products);
        }

        public async Task<ApiMutationResult> TryCreateProductAsync(Product product)
        {
            return await TrySendAsync(HttpMethod.Post, "api/products", product, "Created product in Products API.").ConfigureAwait(false);
        }

        public async Task<ApiMutationResult> TryUpdateProductAsync(Product product)
        {
            return await TrySendAsync(HttpMethod.Put, string.Format("api/products/{0}", product.Id), product, "Updated product in Products API.").ConfigureAwait(false);
        }

        public async Task<ApiMutationResult> TryDeleteProductAsync(int productId)
        {
            return await TrySendAsync(HttpMethod.Delete, string.Format("api/products/{0}", productId), null, "Deleted product in Products API.").ConfigureAwait(false);
        }

        private async Task<ApiMutationResult> TrySendAsync(HttpMethod method, string relativeUrl, Product product, string successMessage)
        {
            try
            {
                using (var request = new HttpRequestMessage(method, relativeUrl))
                {
                    if (product != null)
                    {
                        var payload = JsonConvert.SerializeObject(product, Formatting.Indented);
                        request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
                    }

                    using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return ApiMutationResult.Ok(successMessage);
                        }

                        if ((int)response.StatusCode == 404 || (int)response.StatusCode == 405)
                        {
                            return ApiMutationResult.Failed("Products API is read-only in the current workshop modules. Local working copy updated.");
                        }

                        var details = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return ApiMutationResult.Failed(string.Format("Products API returned {0}: {1}", (int)response.StatusCode, details));
                    }
                }
            }
            catch (Exception ex)
            {
                return ApiMutationResult.Failed("Could not reach Products API. Local working copy updated. " + ex.Message);
            }
        }

        private async Task SaveCacheAsync(IEnumerable<Product> products)
        {
            var directory = Path.GetDirectoryName(_cacheFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            using (var writer = new StreamWriter(_cacheFilePath, false, Encoding.UTF8))
            {
                await writer.WriteAsync(json).ConfigureAwait(false);
            }
        }

        private async Task<IList<Product>> LoadCacheAsync()
        {
            if (!File.Exists(_cacheFilePath))
            {
                return new List<Product>();
            }

            using (var reader = new StreamReader(_cacheFilePath, Encoding.UTF8))
            {
                var json = await reader.ReadToEndAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
            }
        }
    }
}
