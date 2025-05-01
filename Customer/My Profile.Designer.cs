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
            phoneNumberLabel = new Label();
            phoneNumberTextBox = new TextBox();
            nameLabel = new Label();
            dateOfBirthLabel = new Label();
            dobDateTimePicker = new DateTimePicker();
            lastNameTextBox = new TextBox();
            firstNameTextBox = new TextBox();
            enableEditingCheckBox = new CheckBox();
            addressesGroupBox = new GroupBox();
            deleteAddressLabel = new Label();
            addAddressLabel = new Label();
            addressListBox = new ListBox();
            paymentMethodGroupBox = new GroupBox();
            deletePaymentLabel = new Label();
            paymentMethodsListBox = new ListBox();
            addPaymentLabel = new Label();
            myOrdersButton = new Button();
            changePasswordButton = new Button();
            addressesGroupBox.SuspendLayout();
            paymentMethodGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.ForeColor = Color.FromArgb(241, 250, 238);
            saveButton.Name = "saveButton";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
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
            enableEditingCheckBox.CheckedChanged += EnableEditingCheckBox_CheckedChanged;
            // 
            // addressesGroupBox
            // 
            addressesGroupBox.Controls.Add(deleteAddressLabel);
            addressesGroupBox.Controls.Add(addAddressLabel);
            addressesGroupBox.Controls.Add(addressListBox);
            addressesGroupBox.ForeColor = Color.White;
            resources.ApplyResources(addressesGroupBox, "addressesGroupBox");
            addressesGroupBox.Name = "addressesGroupBox";
            addressesGroupBox.TabStop = false;
            // 
            // deleteAddressLabel
            // 
            deleteAddressLabel.Cursor = Cursors.Hand;
            resources.ApplyResources(deleteAddressLabel, "deleteAddressLabel");
            deleteAddressLabel.ForeColor = Color.FromArgb(241, 250, 238);
            deleteAddressLabel.Name = "deleteAddressLabel";
            deleteAddressLabel.Click += DeleteAddressLabel_Click;
            // 
            // addAddressLabel
            // 
            addAddressLabel.Cursor = Cursors.Hand;
            resources.ApplyResources(addAddressLabel, "addAddressLabel");
            addAddressLabel.ForeColor = Color.FromArgb(241, 250, 238);
            addAddressLabel.Name = "addAddressLabel";
            addAddressLabel.Click += AddAddressLabel_Click;
            // 
            // addressListBox
            // 
            addressListBox.FormattingEnabled = true;
            resources.ApplyResources(addressListBox, "addressListBox");
            addressListBox.Name = "addressListBox";
            // 
            // paymentMethodGroupBox
            // 
            paymentMethodGroupBox.Controls.Add(deletePaymentLabel);
            paymentMethodGroupBox.Controls.Add(paymentMethodsListBox);
            paymentMethodGroupBox.Controls.Add(addPaymentLabel);
            paymentMethodGroupBox.ForeColor = Color.White;
            resources.ApplyResources(paymentMethodGroupBox, "paymentMethodGroupBox");
            paymentMethodGroupBox.Name = "paymentMethodGroupBox";
            paymentMethodGroupBox.TabStop = false;
            // 
            // deletePaymentLabel
            // 
            deletePaymentLabel.Cursor = Cursors.Hand;
            resources.ApplyResources(deletePaymentLabel, "deletePaymentLabel");
            deletePaymentLabel.ForeColor = Color.FromArgb(241, 250, 238);
            deletePaymentLabel.Name = "deletePaymentLabel";
            deletePaymentLabel.Click += DeletePaymentLabel_Click;
            // 
            // paymentMethodsListBox
            // 
            paymentMethodsListBox.FormattingEnabled = true;
            resources.ApplyResources(paymentMethodsListBox, "paymentMethodsListBox");
            paymentMethodsListBox.Name = "paymentMethodsListBox";
            // 
            // addPaymentLabel
            // 
            addPaymentLabel.Cursor = Cursors.Hand;
            resources.ApplyResources(addPaymentLabel, "addPaymentLabel");
            addPaymentLabel.ForeColor = Color.FromArgb(241, 250, 238);
            addPaymentLabel.Name = "addPaymentLabel";
            addPaymentLabel.Click += AddPaymentLabel_Click;
            // 
            // myOrdersButton
            // 
            resources.ApplyResources(myOrdersButton, "myOrdersButton");
            myOrdersButton.ForeColor = Color.FromArgb(241, 250, 238);
            myOrdersButton.Name = "myOrdersButton";
            myOrdersButton.UseVisualStyleBackColor = true;
            myOrdersButton.Click += ShowPreviousOrdersButton_Click;
            // 
            // changePasswordButton
            // 
            resources.ApplyResources(changePasswordButton, "changePasswordButton");
            changePasswordButton.ForeColor = Color.FromArgb(241, 250, 238);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.UseVisualStyleBackColor = true;
            changePasswordButton.Click += ChangePasswordButton_Click;
            // 
            // MyProfile
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 53, 87);
            Controls.Add(changePasswordButton);
            Controls.Add(myOrdersButton);
            Controls.Add(paymentMethodGroupBox);
            Controls.Add(addressesGroupBox);
            Controls.Add(enableEditingCheckBox);
            Controls.Add(saveButton);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(nameLabel);
            Controls.Add(dateOfBirthLabel);
            Controls.Add(dobDateTimePicker);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            MaximizeBox = false;
            Name = "MyProfile";
            Load += MyProfile_Load;
            addressesGroupBox.ResumeLayout(false);
            paymentMethodGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button saveButton;
        private Label phoneNumberLabel;
        private TextBox phoneNumberTextBox;
        private Label nameLabel;
        private Label dateOfBirthLabel;
        private DateTimePicker dobDateTimePicker;
        private TextBox lastNameTextBox;
        private TextBox firstNameTextBox;
        private CheckBox enableEditingCheckBox;
        private GroupBox addressesGroupBox;
        private GroupBox paymentMethodGroupBox;
        private ListBox paymentMethodsListBox;
        private ListBox addressListBox;
        private Button myOrdersButton;
        private Label addAddressLabel;
        private Label deleteAddressLabel;
        private Label deletePaymentLabel;
        private Label addPaymentLabel;
        private Button changePasswordButton;
    }
}
