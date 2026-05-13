using eShopLite.AdminFx.Models;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace eShopLite.AdminFx.Forms
{
    public partial class ProductEditForm : Form
    {
        public ProductEditForm(Product product)
        {
            InitializeComponent();
            Product = product ?? new Product();
        }

        public Product Product { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtName.Text = Product.Name ?? string.Empty;
            txtDescription.Text = Product.Description ?? string.Empty;
            txtPrice.Text = Product.Price.ToString("0.00", CultureInfo.InvariantCulture);
            txtImageUrl.Text = Product.ImageUrl ?? string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal price;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(this, "Product name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out price))
            {
                MessageBox.Show(this, "Price must be a valid decimal value.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            Product.Name = txtName.Text.Trim();
            Product.Description = txtDescription.Text.Trim();
            Product.Price = price;
            Product.ImageUrl = txtImageUrl.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
