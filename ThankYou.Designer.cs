using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store
{
    partial class ThankYou
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThankYou));
            OrderPlacedLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // OrderPlacedLabel
            // 
            resources.ApplyResources(OrderPlacedLabel, "OrderPlacedLabel");
            OrderPlacedLabel.Name = "OrderPlacedLabel";
            OrderPlacedLabel.Click += OrderPlacedLabel_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // ThankYou
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(label1);
            Controls.Add(OrderPlacedLabel);
            MaximizeBox = false;
            Name = "ThankYou";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label OrderPlacedLabel;
        private Label label1;
    }
}
