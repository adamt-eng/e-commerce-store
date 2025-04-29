using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
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
            dataGridView1 = new DataGridView();
            DeleteButton = new Button();
            AddButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            // DeleteButton
            // 
            resources.ApplyResources(DeleteButton, "DeleteButton");
            DeleteButton.ForeColor = Color.FromArgb(241, 250, 238);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click_1;
            // 
            // AddButton
            // 
            resources.ApplyResources(AddButton, "AddButton");
            AddButton.ForeColor = Color.FromArgb(241, 250, 238);
            AddButton.Name = "AddButton";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click_1;
            // 
            // SellerPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(dataGridView1);
            Controls.Add(titleLabel);
            MaximizeBox = false;
            Name = "SellerPage";
            Load += SellerPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label titleLabel;
        private DataGridView dataGridView1;
        private Button DeleteButton;
        private Button AddButton;
    }
}
