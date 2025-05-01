using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
{
    partial class Checkout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checkout));
            placeOrderButton = new Button();
            totalPriceLabel = new Label();
            paymentMethodComboBox = new ComboBox();
            choosePaymentMethodLabel = new Label();
            chooseShippingAddressLabel = new Label();
            ShippingAddressComboBox = new ComboBox();
            backButton = new Button();
            SuspendLayout();
            // 
            // placeOrderButton
            // 
            resources.ApplyResources(placeOrderButton, "placeOrderButton");
            placeOrderButton.ForeColor = Color.FromArgb(241, 250, 238);
            placeOrderButton.Name = "placeOrderButton";
            placeOrderButton.UseVisualStyleBackColor = true;
            placeOrderButton.Click += PlaceOrderButton_Click;
            // 
            // totalPriceLabel
            // 
            resources.ApplyResources(totalPriceLabel, "totalPriceLabel");
            totalPriceLabel.ForeColor = Color.FromArgb(241, 250, 238);
            totalPriceLabel.Name = "totalPriceLabel";
            // 
            // paymentMethodComboBox
            // 
            paymentMethodComboBox.FormattingEnabled = true;
            resources.ApplyResources(paymentMethodComboBox, "paymentMethodComboBox");
            paymentMethodComboBox.Name = "paymentMethodComboBox";
            // 
            // choosePaymentMethodLabel
            // 
            resources.ApplyResources(choosePaymentMethodLabel, "choosePaymentMethodLabel");
            choosePaymentMethodLabel.ForeColor = Color.FromArgb(241, 250, 238);
            choosePaymentMethodLabel.Name = "choosePaymentMethodLabel";
            // 
            // chooseShippingAddressLabel
            // 
            resources.ApplyResources(chooseShippingAddressLabel, "chooseShippingAddressLabel");
            chooseShippingAddressLabel.ForeColor = Color.FromArgb(241, 250, 238);
            chooseShippingAddressLabel.Name = "chooseShippingAddressLabel";
            // 
            // ShippingAddressComboBox
            // 
            ShippingAddressComboBox.FormattingEnabled = true;
            resources.ApplyResources(ShippingAddressComboBox, "ShippingAddressComboBox");
            ShippingAddressComboBox.Name = "ShippingAddressComboBox";
            // 
            // backButton
            // 
            resources.ApplyResources(backButton, "backButton");
            backButton.ForeColor = Color.FromArgb(241, 250, 238);
            backButton.Name = "backButton";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += BackButton_Click;
            // 
            // Checkout
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(backButton);
            Controls.Add(ShippingAddressComboBox);
            Controls.Add(chooseShippingAddressLabel);
            Controls.Add(choosePaymentMethodLabel);
            Controls.Add(paymentMethodComboBox);
            Controls.Add(placeOrderButton);
            Controls.Add(totalPriceLabel);
            MaximizeBox = false;
            Name = "Checkout";
            Load += Checkout_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button placeOrderButton;
        private Label totalPriceLabel;
        private ComboBox paymentMethodComboBox;
        private Label choosePaymentMethodLabel;
        private Label chooseShippingAddressLabel;
        private ComboBox ShippingAddressComboBox;
        private Button backButton;
    }
}
