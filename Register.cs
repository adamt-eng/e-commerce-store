using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Register : Form
{
    internal Register() => InitializeComponent();
    internal bool RegisterAsAdmin;
    private void registerButton_Click(object sender, EventArgs e)
    {
        var firstName = firstNameTextBox.Text.Trim();
        var lastName = lastNameTextBox.Text.Trim();
        var dateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        var email = emailTextBox.Text.Trim();
        var password = passwordTextBox.Text.Trim();
        var phoneNumber = phoneNumberTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(phoneNumber))
        {
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var query = string.Empty;
            query = RegisterAsAdmin ? $"""

                                       INSERT INTO Admin (Admin_Name, Admin_Email, Pass_Hashed, Phone_Number)
                                       VALUES ({$"{firstName} {lastName}"}, '{email}', '{password}', '{phoneNumber}');
                                       
                                                   
                                       """ : $"""
                                              
                                                              INSERT INTO Customer (First_Name, Last_Name, Date_Of_Birth, Email, Pass_Hashed, Phone_Number)
                                                              VALUES ('{firstName}', '{lastName}', '{dateOfBirth}', '{email}', '{password}', '{phoneNumber}')
                                                          
                                              """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Hide();
            Program.LoginFormInstance.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Registration failed. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
