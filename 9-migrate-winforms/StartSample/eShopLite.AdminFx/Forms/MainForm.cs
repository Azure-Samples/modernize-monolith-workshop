using eShopLite.AdminFx.Models;
using eShopLite.AdminFx.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShopLite.AdminFx.Forms
{
    public partial class MainForm : Form
    {
        private readonly ProductApiClient _productApiClient;
        private readonly OrderRepository _orderRepository;
        private readonly AdminSettings _settings;
        private readonly BindingSource _productBindingSource = new BindingSource();
        private readonly BindingSource _orderBindingSource = new BindingSource();
        private BindingList<Product> _products = new BindingList<Product>();

        public MainForm(ProductApiClient productApiClient, OrderRepository orderRepository, AdminSettings settings)
        {
            _productApiClient = productApiClient;
            _orderRepository = orderRepository;
            _settings = settings;

            InitializeComponent();
            productsGrid.AutoGenerateColumns = false;
            ordersGrid.AutoGenerateColumns = false;
            productsGrid.DataSource = _productBindingSource;
            ordersGrid.DataSource = _orderBindingSource;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = string.Format("eShopLite AdminFx - {0}", _settings.ProductsApiBaseUrl);
            await LoadProductsAsync();
            LoadOrders();
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                UseWaitCursor = true;
                var products = await _productApiClient.GetProductsAsync();
                _products = new BindingList<Product>(products.OrderBy(product => product.Name).ToList());
                _productBindingSource.DataSource = _products;
                SetStatus(string.Format("Loaded {0} products.", _products.Count));
            }
            catch (Exception ex)
            {
                SetStatus("Could not load products: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Products API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void LoadOrders()
        {
            _orderBindingSource.DataSource = _orderRepository.GetOrders();
        }

        private Product GetSelectedProduct()
        {
            return _productBindingSource.Current as Product;
        }

        private async Task PersistProductsAsync(Product product, Func<Task<ApiMutationResult>> apiAction)
        {
            await _productApiClient.SaveWorkingCopyAsync(_products.ToList());
            var result = await apiAction();
            SetStatus(result.Message);
        }

        private int GetNextProductId()
        {
            return _products.Any() ? _products.Max(product => product.Id) + 1 : 1;
        }

        private void SetStatus(string message)
        {
            toolStripStatusLabel.Text = message;
        }

        private async void refreshProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new Product();
            using (var dialog = new ProductEditForm(product))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                dialog.Product.Id = GetNextProductId();
                _products.Add(dialog.Product.Clone());
                _productBindingSource.ResetBindings(false);
                await PersistProductsAsync(dialog.Product, () => _productApiClient.TryCreateProductAsync(dialog.Product));
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedProduct();
            if (selected == null)
            {
                return;
            }

            var workingCopy = selected.Clone();
            using (var dialog = new ProductEditForm(workingCopy))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                selected.Name = dialog.Product.Name;
                selected.Description = dialog.Product.Description;
                selected.Price = dialog.Product.Price;
                selected.ImageUrl = dialog.Product.ImageUrl;
                _productBindingSource.ResetBindings(false);
                await PersistProductsAsync(selected, () => _productApiClient.TryUpdateProductAsync(selected));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedProduct();
            if (selected == null)
            {
                return;
            }

            if (MessageBox.Show(this, string.Format("Delete '{0}'?", selected.Name), "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            _products.Remove(selected);
            _productBindingSource.ResetBindings(false);
            await PersistProductsAsync(selected, () => _productApiClient.TryDeleteProductAsync(selected.Id));
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowAboutDialog()
        {
            using (var dialog = new AboutDialog())
            {
                dialog.ShowDialog(this);
            }
        }
    }
}
