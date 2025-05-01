using System;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

internal partial class AddAddress : Form
{
    private readonly MyProfile _myProfile;

    internal AddAddress(MyProfile myProfile)
    {
        InitializeComponent();
        _myProfile = myProfile;
    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
        var city = textBox1.Text.Trim();
        var label = nameTextBox.Text.Trim();
        var description = descriptionTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(label) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Please fill in all fields.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            var query = $"""
                         
                                     INSERT INTO Customer_Address (Customer_ID, Label, City, Address_Description)
                                     VALUES ({Login.User.Value}, '{label}', '{city}', '{description}')
                                 
                         """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Address added successfully!", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _myProfile.MyProfile_Load(null, null);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add address. Error: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
