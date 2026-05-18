using eShopLite.Admin.Models;
using System.Globalization;

namespace eShopLite.Admin.Forms;

public partial class ProductEditForm : Form
{
    public ProductEditForm(Product product)
    {
        InitializeComponent();
        Product = product ?? new Product();
    }

    public Product Product { get; }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        txtName.Text = Product.Name;
        txtDescription.Text = Product.Description;
        txtPrice.Text = Product.Price.ToString("0.00", CultureInfo.InvariantCulture);
        txtImageUrl.Text = Product.ImageUrl;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show(this, "Product name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
        }

        if (!decimal.TryParse(txtPrice.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out var price))
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

    private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
}
