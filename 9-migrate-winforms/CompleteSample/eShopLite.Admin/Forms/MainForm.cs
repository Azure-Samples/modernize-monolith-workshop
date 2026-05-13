using eShopLite.Admin.Models;
using eShopLite.Admin.Options;
using eShopLite.Admin.Services;
using System.ComponentModel;
using System.Linq;

namespace eShopLite.Admin.Forms;

public partial class MainForm(ProductApiClient productApiClient, OrderRepository orderRepository, AdminOptions options) : Form
{
    private readonly BindingSource _productBindingSource = new();
    private readonly BindingSource _orderBindingSource = new();
    private BindingList<Product> _products = new();

    public MainForm() : this(new ProductApiClient(new HttpClient()), new OrderRepository(Microsoft.Extensions.Options.Options.Create(new AdminOptions())), new AdminOptions())
    {
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Text = $"eShopLite Admin - {options.ProductsApiBaseUrl}";
        productsGrid.AutoGenerateColumns = false;
        ordersGrid.AutoGenerateColumns = false;
        productsGrid.DataSource = _productBindingSource;
        ordersGrid.DataSource = _orderBindingSource;
        await LoadProductsAsync();
        LoadOrders();
    }

    private async Task LoadProductsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            UseWaitCursor = true;
            var products = await productApiClient.GetProductsAsync(cancellationToken);
            _products = new BindingList<Product>(products.OrderBy(product => product.Name).ToList());
            _productBindingSource.DataSource = _products;
            SetStatus($"Loaded {_products.Count} products.");
        }
        catch (Exception ex)
        {
            SetStatus($"Could not load products: {ex.Message}");
            MessageBox.Show(this, ex.Message, "Products API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            UseWaitCursor = false;
        }
    }

    private void LoadOrders() => _orderBindingSource.DataSource = orderRepository.GetOrders();

    private Product? GetSelectedProduct() => _productBindingSource.Current as Product;

    private async Task PersistProductsAsync(Func<CancellationToken, Task<ApiMutationResult>> apiAction)
    {
        await productApiClient.SaveWorkingCopyAsync(_products.ToList());
        var result = await apiAction(CancellationToken.None);
        SetStatus(result.Message);
    }

    private int GetNextProductId() => _products.Any() ? _products.Max(product => product.Id) + 1 : 1;

    private void SetStatus(string message) => toolStripStatusLabel.Text = message;

    private async void refreshProductsToolStripMenuItem_Click(object sender, EventArgs e) => await LoadProductsAsync();

    private async void btnRefresh_Click(object sender, EventArgs e) => await LoadProductsAsync();

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        using var dialog = new ProductEditForm(new Product());
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        dialog.Product.Id = GetNextProductId();
        _products.Add(dialog.Product.Clone());
        _productBindingSource.ResetBindings(false);
        await PersistProductsAsync(ct => productApiClient.TryCreateProductAsync(dialog.Product, ct));
    }

    private async void btnEdit_Click(object sender, EventArgs e)
    {
        if (GetSelectedProduct() is not { } selected)
        {
            return;
        }

        using var dialog = new ProductEditForm(selected.Clone());
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        selected.Name = dialog.Product.Name;
        selected.Description = dialog.Product.Description;
        selected.Price = dialog.Product.Price;
        selected.ImageUrl = dialog.Product.ImageUrl;
        _productBindingSource.ResetBindings(false);
        await PersistProductsAsync(ct => productApiClient.TryUpdateProductAsync(selected, ct));
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (GetSelectedProduct() is not { } selected)
        {
            return;
        }

        if (MessageBox.Show(this, $"Delete '{selected.Name}'?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        _products.Remove(selected);
        _productBindingSource.ResetBindings(false);
        await PersistProductsAsync(ct => productApiClient.TryDeleteProductAsync(selected.Id, ct));
    }

    private void btnAbout_Click(object sender, EventArgs e) => ShowAboutDialog();

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => ShowAboutDialog();

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

    private void ShowAboutDialog()
    {
        using var dialog = new AboutDialog();
        dialog.ShowDialog(this);
    }
}
