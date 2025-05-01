using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
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
            productsDataGridView = new DataGridView();
            myProfileButton = new Button();
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
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
            // productsDataGridView
            // 
            productsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(productsDataGridView, "productsDataGridView");
            productsDataGridView.Name = "productsDataGridView";
            productsDataGridView.ReadOnly = true;
            productsDataGridView.CellDoubleClick += ProductsDataGridView_CellDoubleClick;
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
            // CustomerPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(myProfileButton);
            Controls.Add(productsDataGridView);
            Controls.Add(titleLabel);
            Controls.Add(cartButton);
            Controls.Add(searchForProductsTextBox);
            MaximizeBox = false;
            Name = "CustomerPage";
            FormClosed += CustomerPage_FormClosed;
            Load += CustomerPage_Load;
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchForProductsTextBox;
        private Button cartButton;
        private Label titleLabel;
        private DataGridView productsDataGridView;
        private Button myProfileButton;
    }
}
