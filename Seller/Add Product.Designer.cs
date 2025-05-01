using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Seller
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            titleLabel = new Label();
            priceLabel = new Label();
            stockLabel = new Label();
            priceTextBox = new TextBox();
            stockTextBox = new TextBox();
            imageLinkTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            categoryComboBox = new ComboBox();
            doneButton = new Button();
            nameTextBox = new TextBox();
            label3 = new Label();
            categoryDescriptionlabel = new Label();
            label5 = new Label();
            descriptionTextBox = new TextBox();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // priceLabel
            // 
            resources.ApplyResources(priceLabel, "priceLabel");
            priceLabel.ForeColor = Color.FromArgb(241, 250, 238);
            priceLabel.Name = "priceLabel";
            // 
            // stockLabel
            // 
            resources.ApplyResources(stockLabel, "stockLabel");
            stockLabel.ForeColor = Color.FromArgb(241, 250, 238);
            stockLabel.Name = "stockLabel";
            // 
            // priceTextBox
            // 
            priceTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(priceTextBox, "priceTextBox");
            priceTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.ReadOnly = true;
            priceTextBox.TabStop = false;
            // 
            // stockTextBox
            // 
            stockTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(stockTextBox, "stockTextBox");
            stockTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.ReadOnly = true;
            stockTextBox.TabStop = false;
            // 
            // imageLinkTextBox
            // 
            imageLinkTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(imageLinkTextBox, "imageLinkTextBox");
            imageLinkTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            imageLinkTextBox.Name = "imageLinkTextBox";
            imageLinkTextBox.ReadOnly = true;
            imageLinkTextBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(241, 250, 238);
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.FromArgb(241, 250, 238);
            label2.Name = "label2";
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            resources.ApplyResources(categoryComboBox, "categoryComboBox");
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;
            // 
            // doneButton
            // 
            resources.ApplyResources(doneButton, "doneButton");
            doneButton.ForeColor = Color.FromArgb(241, 250, 238);
            doneButton.Name = "doneButton";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += LoginButton_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(nameTextBox, "nameTextBox");
            nameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.ReadOnly = true;
            nameTextBox.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.FromArgb(241, 250, 238);
            label3.Name = "label3";
            // 
            // categoryDescriptionlabel
            // 
            resources.ApplyResources(categoryDescriptionlabel, "categoryDescriptionlabel");
            categoryDescriptionlabel.ForeColor = Color.FromArgb(241, 250, 238);
            categoryDescriptionlabel.Name = "categoryDescriptionlabel";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = Color.FromArgb(241, 250, 238);
            label5.Name = "label5";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(descriptionTextBox, "descriptionTextBox");
            descriptionTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.TabStop = false;
            // 
            // AddProduct
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(label5);
            Controls.Add(descriptionTextBox);
            Controls.Add(categoryDescriptionlabel);
            Controls.Add(nameTextBox);
            Controls.Add(label3);
            Controls.Add(doneButton);
            Controls.Add(categoryComboBox);
            Controls.Add(label2);
            Controls.Add(imageLinkTextBox);
            Controls.Add(label1);
            Controls.Add(stockTextBox);
            Controls.Add(priceTextBox);
            Controls.Add(stockLabel);
            Controls.Add(priceLabel);
            Controls.Add(titleLabel);
            MaximizeBox = false;
            Name = "AddProduct";
            Load += ProductAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label priceLabel;
        private Label stockLabel;
        private TextBox priceTextBox;
        private TextBox stockTextBox;
        private TextBox imageLinkTextBox;
        private Label label1;
        private Label label2;
        private ComboBox categoryComboBox;
        private Button doneButton;
        private TextBox nameTextBox;
        private Label label3;
        private Label categoryDescriptionlabel;
        private Label label5;
        private TextBox descriptionTextBox;
    }
}
