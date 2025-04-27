using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class AddProduct : Form
{
    internal AddProduct() => InitializeComponent();

    private void ProductAdd_Load(object sender, EventArgs e)
    {
        foreach (var control in Controls.OfType<TextBox>())
        {
            control.ReadOnly = false;
        }

        var x = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT Category_Name FROM Category");
        foreach (DataRow row in x.Rows)
        {
            categoryComboBox.Items.Add(row["Category_Name"].ToString());
        }
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        // get entered product details
        var priceText = priceTextBox.Text.Trim();
        var publishedAtText = publishedAtTextBox.Text.Trim();
        var stockText = stockTextBox.Text.Trim();
        var category = categoryComboBox.SelectedItem?.ToString();

        if (string.IsNullOrWhiteSpace(priceText) ||
            string.IsNullOrWhiteSpace(publishedAtText) ||
            string.IsNullOrWhiteSpace(stockText) ||
            string.IsNullOrWhiteSpace(category))
        {
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!decimal.TryParse(priceText, out var price))
        {
            MessageBox.Show("Price must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!DateTime.TryParse(publishedAtText, out var publishedAt))
        {
            MessageBox.Show("Published At must be a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!int.TryParse(stockText, out var stock))
        {
            MessageBox.Show("Stock must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
           
            var query = $"""
                         
                                         INSERT INTO Products (Price, PublishedAt, Stock, Category)
                                         VALUES ({price}, '{publishedAt:yyyy-MM-dd}', {stock}, '{category}')
                                     
                         """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //to clear form after product is added
            priceTextBox.Clear();
            publishedAtTextBox.Clear();
            stockTextBox.Clear();
            categoryComboBox.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add product. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
