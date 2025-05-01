using System;
using System.Data;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Seller;

internal partial class SellerPage : Form
{
    private DataTable _products = new();
    internal SellerPage() => InitializeComponent();

    private void SellerPage_Load(object sender, EventArgs e)
    {
        _products.Columns.Add("Product_ID");
        _products.Columns.Add("Product_Name");
        _products.Columns.Add("Price");
        _products.Columns.Add("Product_Description");
        _products.Columns.Add("Quantity_In_Stock");
        _products.Columns.Add("Published_At");
        _products.Columns.Add("Category_Name");

        LoadSellerProducts();

        dataGridView.DataSource = _products;
    }

    internal void LoadSellerProducts()
    {
        var query = "SELECT p.Product_ID, p.Product_Name, p.Price, p.Product_Description, p.Quantity_In_Stock, p.Published_At, c.Category_Name " +
                    "FROM Product p JOIN Category c ON p.Category_ID = c.Category_ID " +
                    $"WHERE p.Seller_ID = {Login.User.Value}";

        _products.Clear();
        _products = (DataTable)Program.DatabaseHandler.ExecuteQuery(query);
        dataGridView.DataSource = _products;
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count != 0)
        {
            var selectedRowIndex = dataGridView.SelectedRows[0].Index;

            Program.DatabaseHandler.ExecuteQuery($"sp_DeleteProduct {_products.Rows[selectedRowIndex]["Product_ID"]}");

            // Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Product WHERE Product_ID = {_products.Rows[selectedRowIndex]["Product_ID"]}");

            _products.Rows.RemoveAt(selectedRowIndex);

            MessageBox.Show("Product deleted successfully.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Please select a full row to delete.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void AddButton_Click(object sender, EventArgs e) => new AddProduct().ShowDialog();

    private void SellerPage_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
}