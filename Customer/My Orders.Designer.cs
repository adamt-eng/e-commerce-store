using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
{
    partial class MyOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyOrders));
            ordersGridView = new DataGridView();
            detailsGridView = new DataGridView();
            selectOrderLabel = new Label();
            orderDetailsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ordersGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detailsGridView).BeginInit();
            SuspendLayout();
            // 
            // ordersGridView
            // 
            ordersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(ordersGridView, "ordersGridView");
            ordersGridView.Name = "ordersGridView";
            ordersGridView.ReadOnly = true;
            // 
            // detailsGridView
            // 
            detailsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(detailsGridView, "detailsGridView");
            detailsGridView.Name = "detailsGridView";
            detailsGridView.ReadOnly = true;
            // 
            // selectOrderLabel
            // 
            resources.ApplyResources(selectOrderLabel, "selectOrderLabel");
            selectOrderLabel.ForeColor = Color.FromArgb(241, 250, 238);
            selectOrderLabel.Name = "selectOrderLabel";
            // 
            // orderDetailsLabel
            // 
            resources.ApplyResources(orderDetailsLabel, "orderDetailsLabel");
            orderDetailsLabel.ForeColor = Color.FromArgb(241, 250, 238);
            orderDetailsLabel.Name = "orderDetailsLabel";
            // 
            // MyOrders
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(orderDetailsLabel);
            Controls.Add(selectOrderLabel);
            Controls.Add(detailsGridView);
            Controls.Add(ordersGridView);
            MaximizeBox = false;
            Name = "MyOrders";
            Load += MyOrders_Load;
            ((System.ComponentModel.ISupportInitialize)ordersGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)detailsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView ordersGridView;
        private DataGridView detailsGridView;
        private Label selectOrderLabel;
        private Label orderDetailsLabel;
    }
}
