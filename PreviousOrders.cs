using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class PreviousOrders : Form
{
    internal PreviousOrders() => InitializeComponent();
    DataTable products = new DataTable();

    private void searchForProductsTextBox_TextChanged(object sender, EventArgs e)
    {
        // Implement logic that refreshes the dataview control with products that match the input text
    }

    private void HomePage_Load(object sender, EventArgs e)
    {
        products.Columns.Add("Product_ID");
        products.Columns.Add("Description");
        products.Columns.Add("Status");
        products.Columns.Add("Published_At");
        products.Columns.Add("Price");
        products.Columns.Add("Seller_ID");    // Foreign Key
        products.Columns.Add("Category_Name");  // Foreign Key

        // Load all products with SQL
    }

    private void myProfileButton_Click(object sender, EventArgs e)
    {
        Hide();
        new MyProfile().ShowDialog();
    }
}