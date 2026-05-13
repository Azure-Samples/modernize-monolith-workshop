namespace eShopLite.Admin.Forms;

partial class ProductEditForm
{
    private System.ComponentModel.IContainer components = null!;
    private Label lblName;
    private Label lblDescription;
    private Label lblPrice;
    private Label lblImageUrl;
    private TextBox txtName;
    private TextBox txtDescription;
    private TextBox txtPrice;
    private TextBox txtImageUrl;
    private Button btnSave;
    private Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblName = new Label();
        lblDescription = new Label();
        lblPrice = new Label();
        lblImageUrl = new Label();
        txtName = new TextBox();
        txtDescription = new TextBox();
        txtPrice = new TextBox();
        txtImageUrl = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(20, 22);
        lblName.Name = "lblName";
        lblName.Size = new Size(49, 25);
        lblName.TabIndex = 0;
        lblName.Text = "Name";
        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(20, 70);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(87, 25);
        lblDescription.TabIndex = 2;
        lblDescription.Text = "Description";
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(20, 191);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(44, 25);
        lblPrice.TabIndex = 4;
        lblPrice.Text = "Price";
        // 
        // lblImageUrl
        // 
        lblImageUrl.AutoSize = true;
        lblImageUrl.Location = new Point(20, 239);
        lblImageUrl.Name = "lblImageUrl";
        lblImageUrl.Size = new Size(83, 25);
        lblImageUrl.TabIndex = 6;
        lblImageUrl.Text = "Image Url";
        // 
        // txtName
        // 
        txtName.Location = new Point(133, 19);
        txtName.Name = "txtName";
        txtName.Size = new Size(367, 31);
        txtName.TabIndex = 1;
        // 
        // txtDescription
        // 
        txtDescription.Location = new Point(133, 67);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.ScrollBars = ScrollBars.Vertical;
        txtDescription.Size = new Size(367, 100);
        txtDescription.TabIndex = 3;
        // 
        // txtPrice
        // 
        txtPrice.Location = new Point(133, 188);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new Size(150, 31);
        txtPrice.TabIndex = 5;
        // 
        // txtImageUrl
        // 
        txtImageUrl.Location = new Point(133, 236);
        txtImageUrl.Name = "txtImageUrl";
        txtImageUrl.Size = new Size(367, 31);
        txtImageUrl.TabIndex = 7;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(344, 287);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 34);
        btnSave.TabIndex = 8;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(425, 287);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 34);
        btnCancel.TabIndex = 9;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // ProductEditForm
        // 
        AcceptButton = btnSave;
        AutoScaleDimensions = new SizeF(9F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(526, 339);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtImageUrl);
        Controls.Add(txtPrice);
        Controls.Add(txtDescription);
        Controls.Add(txtName);
        Controls.Add(lblImageUrl);
        Controls.Add(lblPrice);
        Controls.Add(lblDescription);
        Controls.Add(lblName);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ProductEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Product Editor";
        ResumeLayout(false);
        PerformLayout();
    }
}
