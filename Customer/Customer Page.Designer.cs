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
            topPanel = new Panel();
            searchPanel = new Panel();
            topPanel.SuspendLayout();
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
            cartButton.FlatAppearance.BorderSize = 0;
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
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(29, 53, 87);
            topPanel.Controls.Add(searchForProductsTextBox);
            topPanel.Controls.Add(titleLabel);
            topPanel.Controls.Add(myProfileButton);
            topPanel.Controls.Add(cartButton);
            resources.ApplyResources(topPanel, "topPanel");
            topPanel.Name = "topPanel";
            // 
            // searchPanel
            // 
            searchPanel.BackColor = Color.FromArgb(29, 53, 87);
            resources.ApplyResources(searchPanel, "searchPanel");
            searchPanel.Name = "searchPanel";
            searchPanel.Paint += searchPanel_Paint;
            // 
            // CustomerPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(productsFlowLayoutPanel);
            Controls.Add(searchPanel);
            Controls.Add(topPanel);
            MaximizeBox = false;
            Name = "CustomerPage";
            FormClosed += CustomerPage_FormClosed;
            Load += CustomerPage_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion 

        private TextBox searchForProductsTextBox;
        private Button cartButton;
        private Label titleLabel;
        private Button myProfileButton;
        private FlowLayoutPanel productsFlowLayoutPanel;
        private Panel topPanel;
        private Panel searchPanel;
    }
}