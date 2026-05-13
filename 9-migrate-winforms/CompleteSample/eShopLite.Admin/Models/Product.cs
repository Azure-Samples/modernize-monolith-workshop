using System.Text.Json.Serialization;

namespace eShopLite.Admin.Models;

public sealed class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    public Product Clone() => new()
    {
        Id = Id,
        Name = Name,
        Description = Description,
        Price = Price,
        ImageUrl = ImageUrl
    };
}
