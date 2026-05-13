namespace eShopLite.Admin.Options;

public sealed class AdminOptions
{
    public string ProductsApiBaseUrl { get; set; } = "https://localhost:7102/";

    public int ProductsApiTimeoutSeconds { get; set; } = 10;

    public string OrdersFilePath { get; set; } = @"Data\orders.json";
}
