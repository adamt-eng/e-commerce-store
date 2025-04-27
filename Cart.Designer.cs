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
            CartLabelTextBox = new Label();
            CartTable = new DataGridView();
            loginButton = new Button();
            TotalPriceLabel = new Label();
            Item = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)CartTable).BeginInit();
            SuspendLayout();
            // 
            // CartLabelTextBox
            // 
            CartLabelTextBox.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(CartLabelTextBox, "CartLabelTextBox");
            CartLabelTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            CartLabelTextBox.Name = "CartLabelTextBox";
            CartLabelTextBox.Click += titleLabel_Click;
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
            // loginButton
            // 
            resources.ApplyResources(loginButton, "loginButton");
            loginButton.ForeColor = Color.FromArgb(241, 250, 238);
            loginButton.Name = "loginButton";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // TotalPriceLabel
            // 
            resources.ApplyResources(TotalPriceLabel, "TotalPriceLabel");
            TotalPriceLabel.BackColor = Color.Navy;
            TotalPriceLabel.Name = "TotalPriceLabel";
            TotalPriceLabel.Click += label1_Click;
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
            // Cart
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(TotalPriceLabel);
            Controls.Add(loginButton);
            Controls.Add(CartTable);
            Controls.Add(CartLabelTextBox);
            Name = "Cart";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)CartTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private TextBox passwordTextBox;
        private Label CartLabelTextBox;
        private DataGridView CartTable;
        private Label TotalPriceLabel;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Delete;
    }
}
