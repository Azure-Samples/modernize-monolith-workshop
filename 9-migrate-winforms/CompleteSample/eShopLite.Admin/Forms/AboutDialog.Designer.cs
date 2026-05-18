namespace eShopLite.Admin.Forms;

partial class AboutDialog
{
    private System.ComponentModel.IContainer components = null!;
    private Label lblTitle;
    private Label lblDetails;
    private Button btnClose;

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
        lblTitle = new Label();
        lblDetails = new Label();
        btnClose = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(22, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(196, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "eShopLite Admin";
        // 
        // lblDetails
        // 
        lblDetails.AutoSize = true;
        lblDetails.Location = new Point(24, 67);
        lblDetails.Name = "lblDetails";
        lblDetails.Size = new Size(361, 100);
        lblDetails.TabIndex = 1;
        lblDetails.Text = "Modern WinForms sample for Module 9.\r\n\r\nDemonstrates SDK-style projects, appsett" +
    "ings.json,\r\nIHttpClientFactory, and modern .NET patterns.";
        // 
        // btnClose
        // 
        btnClose.DialogResult = DialogResult.OK;
        btnClose.Location = new Point(310, 180);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(75, 34);
        btnClose.TabIndex = 2;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        // 
        // AboutDialog
        // 
        AcceptButton = btnClose;
        AutoScaleDimensions = new SizeF(9F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnClose;
        ClientSize = new Size(418, 234);
        Controls.Add(btnClose);
        Controls.Add(lblDetails);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AboutDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "About";
        ResumeLayout(false);
        PerformLayout();
    }
}
