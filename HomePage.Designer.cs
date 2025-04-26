using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            searchForProductsTextBox = new TextBox();
            cartButton = new Button();
            titleLabel = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
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
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.FromArgb(241, 250, 238);
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // HomePage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(titleLabel);
            Controls.Add(cartButton);
            Controls.Add(searchForProductsTextBox);
            Name = "HomePage";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private TextBox searchForProductsTextBox;
        private TextBox passwordTextBox;
        private Button cartButton;
        private Label titleLabel;
        private DataGridView dataGridView1;
        private Button button1;
    }
}
