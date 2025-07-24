using System.Text.Json.Serialization;

namespace eShopLite.Store.DataEntities;

public class StoreInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("city")]
    public string? City { get; set; }
    [JsonPropertyName("state")]
    public string? State { get; set; }
    [JsonPropertyName("hours")]
    public string? Hours { get; set; }
}

[JsonSerializable(typeof(List<StoreInfo>))]
public sealed partial class StoreInfoSerializerContext : JsonSerializerContext
{
}