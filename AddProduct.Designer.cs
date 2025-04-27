using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            titleLabel = new Label();
            priceLabel = new Label();
            publishedAtLabel = new Label();
            stockLabel = new Label();
            productDescriptionLabel = new Label();
            priceTextBox = new TextBox();
            publishedAtTextBox = new TextBox();
            stockTextBox = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            categoryComboBox = new ComboBox();
            doneButton = new Button();
            productImageButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
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
            // stockLabel
            // 
            resources.ApplyResources(stockLabel, "stockLabel");
            stockLabel.ForeColor = Color.FromArgb(241, 250, 238);
            stockLabel.Name = "stockLabel";
            // 
            // productDescriptionLabel
            // 
            productDescriptionLabel.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(productDescriptionLabel, "productDescriptionLabel");
            productDescriptionLabel.ForeColor = Color.FromArgb(241, 250, 238);
            productDescriptionLabel.Name = "productDescriptionLabel";
            // 
            // priceTextBox
            // 
            priceTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(priceTextBox, "priceTextBox");
            priceTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.ReadOnly = true;
            priceTextBox.TabStop = false;
            // 
            // publishedAtTextBox
            // 
            publishedAtTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(publishedAtTextBox, "publishedAtTextBox");
            publishedAtTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            publishedAtTextBox.Name = "publishedAtTextBox";
            publishedAtTextBox.ReadOnly = true;
            publishedAtTextBox.TabStop = false;
            // 
            // stockTextBox
            // 
            stockTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(stockTextBox, "stockTextBox");
            stockTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.ReadOnly = true;
            stockTextBox.TabStop = false;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(textBox4, "textBox4");
            textBox4.ForeColor = Color.FromArgb(241, 250, 238);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(241, 250, 238);
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.FromArgb(241, 250, 238);
            label2.Name = "label2";
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            resources.ApplyResources(categoryComboBox, "categoryComboBox");
            categoryComboBox.Name = "categoryComboBox";
            // 
            // doneButton
            // 
            resources.ApplyResources(doneButton, "doneButton");
            doneButton.ForeColor = Color.FromArgb(241, 250, 238);
            doneButton.Name = "doneButton";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += loginButton_Click;
            // 
            // productImageButton
            // 
            productImageButton.BackgroundImage = Properties.Resources.cart;
            resources.ApplyResources(productImageButton, "productImageButton");
            productImageButton.ForeColor = Color.FromArgb(241, 250, 238);
            productImageButton.Name = "productImageButton";
            productImageButton.UseVisualStyleBackColor = true;
            // 
            // AddProduct
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(doneButton);
            Controls.Add(categoryComboBox);
            Controls.Add(label2);
            Controls.Add(textBox4);
            Controls.Add(label1);
            Controls.Add(stockTextBox);
            Controls.Add(publishedAtTextBox);
            Controls.Add(priceTextBox);
            Controls.Add(productDescriptionLabel);
            Controls.Add(stockLabel);
            Controls.Add(publishedAtLabel);
            Controls.Add(priceLabel);
            Controls.Add(productImageButton);
            Controls.Add(titleLabel);
            Name = "AddProduct";
            Load += ProductAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label priceLabel;
        private Label publishedAtLabel;
        private Label stockLabel;
        private Label productDescriptionLabel;
        private TextBox priceTextBox;
        private TextBox publishedAtTextBox;
        private TextBox stockTextBox;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private ComboBox categoryComboBox;
        private Button doneButton;
        private Button productImageButton;
    }
}
