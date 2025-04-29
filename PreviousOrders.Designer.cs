using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
{
    partial class PreviousOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviousOrders));
            titleLabel = new Label();
            ordersGridView = new DataGridView();
            myProfileButton = new Button();
            detailsGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ordersGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detailsGridView).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // ordersGridView
            // 
            ordersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(ordersGridView, "ordersGridView");
            ordersGridView.Name = "ordersGridView";
            // 
            // myProfileButton
            // 
            resources.ApplyResources(myProfileButton, "myProfileButton");
            myProfileButton.FlatAppearance.BorderSize = 0;
            myProfileButton.ForeColor = Color.FromArgb(241, 250, 238);
            myProfileButton.Name = "myProfileButton";
            myProfileButton.UseVisualStyleBackColor = true;
            myProfileButton.Click += myProfileButton_Click;
            // 
            // detailsGridView
            // 
            detailsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(detailsGridView, "detailsGridView");
            detailsGridView.Name = "detailsGridView";
            // 
            // PreviousOrders
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(detailsGridView);
            Controls.Add(myProfileButton);
            Controls.Add(ordersGridView);
            Controls.Add(titleLabel);
            MaximizeBox = false;
            Name = "PreviousOrders";
            Load += PreviousOrders_Load;
            ((System.ComponentModel.ISupportInitialize)ordersGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)detailsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label titleLabel;
        private DataGridView ordersGridView;
        private Button myProfileButton;
        private DataGridView detailsGridView;
    }
}
