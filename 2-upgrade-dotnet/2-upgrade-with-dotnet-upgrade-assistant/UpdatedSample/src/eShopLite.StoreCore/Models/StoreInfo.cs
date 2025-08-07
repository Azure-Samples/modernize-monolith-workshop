using Newtonsoft.Json;

namespace eShopLite.StoreFx.Models
{
    public class StoreInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("hours")]
        public string Hours { get; set; }
    }
}
