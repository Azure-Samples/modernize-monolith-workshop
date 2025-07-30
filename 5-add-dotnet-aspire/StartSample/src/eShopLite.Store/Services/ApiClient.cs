using System.Text.Json;

namespace eShopLite.Store.Services
{
    public abstract class ApiClient
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILogger<ApiClient> _logger;
        protected readonly JsonSerializerOptions _jsonOptions;

        protected ApiClient(HttpClient httpClient, ILogger<ApiClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
        }

        protected async Task<T?> GetAsync<T>(string endpoint)
        {
            try
            {
                _logger.LogInformation("Making GET request to {Endpoint}", endpoint);
                var response = await _httpClient.GetAsync(endpoint);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(content, _jsonOptions);
                }
                else
                {
                    _logger.LogWarning("HTTP GET request to {Endpoint} failed with status code {StatusCode}", 
                        endpoint, response.StatusCode);
                    return default;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error making GET request to {Endpoint}", endpoint);
                throw;
            }
        }

        protected async Task<IEnumerable<T>> GetListAsync<T>(string endpoint)
        {
            try
            {
                _logger.LogInformation("Making GET list request to {Endpoint}", endpoint);
                var response = await _httpClient.GetAsync(endpoint);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<IEnumerable<T>>(content, _jsonOptions);
                    return result ?? Enumerable.Empty<T>();
                }
                else
                {
                    _logger.LogWarning("HTTP GET list request to {Endpoint} failed with status code {StatusCode}", 
                        endpoint, response.StatusCode);
                    return Enumerable.Empty<T>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error making GET list request to {Endpoint}", endpoint);
                throw;
            }
        }
    }
}