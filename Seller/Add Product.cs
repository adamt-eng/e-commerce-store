using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Seller;

internal partial class AddProduct : Form
{
    internal AddProduct() => InitializeComponent();
    internal List<Tuple<string, int, string>> Categories = [];

    private void ProductAdd_Load(object sender, EventArgs e)
    {
        // Enable all textboxes to be editable
        foreach (var control in Controls.OfType<TextBox>())
        {
            control.ReadOnly = false;
        }

        // Load categories into the ComboBox
        var categories = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT Category_Name, Category_ID, Category_Description FROM Category");
        foreach (DataRow row in categories.Rows)
        {
            var catName = row["Category_Name"].ToString();
            Categories.Add(new Tuple<string, int, string>(catName, Convert.ToInt32(row["Category_ID"]), row["Category_Description"].ToString()));
            categoryComboBox.Items.Add(catName);
        }
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        var productName = nameTextBox.Text.Trim();
        var productDescription = descriptionTextBox.Text.Trim();
        var priceText = priceTextBox.Text.Trim();
        var stockText = stockTextBox.Text.Trim();
        var categoryComboBoxSelectedItem = categoryComboBox.SelectedItem;
        if (categoryComboBoxSelectedItem == null)
        {
            MessageBox.Show("Invalid category.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var category = categoryComboBoxSelectedItem.ToString();
        var sellerId = Login.User.Value;
        var imageLink = imageLinkTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrWhiteSpace(stockText))
        {
            MessageBox.Show("Please fill in all fields.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!decimal.TryParse(priceText, out var price))
        {
            MessageBox.Show("Price must be a valid number.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!int.TryParse(stockText, out var stock))
        {
            MessageBox.Show("Stock must be a valid number.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var categoryId = Categories.First(cat => cat.Item1 == category).Item2;

        try
        {
            var query = $"""
                         
                                             INSERT INTO Product (Product_Name, Price, Product_Description, Quantity_In_Stock, Published_At, Category_ID, Seller_ID, Image_Link)
                                             VALUES ('{productName}', {price}, '{productDescription}', {stock}, '{DateTime.Now:yyyy-MM-dd}', {categoryId}, {sellerId}, '{imageLink}')
                                         
                         """;

            Program.DatabaseHandler.ExecuteQuery(query);

            MessageBox.Show("Product added successfully!", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
            (Login.MainForm as SellerPage).LoadSellerProducts();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add product. Error: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        categoryDescriptionlabel.Text = Categories.First(cat => cat.Item1 == categoryComboBox.SelectedItem.ToString()).Item3;
    }
}