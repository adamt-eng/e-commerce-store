using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store
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
            PlaceOrderButton = new Button();
            TotalLabel = new Label();
            TotalPriceTextBox = new TextBox();
            PaymentMethodComboBox = new ComboBox();
            ChoosePaymentMethodLabel = new Label();
            ChooseShippingAddressLabel = new Label();
            ShippingAddressComboBox = new ComboBox();
            SuspendLayout();
            // 
            // PlaceOrderButton
            // 
            resources.ApplyResources(PlaceOrderButton, "PlaceOrderButton");
            PlaceOrderButton.ForeColor = Color.FromArgb(241, 250, 238);
            PlaceOrderButton.Name = "PlaceOrderButton";
            PlaceOrderButton.UseVisualStyleBackColor = true;
            PlaceOrderButton.Click += PlaceOrderButton_Click;
            // 
            // TotalLabel
            // 
            resources.ApplyResources(TotalLabel, "TotalLabel");
            TotalLabel.ForeColor = Color.FromArgb(241, 250, 238);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Click += nameLabel_Click;
            // 
            // TotalPriceTextBox
            // 
            TotalPriceTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(TotalPriceTextBox, "TotalPriceTextBox");
            TotalPriceTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            TotalPriceTextBox.Name = "TotalPriceTextBox";
            TotalPriceTextBox.ReadOnly = true;
            TotalPriceTextBox.TabStop = false;
            TotalPriceTextBox.TextChanged += textBox1_TextChanged;
            // 
            // PaymentMethodComboBox
            // 
            PaymentMethodComboBox.FormattingEnabled = true;
            resources.ApplyResources(PaymentMethodComboBox, "PaymentMethodComboBox");
            PaymentMethodComboBox.Name = "PaymentMethodComboBox";
            // 
            // ChoosePaymentMethodLabel
            // 
            resources.ApplyResources(ChoosePaymentMethodLabel, "ChoosePaymentMethodLabel");
            ChoosePaymentMethodLabel.ForeColor = Color.FromArgb(241, 250, 238);
            ChoosePaymentMethodLabel.Name = "ChoosePaymentMethodLabel";
            // 
            // ChooseShippingAddressLabel
            // 
            resources.ApplyResources(ChooseShippingAddressLabel, "ChooseShippingAddressLabel");
            ChooseShippingAddressLabel.ForeColor = Color.FromArgb(241, 250, 238);
            ChooseShippingAddressLabel.Name = "ChooseShippingAddressLabel";
            ChooseShippingAddressLabel.Click += label1_Click;
            // 
            // ShippingAddressComboBox
            // 
            ShippingAddressComboBox.FormattingEnabled = true;
            resources.ApplyResources(ShippingAddressComboBox, "ShippingAddressComboBox");
            ShippingAddressComboBox.Name = "ShippingAddressComboBox";
            // 
            // Checkout
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(ShippingAddressComboBox);
            Controls.Add(ChooseShippingAddressLabel);
            Controls.Add(ChoosePaymentMethodLabel);
            Controls.Add(PaymentMethodComboBox);
            Controls.Add(TotalPriceTextBox);
            Controls.Add(PlaceOrderButton);
            Controls.Add(TotalLabel);
            MaximizeBox = false;
            Name = "Checkout";
            Load += MyProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button PlaceOrderButton;
        private Label TotalLabel;
        private TextBox TotalPriceTextBox;
        private ComboBox PaymentMethodComboBox;
        private Label ChoosePaymentMethodLabel;
        private Label ChooseShippingAddressLabel;
        private ComboBox ShippingAddressComboBox;
    }
}
