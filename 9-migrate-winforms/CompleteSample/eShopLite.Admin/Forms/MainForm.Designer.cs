namespace eShopLite.Admin.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null!;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem refreshProductsToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private TabControl tabControl1;
    private TabPage tabProducts;
    private TabPage tabOrders;
    private ToolStrip productToolStrip;
    private ToolStripButton btnRefresh;
    private ToolStripButton btnAdd;
    private ToolStripButton btnEdit;
    private ToolStripButton btnDelete;
    private ToolStripButton btnAbout;
    private DataGridView productsGrid;
    private DataGridView ordersGrid;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colDescription;
    private DataGridViewTextBoxColumn colPrice;
    private DataGridViewTextBoxColumn colImageUrl;
    private DataGridViewTextBoxColumn colOrderNumber;
    private DataGridViewTextBoxColumn colCustomer;
    private DataGridViewTextBoxColumn colStatus;
    private DataGridViewTextBoxColumn colOrderedAt;
    private DataGridViewTextBoxColumn colTotal;
    private DataGridViewTextBoxColumn colItemCount;

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
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        refreshProductsToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        tabControl1 = new TabControl();
        tabProducts = new TabPage();
        productsGrid = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colName = new DataGridViewTextBoxColumn();
        colDescription = new DataGridViewTextBoxColumn();
        colPrice = new DataGridViewTextBoxColumn();
        colImageUrl = new DataGridViewTextBoxColumn();
        productToolStrip = new ToolStrip();
        btnRefresh = new ToolStripButton();
        btnAdd = new ToolStripButton();
        btnEdit = new ToolStripButton();
        btnDelete = new ToolStripButton();
        btnAbout = new ToolStripButton();
        tabOrders = new TabPage();
        ordersGrid = new DataGridView();
        colOrderNumber = new DataGridViewTextBoxColumn();
        colCustomer = new DataGridViewTextBoxColumn();
        colStatus = new DataGridViewTextBoxColumn();
        colOrderedAt = new DataGridViewTextBoxColumn();
        colTotal = new DataGridViewTextBoxColumn();
        colItemCount = new DataGridViewTextBoxColumn();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabel = new ToolStripStatusLabel();
        menuStrip1.SuspendLayout();
        tabControl1.SuspendLayout();
        tabProducts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)productsGrid).BeginInit();
        productToolStrip.SuspendLayout();
        tabOrders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ordersGrid).BeginInit();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange([fileToolStripMenuItem, helpToolStripMenuItem]);
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1199, 33);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange([refreshProductsToolStripMenuItem, exitToolStripMenuItem]);
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(54, 29);
        fileToolStripMenuItem.Text = "File";
        // 
        // refreshProductsToolStripMenuItem
        // 
        refreshProductsToolStripMenuItem.Name = "refreshProductsToolStripMenuItem";
        refreshProductsToolStripMenuItem.Size = new Size(241, 34);
        refreshProductsToolStripMenuItem.Text = "Refresh Products";
        refreshProductsToolStripMenuItem.Click += refreshProductsToolStripMenuItem_Click;
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(241, 34);
        exitToolStripMenuItem.Text = "Exit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange([aboutToolStripMenuItem]);
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(65, 29);
        helpToolStripMenuItem.Text = "Help";
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(164, 34);
        aboutToolStripMenuItem.Text = "About";
        aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabProducts);
        tabControl1.Controls.Add(tabOrders);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 33);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1199, 577);
        tabControl1.TabIndex = 1;
        // 
        // tabProducts
        // 
        tabProducts.Controls.Add(productsGrid);
        tabProducts.Controls.Add(productToolStrip);
        tabProducts.Location = new Point(4, 34);
        tabProducts.Name = "tabProducts";
        tabProducts.Padding = new Padding(3);
        tabProducts.Size = new Size(1191, 539);
        tabProducts.TabIndex = 0;
        tabProducts.Text = "Products";
        tabProducts.UseVisualStyleBackColor = true;
        // 
        // productsGrid
        // 
        productsGrid.AllowUserToAddRows = false;
        productsGrid.AllowUserToDeleteRows = false;
        productsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        productsGrid.Columns.AddRange([colId, colName, colDescription, colPrice, colImageUrl]);
        productsGrid.Dock = DockStyle.Fill;
        productsGrid.Location = new Point(3, 42);
        productsGrid.MultiSelect = false;
        productsGrid.Name = "productsGrid";
        productsGrid.ReadOnly = true;
        productsGrid.RowHeadersWidth = 62;
        productsGrid.RowTemplate.Height = 33;
        productsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        productsGrid.Size = new Size(1185, 494);
        productsGrid.TabIndex = 1;
        // 
        // colId
        // 
        colId.DataPropertyName = "Id";
        colId.HeaderText = "Id";
        colId.MinimumWidth = 8;
        colId.Name = "colId";
        colId.ReadOnly = true;
        colId.Width = 60;
        // 
        // colName
        // 
        colName.DataPropertyName = "Name";
        colName.HeaderText = "Name";
        colName.MinimumWidth = 8;
        colName.Name = "colName";
        colName.ReadOnly = true;
        colName.Width = 220;
        // 
        // colDescription
        // 
        colDescription.DataPropertyName = "Description";
        colDescription.HeaderText = "Description";
        colDescription.MinimumWidth = 8;
        colDescription.Name = "colDescription";
        colDescription.ReadOnly = true;
        colDescription.Width = 320;
        // 
        // colPrice
        // 
        colPrice.DataPropertyName = "Price";
        colPrice.DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" };
        colPrice.HeaderText = "Price";
        colPrice.MinimumWidth = 8;
        colPrice.Name = "colPrice";
        colPrice.ReadOnly = true;
        colPrice.Width = 120;
        // 
        // colImageUrl
        // 
        colImageUrl.DataPropertyName = "ImageUrl";
        colImageUrl.HeaderText = "Image Url";
        colImageUrl.MinimumWidth = 8;
        colImageUrl.Name = "colImageUrl";
        colImageUrl.ReadOnly = true;
        colImageUrl.Width = 240;
        // 
        // productToolStrip
        // 
        productToolStrip.ImageScalingSize = new Size(24, 24);
        productToolStrip.Items.AddRange([btnRefresh, btnAdd, btnEdit, btnDelete, btnAbout]);
        productToolStrip.Location = new Point(3, 3);
        productToolStrip.Name = "productToolStrip";
        productToolStrip.Size = new Size(1185, 39);
        productToolStrip.TabIndex = 0;
        productToolStrip.Text = "productToolStrip";
        // 
        // btnRefresh
        // 
        btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(76, 34);
        btnRefresh.Text = "Refresh";
        btnRefresh.Click += btnRefresh_Click;
        // 
        // btnAdd
        // 
        btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(51, 34);
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;
        // 
        // btnEdit
        // 
        btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(49, 34);
        btnEdit.Text = "Edit";
        btnEdit.Click += btnEdit_Click;
        // 
        // btnDelete
        // 
        btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(71, 34);
        btnDelete.Text = "Delete";
        btnDelete.Click += btnDelete_Click;
        // 
        // btnAbout
        // 
        btnAbout.Alignment = ToolStripItemAlignment.Right;
        btnAbout.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnAbout.Name = "btnAbout";
        btnAbout.Size = new Size(63, 34);
        btnAbout.Text = "About";
        btnAbout.Click += btnAbout_Click;
        // 
        // tabOrders
        // 
        tabOrders.Controls.Add(ordersGrid);
        tabOrders.Location = new Point(4, 34);
        tabOrders.Name = "tabOrders";
        tabOrders.Padding = new Padding(3);
        tabOrders.Size = new Size(1191, 539);
        tabOrders.TabIndex = 1;
        tabOrders.Text = "Orders";
        tabOrders.UseVisualStyleBackColor = true;
        // 
        // ordersGrid
        // 
        ordersGrid.AllowUserToAddRows = false;
        ordersGrid.AllowUserToDeleteRows = false;
        ordersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        ordersGrid.Columns.AddRange([colOrderNumber, colCustomer, colStatus, colOrderedAt, colTotal, colItemCount]);
        ordersGrid.Dock = DockStyle.Fill;
        ordersGrid.Location = new Point(3, 3);
        ordersGrid.Name = "ordersGrid";
        ordersGrid.ReadOnly = true;
        ordersGrid.RowHeadersWidth = 62;
        ordersGrid.RowTemplate.Height = 33;
        ordersGrid.Size = new Size(1185, 533);
        ordersGrid.TabIndex = 0;
        // 
        // colOrderNumber
        // 
        colOrderNumber.DataPropertyName = "OrderNumber";
        colOrderNumber.HeaderText = "Order #";
        colOrderNumber.MinimumWidth = 8;
        colOrderNumber.Name = "colOrderNumber";
        colOrderNumber.ReadOnly = true;
        colOrderNumber.Width = 120;
        // 
        // colCustomer
        // 
        colCustomer.DataPropertyName = "CustomerName";
        colCustomer.HeaderText = "Customer";
        colCustomer.MinimumWidth = 8;
        colCustomer.Name = "colCustomer";
        colCustomer.ReadOnly = true;
        colCustomer.Width = 220;
        // 
        // colStatus
        // 
        colStatus.DataPropertyName = "Status";
        colStatus.HeaderText = "Status";
        colStatus.MinimumWidth = 8;
        colStatus.Name = "colStatus";
        colStatus.ReadOnly = true;
        colStatus.Width = 120;
        // 
        // colOrderedAt
        // 
        colOrderedAt.DataPropertyName = "OrderedAt";
        colOrderedAt.DefaultCellStyle = new DataGridViewCellStyle { Format = "g" };
        colOrderedAt.HeaderText = "Ordered At";
        colOrderedAt.MinimumWidth = 8;
        colOrderedAt.Name = "colOrderedAt";
        colOrderedAt.ReadOnly = true;
        colOrderedAt.Width = 180;
        // 
        // colTotal
        // 
        colTotal.DataPropertyName = "Total";
        colTotal.DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" };
        colTotal.HeaderText = "Total";
        colTotal.MinimumWidth = 8;
        colTotal.Name = "colTotal";
        colTotal.ReadOnly = true;
        colTotal.Width = 120;
        // 
        // colItemCount
        // 
        colItemCount.DataPropertyName = "ItemCount";
        colItemCount.HeaderText = "Items";
        colItemCount.MinimumWidth = 8;
        colItemCount.Name = "colItemCount";
        colItemCount.ReadOnly = true;
        colItemCount.Width = 80;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(24, 24);
        statusStrip1.Items.AddRange([toolStripStatusLabel]);
        statusStrip1.Location = new Point(0, 610);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(1199, 32);
        statusStrip1.TabIndex = 2;
        statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabel
        // 
        toolStripStatusLabel.Name = "toolStripStatusLabel";
        toolStripStatusLabel.Size = new Size(59, 25);
        toolStripStatusLabel.Text = "Ready";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(9F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1199, 642);
        Controls.Add(tabControl1);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "eShopLite Admin";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        tabControl1.ResumeLayout(false);
        tabProducts.ResumeLayout(false);
        tabProducts.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)productsGrid).EndInit();
        productToolStrip.ResumeLayout(false);
        productToolStrip.PerformLayout();
        tabOrders.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)ordersGrid).EndInit();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
