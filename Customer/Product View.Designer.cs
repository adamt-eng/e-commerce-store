using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
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
            inCartNumericUpDown = new NumericUpDown();
            cartLabel = new Label();
            priceLabel = new Label();
            publishedAtLabel = new Label();
            stockLabel = new Label();
            productDescriptionLabel = new Label();
            sellerLabel = new Label();
            productPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)inCartNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productPictureBox).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // inCartNumericUpDown
            // 
            resources.ApplyResources(inCartNumericUpDown, "inCartNumericUpDown");
            inCartNumericUpDown.Name = "inCartNumericUpDown";
            inCartNumericUpDown.ValueChanged += inCartNumericUpDown_ValueChanged;
            // 
            // cartLabel
            // 
            resources.ApplyResources(cartLabel, "cartLabel");
            cartLabel.ForeColor = Color.FromArgb(241, 250, 238);
            cartLabel.Name = "cartLabel";
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
            // sellerLabel
            // 
            resources.ApplyResources(sellerLabel, "sellerLabel");
            sellerLabel.ForeColor = Color.FromArgb(241, 250, 238);
            sellerLabel.Name = "sellerLabel";
            // 
            // productPictureBox
            // 
            productPictureBox.BackgroundImage = Properties.Resources.cart;
            resources.ApplyResources(productPictureBox, "productPictureBox");
            productPictureBox.BorderStyle = BorderStyle.FixedSingle;
            productPictureBox.Name = "productPictureBox";
            productPictureBox.TabStop = false;
            // 
            // ProductView
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(productPictureBox);
            Controls.Add(sellerLabel);
            Controls.Add(productDescriptionLabel);
            Controls.Add(stockLabel);
            Controls.Add(publishedAtLabel);
            Controls.Add(priceLabel);
            Controls.Add(inCartNumericUpDown);
            Controls.Add(titleLabel);
            Controls.Add(cartLabel);
            MaximizeBox = false;
            Name = "ProductView";
            Load += ProductView_Load;
            ((System.ComponentModel.ISupportInitialize)inCartNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)productPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label titleLabel;
        private NumericUpDown inCartNumericUpDown;
        private Label cartLabel;
        private Label priceLabel;
        private Label publishedAtLabel;
        private Label stockLabel;
        private Label productDescriptionLabel;
        private Label sellerLabel;
        private PictureBox productPictureBox;
    }
}
