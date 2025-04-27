using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateOfBirthLabel = new Label();
            nameLabel = new Label();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            phoneNumberLabel = new Label();
            phoneNumberTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            registerButton = new Button();
            SuspendLayout();
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(firstNameTextBox, "firstNameTextBox");
            firstNameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.TabStop = false;
            firstNameTextBox.TextChanged += searchForProductsTextBox_TextChanged;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(lastNameTextBox, "lastNameTextBox");
            lastNameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.TabStop = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            resources.ApplyResources(dateTimePicker1, "dateTimePicker1");
            dateTimePicker1.Name = "dateTimePicker1";
            // 
            // dateOfBirthLabel
            // 
            resources.ApplyResources(dateOfBirthLabel, "dateOfBirthLabel");
            dateOfBirthLabel.ForeColor = Color.FromArgb(241, 250, 238);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            // 
            // nameLabel
            // 
            resources.ApplyResources(nameLabel, "nameLabel");
            nameLabel.ForeColor = Color.FromArgb(241, 250, 238);
            nameLabel.Name = "nameLabel";
            // 
            // emailLabel
            // 
            resources.ApplyResources(emailLabel, "emailLabel");
            emailLabel.ForeColor = Color.FromArgb(241, 250, 238);
            emailLabel.Name = "emailLabel";
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(emailTextBox, "emailTextBox");
            emailTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.TabStop = false;
            // 
            // phoneNumberLabel
            // 
            resources.ApplyResources(phoneNumberLabel, "phoneNumberLabel");
            phoneNumberLabel.ForeColor = Color.FromArgb(241, 250, 238);
            phoneNumberLabel.Name = "phoneNumberLabel";
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(phoneNumberTextBox, "phoneNumberTextBox");
            phoneNumberTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.TabStop = false;
            // 
            // passwordLabel
            // 
            resources.ApplyResources(passwordLabel, "passwordLabel");
            passwordLabel.ForeColor = Color.FromArgb(241, 250, 238);
            passwordLabel.Name = "passwordLabel";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(passwordTextBox, "passwordTextBox");
            passwordTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.TabStop = false;
            // 
            // registerButton
            // 
            resources.ApplyResources(registerButton, "registerButton");
            registerButton.ForeColor = Color.FromArgb(241, 250, 238);
            registerButton.Name = "registerButton";
            registerButton.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(registerButton);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(nameLabel);
            Controls.Add(dateOfBirthLabel);
            Controls.Add(dateTimePicker1);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            MaximizeBox = false;
            Name = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private DateTimePicker dateTimePicker1;
        private Label dateOfBirthLabel;
        private Label nameLabel;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label phoneNumberLabel;
        private TextBox phoneNumberTextBox;
        private Label passwordLabel;
        private Button registerButton;
    }
}
