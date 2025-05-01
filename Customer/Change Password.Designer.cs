using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            passwordTextBox = new TextBox();
            saveButton = new Button();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(passwordTextBox, "passwordTextBox");
            passwordTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            passwordTextBox.Name = "passwordTextBox";
            // 
            // saveButton
            // 
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.ForeColor = Color.FromArgb(241, 250, 238);
            saveButton.Name = "saveButton";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // ChangePassword
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(saveButton);
            Controls.Add(passwordTextBox);
            MaximizeBox = false;
            Name = "ChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox passwordTextBox;
        private Button saveButton;
    }
}
