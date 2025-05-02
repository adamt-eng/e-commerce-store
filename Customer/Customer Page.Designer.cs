using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
{
    partial class CustomerPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerPage));
            searchForProductsTextBox = new TextBox();
            cartButton = new Button();
            titleLabel = new Label();
            myProfileButton = new Button();
            productsFlowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // searchForProductsTextBox
            // 
            searchForProductsTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(searchForProductsTextBox, "searchForProductsTextBox");
            searchForProductsTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            searchForProductsTextBox.Name = "searchForProductsTextBox";
            searchForProductsTextBox.TabStop = false;
            searchForProductsTextBox.TextChanged += SearchForProductsTextBox_TextChanged;
            // 
            // cartButton
            // 
            cartButton.BackgroundImage = Properties.Resources.cart;
            resources.ApplyResources(cartButton, "cartButton");
            cartButton.ForeColor = Color.FromArgb(241, 250, 238);
            cartButton.Name = "cartButton";
            cartButton.UseVisualStyleBackColor = true;
            cartButton.Click += CartButton_Click;
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // myProfileButton
            // 
            myProfileButton.BackgroundImage = Properties.Resources.account;
            resources.ApplyResources(myProfileButton, "myProfileButton");
            myProfileButton.FlatAppearance.BorderSize = 0;
            myProfileButton.ForeColor = Color.FromArgb(241, 250, 238);
            myProfileButton.Name = "myProfileButton";
            myProfileButton.UseVisualStyleBackColor = true;
            myProfileButton.Click += MyProfileButton_Click;
            // 
            // productsFlowLayoutPanel
            // 
            resources.ApplyResources(productsFlowLayoutPanel, "productsFlowLayoutPanel");
            productsFlowLayoutPanel.BackColor = Color.FromArgb(29, 53, 87);
            productsFlowLayoutPanel.Name = "productsFlowLayoutPanel";
            // 
            // CustomerPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(cartButton);
            Controls.Add(titleLabel);
            Controls.Add(myProfileButton);
            Controls.Add(productsFlowLayoutPanel);
            Controls.Add(searchForProductsTextBox);
            MaximizeBox = false;
            Name = "CustomerPage";
            FormClosed += CustomerPage_FormClosed;
            Load += CustomerPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchForProductsTextBox;
        private Button cartButton;
        private Label titleLabel;
        private Button myProfileButton;
        private FlowLayoutPanel productsFlowLayoutPanel;
    }
}