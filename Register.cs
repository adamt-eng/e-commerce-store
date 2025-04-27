using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Register : Form
{
    internal Register() => InitializeComponent();

    private void Register_Load(object sender, EventArgs e)
    {

    }

    private void searchForProductsTextBox_TextChanged(object sender, EventArgs e)
    {
        // No need to implement anything here for the Register form
    }

    private void registerButton_Click(object sender, EventArgs e)
    {
        // Get the entered values
        var firstName = firstNameTextBox.Text.Trim();
        var lastName = lastNameTextBox.Text.Trim();
        var dateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        var email = emailTextBox.Text.Trim();
        var password = passwordTextBox.Text.Trim(); // Ideally should hash password before saving
        var phoneNumber = phoneNumberTextBox.Text.Trim();

        // Check if all fields are filled
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
            // Insert into the database
            var query = $"""
                         
                                         INSERT INTO Customer (FirstName, LastName, DateOfBirth, Email, Pass_Hashed, PhoneNumber)
                                         VALUES ('{firstName}', '{lastName}', '{dateOfBirth}', '{email}', '{password}', '{phoneNumber}')
                                     
                         """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // After successful registration, redirect back to Login
            Hide();
            new Login().ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Registration failed. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
