using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
{
    partial class ProductView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductView));
            titleLabel = new Label();
            productImageButton = new Button();
            inCartNumericUpDown = new NumericUpDown();
            label1 = new Label();
            priceLabel = new Label();
            publishedAtLabel = new Label();
            quantityInStockLabel = new Label();
            productDescriptionLabel = new Label();
            sellerLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)inCartNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // productImageButton
            // 
            productImageButton.BackgroundImage = Properties.Resources.cart;
            resources.ApplyResources(productImageButton, "productImageButton");
            productImageButton.ForeColor = Color.FromArgb(241, 250, 238);
            productImageButton.Name = "productImageButton";
            productImageButton.UseVisualStyleBackColor = true;
            // 
            // inCartNumericUpDown
            // 
            resources.ApplyResources(inCartNumericUpDown, "inCartNumericUpDown");
            inCartNumericUpDown.Name = "inCartNumericUpDown";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(241, 250, 238);
            label1.Name = "label1";
            // 
            // priceLabel
            // 
            resources.ApplyResources(priceLabel, "priceLabel");
            priceLabel.ForeColor = Color.FromArgb(241, 250, 238);
            priceLabel.Name = "priceLabel";
            // 
            // publishedAtLabel
            // 
            resources.ApplyResources(publishedAtLabel, "publishedAtLabel");
            publishedAtLabel.ForeColor = Color.FromArgb(241, 250, 238);
            publishedAtLabel.Name = "publishedAtLabel";
            // 
            // quantityInStockLabel
            // 
            resources.ApplyResources(quantityInStockLabel, "quantityInStockLabel");
            quantityInStockLabel.ForeColor = Color.FromArgb(241, 250, 238);
            quantityInStockLabel.Name = "quantityInStockLabel";
            // 
            // productDescriptionLabel
            // 
            productDescriptionLabel.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(productDescriptionLabel, "productDescriptionLabel");
            productDescriptionLabel.ForeColor = Color.FromArgb(241, 250, 238);
            productDescriptionLabel.Name = "productDescriptionLabel";
            // 
            // sellerLabel
            // 
            resources.ApplyResources(sellerLabel, "sellerLabel");
            sellerLabel.ForeColor = Color.FromArgb(241, 250, 238);
            sellerLabel.Name = "sellerLabel";
            // 
            // ProductView
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(sellerLabel);
            Controls.Add(productDescriptionLabel);
            Controls.Add(quantityInStockLabel);
            Controls.Add(publishedAtLabel);
            Controls.Add(priceLabel);
            Controls.Add(label1);
            Controls.Add(inCartNumericUpDown);
            Controls.Add(productImageButton);
            Controls.Add(titleLabel);
            Name = "ProductView";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)inCartNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
        private TextBox passwordTextBox;
        private Label titleLabel;
        private Button productImageButton;
        private NumericUpDown inCartNumericUpDown;
        private Label label1;
        private Label priceLabel;
        private Label publishedAtLabel;
        private Label quantityInStockLabel;
        private Label productDescriptionLabel;
        private Label sellerLabel;
    }
}
