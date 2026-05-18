using eShopLite.AdminFx.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eShopLite.AdminFx.Services
{
    public class OrderRepository
    {
        private readonly string _ordersFilePath;

        public OrderRepository(string ordersFilePath)
        {
            _ordersFilePath = ordersFilePath;
        }

        public IList<OrderSummary> GetOrders()
        {
            if (!File.Exists(_ordersFilePath))
            {
                return new List<OrderSummary>();
            }

            var json = File.ReadAllText(_ordersFilePath);
            var orders = JsonConvert.DeserializeObject<List<OrderSummary>>(json) ?? new List<OrderSummary>();
            return orders.OrderByDescending(order => order.OrderedAt).ToList();
        }
    }
}
