using eShopLite.Admin.Forms;
using eShopLite.Admin.Options;
using eShopLite.Admin.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace eShopLite.Admin;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var builder = Host.CreateApplicationBuilder();
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        builder.Services
            .Configure<AdminOptions>(builder.Configuration.GetSection("Admin"))
            .AddSingleton(sp => sp.GetRequiredService<IOptions<AdminOptions>>().Value)
            .AddSingleton<OrderRepository>()
            .AddSingleton<MainForm>();

        builder.Services.AddHttpClient<ProductApiClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<AdminOptions>>().Value;
            client.BaseAddress = new Uri(options.ProductsApiBaseUrl, UriKind.Absolute);
            client.Timeout = TimeSpan.FromSeconds(options.ProductsApiTimeoutSeconds);
        });

        using var host = builder.Build();
        Application.Run(host.Services.GetRequiredService<MainForm>());
    }
}