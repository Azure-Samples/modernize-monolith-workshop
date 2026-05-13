using System.Text.Json.Serialization;

namespace eShopLite.Admin.Models;

public sealed class OrderSummary
{
    [JsonPropertyName("orderNumber")]
    public string OrderNumber { get; set; } = string.Empty;

    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("orderedAt")]
    public DateTime OrderedAt { get; set; }

    [JsonPropertyName("total")]
    public decimal Total { get; set; }

    [JsonPropertyName("itemCount")]
    public int ItemCount { get; set; }
}
