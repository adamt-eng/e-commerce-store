using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Admin
{
    partial class AddCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCategory));
            titleLabel = new Label();
            publishedAtLabel = new Label();
            productDescriptionLabel = new Label();
            descriptionTextBox = new TextBox();
            nameTextBox = new TextBox();
            label1 = new Label();
            doneButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // publishedAtLabel
            // 
            resources.ApplyResources(publishedAtLabel, "publishedAtLabel");
            publishedAtLabel.ForeColor = Color.FromArgb(241, 250, 238);
            publishedAtLabel.Name = "publishedAtLabel";
            // 
            // productDescriptionLabel
            // 
            productDescriptionLabel.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(productDescriptionLabel, "productDescriptionLabel");
            productDescriptionLabel.ForeColor = Color.FromArgb(241, 250, 238);
            productDescriptionLabel.Name = "productDescriptionLabel";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(descriptionTextBox, "descriptionTextBox");
            descriptionTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.TabStop = false;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(nameTextBox, "nameTextBox");
            nameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(241, 250, 238);
            label1.Name = "label1";
            // 
            // doneButton
            // 
            resources.ApplyResources(doneButton, "doneButton");
            doneButton.ForeColor = Color.FromArgb(241, 250, 238);
            doneButton.Name = "doneButton";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += DoneButton_Click;
            // 
            // AddCategory
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(doneButton);
            Controls.Add(nameTextBox);
            Controls.Add(label1);
            Controls.Add(descriptionTextBox);
            Controls.Add(productDescriptionLabel);
            Controls.Add(publishedAtLabel);
            Controls.Add(titleLabel);
            MaximizeBox = false;
            Name = "AddCategory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label publishedAtLabel;
        private Label productDescriptionLabel;
        private TextBox descriptionTextBox;
        private TextBox nameTextBox;
        private Label label1;
        private Button doneButton;
    }
}
