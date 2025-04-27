using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
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
            Item = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewTextBoxColumn();
            proceedToCheckoutButton = new Button();
            TotalPriceLabel = new Label();
            CartLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)CartTable).BeginInit();
            SuspendLayout();
            // 
            // CartTable
            // 
            CartTable.BorderStyle = BorderStyle.None;
            CartTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CartTable.Columns.AddRange(new DataGridViewColumn[] { Item, Price, Quantity, Total, Delete });
            resources.ApplyResources(CartTable, "CartTable");
            CartTable.Name = "CartTable";
            CartTable.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Item
            // 
            resources.ApplyResources(Item, "Item");
            Item.Name = "Item";
            // 
            // Price
            // 
            resources.ApplyResources(Price, "Price");
            Price.Name = "Price";
            // 
            // Quantity
            // 
            resources.ApplyResources(Quantity, "Quantity");
            Quantity.Name = "Quantity";
            // 
            // Total
            // 
            resources.ApplyResources(Total, "Total");
            Total.Name = "Total";
            // 
            // Delete
            // 
            resources.ApplyResources(Delete, "Delete");
            Delete.Name = "Delete";
            // 
            // proceedToCheckoutButton
            // 
            resources.ApplyResources(proceedToCheckoutButton, "proceedToCheckoutButton");
            proceedToCheckoutButton.ForeColor = Color.FromArgb(241, 250, 238);
            proceedToCheckoutButton.Name = "proceedToCheckoutButton";
            proceedToCheckoutButton.UseVisualStyleBackColor = true;
            // 
            // TotalPriceLabel
            // 
            TotalPriceLabel.BackColor = Color.FromArgb(29, 53, 87);
            resources.ApplyResources(TotalPriceLabel, "TotalPriceLabel");
            TotalPriceLabel.ForeColor = Color.White;
            TotalPriceLabel.Name = "TotalPriceLabel";
            TotalPriceLabel.Click += label1_Click;
            // 
            // CartLabel
            // 
            resources.ApplyResources(CartLabel, "CartLabel");
            CartLabel.ForeColor = Color.FromArgb(241, 250, 238);
            CartLabel.Name = "CartLabel";
            // 
            // Cart
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(CartLabel);
            Controls.Add(TotalPriceLabel);
            Controls.Add(proceedToCheckoutButton);
            Controls.Add(CartTable);
            Name = "Cart";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)CartTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button proceedToCheckoutButton;
        private DataGridView CartTable;
        private Label TotalPriceLabel;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Delete;
        private Label CartLabel;
    }
}
