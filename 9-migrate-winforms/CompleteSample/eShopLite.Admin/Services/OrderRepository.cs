using eShopLite.Admin.Models;
using eShopLite.Admin.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace eShopLite.Admin.Services;

public sealed class OrderRepository
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    private readonly string _ordersFilePath;

    public OrderRepository(IOptions<AdminOptions> options)
    {
        _ordersFilePath = Path.Combine(AppContext.BaseDirectory, options.Value.OrdersFilePath);
    }

    public IReadOnlyList<OrderSummary> GetOrders()
    {
        if (!File.Exists(_ordersFilePath))
        {
            return [];
        }

        using var stream = File.OpenRead(_ordersFilePath);
        var orders = JsonSerializer.Deserialize<List<OrderSummary>>(stream, SerializerOptions) ?? [];
        return orders.OrderByDescending(order => order.OrderedAt).ToList();
    }
}
