using System;
using System.Net;
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

            if (RegisterAsAdmin)
            {
                query = $"""

                         INSERT INTO Admin (Admin_Name, Admin_Email, Pass_Hashed, Phone_Number)
                         VALUES ({$"{firstName} {lastName}"}, '{email}', '{password}', '{phoneNumber}');
                         
                                     
                         """;
            }
            else
            {
                if (userTypeComboBox.SelectedIndex == 0)
                {
                    query = $"""
                             
                                             INSERT INTO Customer (First_Name, Last_Name, Date_Of_Birth, Email, Pass_Hashed, Phone_Number)
                                             VALUES ('{firstName}', '{lastName}', '{dateOfBirth}', '{email}', '{password}', '{phoneNumber}')
                                         
                             """;
                }
                else
                {
                     query = $@"
    INSERT INTO Seller (Seller_Name, Seller_Email, Pass_Hashed, Phone_Number, Seller_Address)
    VALUES ('{firstName} {lastName}', '{email}', '{password}', '{phoneNumber}', '{textBox1.Text.Trim()}')
";

                }
            }


            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Hide();
            Program.LoginFormInstance.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Registration failed. Error: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void Register_Load(object sender, EventArgs e)
    {
        userTypeComboBox.SelectedIndex = 0;
    }

    private void userTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (userTypeComboBox.SelectedIndex == 0)
        {
            // Show the date of birth field and hide the address field
            dateTimePicker1.Visible = true;
            dateOfBirthLabel.Visible = true;
            textBox1.Visible = false;
            label1.Visible = false;
        }
        else
        {
            // Show the address text field and hide the date of birth field
            dateTimePicker1.Visible = false;
            dateOfBirthLabel.Visible = false;
            textBox1.Visible = true;
            label1.Visible = true;
        }
    }
}