using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
{
    partial class CustomerPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerPage));
            searchForProductsTextBox = new TextBox();
            cartButton = new Button();
            titleLabel = new Label();
            dataGridView1 = new DataGridView();
            myProfileButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // searchForProductsTextBox
            // 
            searchForProductsTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(searchForProductsTextBox, "searchForProductsTextBox");
            searchForProductsTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            searchForProductsTextBox.Name = "searchForProductsTextBox";
            searchForProductsTextBox.TabStop = false;
            searchForProductsTextBox.TextChanged += searchForProductsTextBox_TextChanged;
            // 
            // cartButton
            // 
            cartButton.BackgroundImage = Properties.Resources.cart;
            resources.ApplyResources(cartButton, "cartButton");
            cartButton.ForeColor = Color.FromArgb(241, 250, 238);
            cartButton.Name = "cartButton";
            cartButton.UseVisualStyleBackColor = true;
            cartButton.Click += cartButton_Click;
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
            // 
            // myProfileButton
            // 
            resources.ApplyResources(myProfileButton, "myProfileButton");
            myProfileButton.FlatAppearance.BorderSize = 0;
            myProfileButton.ForeColor = Color.FromArgb(241, 250, 238);
            myProfileButton.Name = "myProfileButton";
            myProfileButton.UseVisualStyleBackColor = true;
            myProfileButton.Click += myProfileButton_Click;
            // 
            // CustomerPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(myProfileButton);
            Controls.Add(dataGridView1);
            Controls.Add(titleLabel);
            Controls.Add(cartButton);
            Controls.Add(searchForProductsTextBox);
            Name = "CustomerPage";
            Load += CustomerPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchForProductsTextBox;
        private Button cartButton;
        private Label titleLabel;
        private DataGridView dataGridView1;
        private Button myProfileButton;
    }
}
