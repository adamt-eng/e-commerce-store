using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class AddAddress : Form
{
    internal AddAddress() => InitializeComponent();

    private void doneButton_Click(object sender, EventArgs e)
    {
        // get entered product details
        var city = textBox1.Text.Trim();
        var label = nameTextBox.Text.Trim();
        var description = descriptionTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(label) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var query = $"""
                         
                                     INSERT INTO Customer_Address (Customer_ID, Label, City, Address_Description)
                                     VALUES ({Login.User.Value}, '{label}', '{city}', '{description}')
                                 
                         """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Address added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //to clear form after address is added
            nameTextBox.Clear();
            descriptionTextBox.Clear();
            textBox1.Clear();
            new MyProfile().Show();
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add address. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
