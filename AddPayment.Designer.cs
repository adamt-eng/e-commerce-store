using System.Drawing;
using System.Windows.Forms;
using System;

namespace E_Commerce_Store
{
    partial class AddPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPayment));
            titleLabel = new Label();
            cardNumberTextBox = new TextBox();
            cardholderNameTextBox = new TextBox();
            expiryDatePicker = new DateTimePicker();
            doneButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.ForeColor = Color.FromArgb(241, 250, 238);
            titleLabel.Name = "titleLabel";
            // 
            // cardNumberTextBox
            // 
            cardNumberTextBox.BackColor = Color.FromArgb(49, 73, 107);
            cardNumberTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            resources.ApplyResources(cardNumberTextBox, "cardNumberTextBox");
            cardNumberTextBox.Name = "cardNumberTextBox";
            // 
            // cardholderNameTextBox
            // 
            cardholderNameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            cardholderNameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            resources.ApplyResources(cardholderNameTextBox, "cardholderNameTextBox");
            cardholderNameTextBox.Name = "cardholderNameTextBox";
            // 
            // expiryDatePicker
            // 
            resources.ApplyResources(expiryDatePicker, "expiryDatePicker");
            expiryDatePicker.Format = DateTimePickerFormat.Custom;
            expiryDatePicker.Name = "expiryDatePicker";
            // 
            // doneButton
            // 
            resources.ApplyResources(doneButton, "doneButton");
            doneButton.ForeColor = Color.FromArgb(241, 250, 238);
            doneButton.Name = "doneButton";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // AddPayment
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(doneButton);
            Controls.Add(expiryDatePicker);
            Controls.Add(cardholderNameTextBox);
            Controls.Add(cardNumberTextBox);
            Controls.Add(titleLabel);
            Name = "AddPayment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private TextBox cardNumberTextBox;
        private TextBox cardholderNameTextBox;
        private DateTimePicker expiryDatePicker;
        private Button doneButton;
    }
}
