using Newtonsoft.Json;
using System;

namespace eShopLite.AdminFx.Models
{
    public class OrderSummary
    {
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("itemCount")]
        public int ItemCount { get; set; }
    }
}
