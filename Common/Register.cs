using System;
using System.Windows.Forms;

namespace E_Commerce_Store.Common;

internal partial class Register : Form
{
    internal Register() => InitializeComponent();
    internal bool RegisterAsAdmin;

    private void RegisterButton_Click(object sender, EventArgs e)
    {
        var firstName = firstNameTextBox.Text.Trim();
        var lastName = lastNameTextBox.Text.Trim();
        var dateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        var email = emailTextBox.Text.Trim();
        var password = passwordTextBox.Text.Trim();
        var phoneNumber = phoneNumberTextBox.Text.Trim();
        var address = addressTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Please fill in all fields.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (userTypeComboBox.SelectedIndex == 1 && string.IsNullOrWhiteSpace(address))
        {
            MessageBox.Show("Please fill in address field.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!Validation.IsValidEmail(email))
        {
            MessageBox.Show("Invalid email.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!Validation.IsValidPhoneNumber(phoneNumber))
        {
            MessageBox.Show("Invalid phone number.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        password = PasswordHasher.Hash(password);

        try
        {
            string query;

            if (RegisterAsAdmin)
            {
                query = $"""

                         INSERT INTO Admin (Admin_Name, Admin_Email, Pass_Hashed, Phone_Number)
                         VALUES ({$"{firstName} {lastName}"}, '{email}', '{password}', '{phoneNumber}');
                         
                                     
                         """;
            }
            else
            {
                query = userTypeComboBox.SelectedIndex == 0 ? $"""
                                                               
                                                                               INSERT INTO Customer (First_Name, Last_Name, Date_Of_Birth, Email, Pass_Hashed, Phone_Number)
                                                                               VALUES ('{firstName}', '{lastName}', '{dateOfBirth}', '{email}', '{password}', '{phoneNumber}')
                                                                           
                                                               """ : $"""
                                                                      
                                                                          INSERT INTO Seller (Seller_Name, Seller_Email, Pass_Hashed, Phone_Number, Seller_Address)
                                                                          VALUES ('{firstName} {lastName}', '{email}', '{password}', '{phoneNumber}', '{addressTextBox.Text.Trim()}')

                                                                      """;
            }


            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Registration successful! You can now log in.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Registration failed. Error: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Register_Load(object sender, EventArgs e) => userTypeComboBox.SelectedIndex = 0;

    private void UserTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (userTypeComboBox.SelectedIndex == 0)
        {
            // Show the date of birth field and hide the address field
            dateTimePicker1.Visible = true;
            dateOfBirthLabel.Visible = true;
            addressTextBox.Visible = false;
            label1.Visible = false;
        }
        else
        {
            // Show the address text field and hide the date of birth field
            dateTimePicker1.Visible = false;
            dateOfBirthLabel.Visible = false;
            addressTextBox.Visible = true;
            label1.Visible = true;
        }
    }

    private void Register_FormClosing(object sender, FormClosingEventArgs e) => Program.LoginFormInstance.Show();
}