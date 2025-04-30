using System.Drawing;
using System.Windows.Forms;

namespace E_Commerce_Store.Customer
{
    partial class MyProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyProfile));
            saveButton = new Button();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            phoneNumberLabel = new Label();
            phoneNumberTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            nameLabel = new Label();
            dateOfBirthLabel = new Label();
            dobDateTimePicker = new DateTimePicker();
            lastNameTextBox = new TextBox();
            firstNameTextBox = new TextBox();
            enableEditingCheckBox = new CheckBox();
            label1 = new Label();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            addressListBox = new ListBox();
            groupBox2 = new GroupBox();
            paymentMethodsListBox = new ListBox();
            showPreviousOrdersButton = new Button();
            deleteInPaymentButton = new Button();
            deleteInAddressButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.ForeColor = Color.FromArgb(241, 250, 238);
            saveButton.Name = "saveButton";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
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
            passwordTextBox.ReadOnly = true;
            passwordTextBox.TabStop = false;
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
            phoneNumberTextBox.ReadOnly = true;
            phoneNumberTextBox.TabStop = false;
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
            emailTextBox.ReadOnly = true;
            emailTextBox.TabStop = false;
            // 
            // nameLabel
            // 
            resources.ApplyResources(nameLabel, "nameLabel");
            nameLabel.ForeColor = Color.FromArgb(241, 250, 238);
            nameLabel.Name = "nameLabel";
            // 
            // dateOfBirthLabel
            // 
            resources.ApplyResources(dateOfBirthLabel, "dateOfBirthLabel");
            dateOfBirthLabel.ForeColor = Color.FromArgb(241, 250, 238);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            // 
            // dobDateTimePicker
            // 
            resources.ApplyResources(dobDateTimePicker, "dobDateTimePicker");
            dobDateTimePicker.Format = DateTimePickerFormat.Short;
            dobDateTimePicker.Name = "dobDateTimePicker";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(lastNameTextBox, "lastNameTextBox");
            lastNameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.ReadOnly = true;
            lastNameTextBox.TabStop = false;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(firstNameTextBox, "firstNameTextBox");
            firstNameTextBox.ForeColor = Color.FromArgb(241, 250, 238);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.ReadOnly = true;
            firstNameTextBox.TabStop = false;
            // 
            // enableEditingCheckBox
            // 
            enableEditingCheckBox.ForeColor = Color.White;
            resources.ApplyResources(enableEditingCheckBox, "enableEditingCheckBox");
            enableEditingCheckBox.Name = "enableEditingCheckBox";
            enableEditingCheckBox.UseVisualStyleBackColor = true;
            enableEditingCheckBox.CheckedChanged += enableEditingCheckBox_CheckedChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(241, 250, 238);
            label1.Name = "label1";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(49, 73, 107);
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.ForeColor = Color.FromArgb(241, 250, 238);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(addressListBox);
            groupBox1.ForeColor = Color.White;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // addressListBox
            // 
            addressListBox.FormattingEnabled = true;
            resources.ApplyResources(addressListBox, "addressListBox");
            addressListBox.Name = "addressListBox";
            addressListBox.DoubleClick += addressListBox_DoubleClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(paymentMethodsListBox);
            groupBox2.ForeColor = Color.White;
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // paymentMethodsListBox
            // 
            paymentMethodsListBox.FormattingEnabled = true;
            resources.ApplyResources(paymentMethodsListBox, "paymentMethodsListBox");
            paymentMethodsListBox.Name = "paymentMethodsListBox";
            paymentMethodsListBox.DoubleClick += paymentMethodsListBox_DoubleClick;
            // 
            // showPreviousOrdersButton
            // 
            resources.ApplyResources(showPreviousOrdersButton, "showPreviousOrdersButton");
            showPreviousOrdersButton.ForeColor = Color.FromArgb(241, 250, 238);
            showPreviousOrdersButton.Name = "showPreviousOrdersButton";
            showPreviousOrdersButton.UseVisualStyleBackColor = true;
            showPreviousOrdersButton.Click += showPreviousOrdersButton_Click;
            // 
            // deleteInPaymentButton
            // 
            resources.ApplyResources(deleteInPaymentButton, "deleteInPaymentButton");
            deleteInPaymentButton.ForeColor = Color.FromArgb(241, 250, 238);
            deleteInPaymentButton.Name = "deleteInPaymentButton";
            deleteInPaymentButton.UseVisualStyleBackColor = true;
            deleteInPaymentButton.Click += deleteInPaymentButton_Click;
            // 
            // deleteInAddressButton
            // 
            resources.ApplyResources(deleteInAddressButton, "deleteInAddressButton");
            deleteInAddressButton.ForeColor = Color.FromArgb(241, 250, 238);
            deleteInAddressButton.Name = "deleteInAddressButton";
            deleteInAddressButton.UseVisualStyleBackColor = true;
            deleteInAddressButton.Click += deleteInAddressButton_Click;
            // 
            // MyProfile
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(deleteInAddressButton);
            Controls.Add(deleteInPaymentButton);
            Controls.Add(showPreviousOrdersButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(enableEditingCheckBox);
            Controls.Add(saveButton);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(nameLabel);
            Controls.Add(dateOfBirthLabel);
            Controls.Add(dobDateTimePicker);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            MaximizeBox = false;
            Name = "MyProfile";
            Load += MyProfile_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button saveButton;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Label phoneNumberLabel;
        private TextBox phoneNumberTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label nameLabel;
        private Label dateOfBirthLabel;
        private DateTimePicker dobDateTimePicker;
        private TextBox lastNameTextBox;
        private TextBox firstNameTextBox;
        private CheckBox enableEditingCheckBox;
        private Label label1;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox paymentMethodsListBox;
        private ListBox addressListBox;
        private Button showPreviousOrdersButton;
        private Button deleteInPaymentButton;
        private Button deleteInAddressButton;
    }
}
