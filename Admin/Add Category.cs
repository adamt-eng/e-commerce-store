using System;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Admin;

internal partial class AddCategory : Form
{
    internal AddCategory() => InitializeComponent();

    private void doneButton_Click(object sender, EventArgs e)
    {
        var name = nameTextBox.Text.Trim();
        var description = descriptionTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Please fill in all fields.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
           
            var query = $"""
                         
                                         INSERT INTO Category (Category_Name, Category_Description)
                                         VALUES ('{name}', '{description}')
                                     
                         """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Category added successfully!", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

            (Login.MainForm as AdminPage).RefreshCategories();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add category. Error: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
