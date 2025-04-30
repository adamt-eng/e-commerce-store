using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
{
    partial class Cart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cart));
            CartTable = new DataGridView();
            proceedToCheckoutButton = new Button();
            TotalPriceLabel = new Label();
            CartLabel = new Label();
            backToHomePageButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CartTable).BeginInit();
            SuspendLayout();
            // 
            // CartTable
            // 
            CartTable.BorderStyle = BorderStyle.None;
            CartTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(CartTable, "CartTable");
            CartTable.Name = "CartTable";
            // 
            // proceedToCheckoutButton
            // 
            resources.ApplyResources(proceedToCheckoutButton, "proceedToCheckoutButton");
            proceedToCheckoutButton.ForeColor = Color.FromArgb(241, 250, 238);
            proceedToCheckoutButton.Name = "proceedToCheckoutButton";
            proceedToCheckoutButton.UseVisualStyleBackColor = true;
            proceedToCheckoutButton.Click += proceedToCheckoutButton_Click;
            // 
            // TotalPriceLabel
            // 
            TotalPriceLabel.BackColor = Color.FromArgb(29, 53, 87);
            resources.ApplyResources(TotalPriceLabel, "TotalPriceLabel");
            TotalPriceLabel.ForeColor = Color.White;
            TotalPriceLabel.Name = "TotalPriceLabel";
            // 
            // CartLabel
            // 
            resources.ApplyResources(CartLabel, "CartLabel");
            CartLabel.ForeColor = Color.FromArgb(241, 250, 238);
            CartLabel.Name = "CartLabel";
            // 
            // backToHomePageButton
            // 
            resources.ApplyResources(backToHomePageButton, "backToHomePageButton");
            backToHomePageButton.ForeColor = Color.FromArgb(241, 250, 238);
            backToHomePageButton.Name = "backToHomePageButton";
            backToHomePageButton.UseVisualStyleBackColor = true;
            backToHomePageButton.Click += backToHomePageButton_Click;
            // 
            // Cart
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(backToHomePageButton);
            Controls.Add(CartLabel);
            Controls.Add(TotalPriceLabel);
            Controls.Add(proceedToCheckoutButton);
            Controls.Add(CartTable);
            MaximizeBox = false;
            Name = "Cart";
            Load += Cart_Load;
            ((System.ComponentModel.ISupportInitialize)CartTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button proceedToCheckoutButton;
        private DataGridView CartTable;
        private Label TotalPriceLabel;
        private Label CartLabel;
        private Button backToHomePageButton;
    }
}
