using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Seller
{
    partial class SellerPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerPage));
            titleLabel = new Label();
            dataGridView = new DataGridView();
            DeleteButton = new Button();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridView, "dataGridView");
            dataGridView.Name = "dataGridView";
            // 
            // DeleteButton
            // 
            resources.ApplyResources(DeleteButton, "DeleteButton");
            DeleteButton.ForeColor = Color.FromArgb(241, 250, 238);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // addButton
            // 
            resources.ApplyResources(addButton, "addButton");
            addButton.ForeColor = Color.FromArgb(241, 250, 238);
            addButton.Name = "addButton";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // SellerPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(addButton);
            Controls.Add(DeleteButton);
            Controls.Add(dataGridView);
            Controls.Add(titleLabel);
            MaximizeBox = false;
            Name = "SellerPage";
            FormClosed += SellerPage_FormClosed;
            Load += SellerPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label titleLabel;
        private DataGridView dataGridView;
        private Button DeleteButton;
        private Button addButton;
    }
}
