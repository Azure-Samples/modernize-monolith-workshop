using System.Text.Json.Serialization;

namespace eShopLite.StoreCore.Models
{
    public class StoreInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;
        
        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;
        
        [JsonPropertyName("hours")]
        public string Hours { get; set; } = string.Empty;
    }
}
