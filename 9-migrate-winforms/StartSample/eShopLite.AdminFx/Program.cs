using eShopLite.AdminFx.Forms;
using eShopLite.AdminFx.Models;
using eShopLite.AdminFx.Services;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace eShopLite.AdminFx
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var settings = LoadSettings();
            var productApiClient = new ProductApiClient(settings.ProductsApiBaseUrl, settings.ProductsApiTimeoutSeconds);
            var orderRepository = new OrderRepository(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.OrdersFilePath));

            Application.Run(new MainForm(productApiClient, orderRepository, settings));
        }

        private static AdminSettings LoadSettings()
        {
            return new AdminSettings
            {
                ProductsApiBaseUrl = ConfigurationManager.AppSettings["ProductsApiBaseUrl"] ?? "https://localhost:7102/",
                ProductsApiTimeoutSeconds = int.TryParse(ConfigurationManager.AppSettings["ProductsApiTimeoutSeconds"], out var timeout) ? timeout : 10,
                OrdersFilePath = ConfigurationManager.AppSettings["OrdersFilePath"] ?? @"Data\orders.json"
            };
        }
    }
}
