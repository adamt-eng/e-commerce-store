using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class HomePage : Form
{
    internal HomePage() => InitializeComponent();
    private DataTable _products = new();

    private void searchForProductsTextBox_TextChanged(object sender, EventArgs e)
    {
        // Implement logic that refreshes the dataview control with products that match the input text
    }

    private void HomePage_Load(object sender, EventArgs e)
    {
        _products.Columns.Add("Product_ID");
        _products.Columns.Add("Description");
        _products.Columns.Add("Status");
        _products.Columns.Add("Published_At");
        _products.Columns.Add("Price");
        _products.Columns.Add("Seller_ID");    // Foreign Key
        _products.Columns.Add("Category_Name");  // Foreign Key

        // Load all products with SQL
    }

    private void myProfileButton_Click(object sender, EventArgs e)
    {
        Hide();
        new MyProfile().ShowDialog();
    }

    private void cartButton_Click(object sender, EventArgs e)
    {
        Hide();
        new Cart().ShowDialog();
    }
}