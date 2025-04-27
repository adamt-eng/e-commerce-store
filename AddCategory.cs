using System;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class AddCategory : Form
{
    internal AddCategory() => InitializeComponent();

    private void doneButton_Click(object sender, EventArgs e)
    {
        // get entered product details
        var name = nameTextBox.Text.Trim();
        var description = descriptionTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
        {
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
           
            var query = $"""
                         
                                         INSERT INTO Category (Category_ID,Category_Name, Category_Description)
                                         VALUES (3,'{name}', '{description}')
                                     
                         """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //to clear form after product is added
            nameTextBox.Clear();
            descriptionTextBox.Clear();

            (Login.MainForm as AdminPage).RefreshCategories();

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add category. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
