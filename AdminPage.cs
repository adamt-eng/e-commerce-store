using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class AdminPage : Form
{
    private DataTable _users;
    private DataTable _sellers;
    private DataTable _products;
    private DataTable _categories;
    private DataTable _orders;

    internal AdminPage() => InitializeComponent();

    private void AdminPage_Load(object sender, EventArgs e)
    {
        RefreshTables();
        comboBox1.SelectedIndex = 0;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (comboBox1.SelectedIndex)
        {
            case 0:
                dataGridView1.DataSource = _users;
                deleteButton.Show();
                deleteButton.Text = "Ban";
                break;
            case 1:
                dataGridView1.DataSource = _sellers;
                deleteButton.Show();
                deleteButton.Text = "Ban";
                break;
            case 2:
                dataGridView1.DataSource = _products;
                deleteButton.Show();
                deleteButton.Text = "Delete";
                break;
            case 3:
                dataGridView1.DataSource = _orders;
                deleteButton.Hide();
                break;
            case 4:
                dataGridView1.DataSource = _categories;
                deleteButton.Show();
                deleteButton.Text = "Delete";
                break;
        }

        dataGridView1.Update();
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count > 0)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var selectedRowIndex = selectedRow.Index;

            if (selectedRowIndex < 0) return;

            if (dataGridView1.DataSource == _users)
            {
                var customerId = _users.Rows[selectedRowIndex]["Customer_ID"];
                Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Customer WHERE Customer_ID = {customerId}");
            }
            else if (dataGridView1.DataSource == _sellers)
            {
                var sellerId = _sellers.Rows[selectedRowIndex]["Seller_ID"];
                Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Seller WHERE Seller_ID = {sellerId}");
            }
            else if (dataGridView1.DataSource == _products)
            {
                var productId = _products.Rows[selectedRowIndex]["Product_ID"];
                Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Product WHERE Product_ID = {productId}");
            }
            else if (dataGridView1.DataSource == _categories)
            {
                var categoryId = _categories.Rows[selectedRowIndex]["Category_ID"];
                Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Category WHERE Category_ID = {categoryId}");
            }
            else
            {
                MessageBox.Show("Unknown table selected.");
                return;
            }

            MessageBox.Show("Deleted successfully.");
            RefreshTables();
            comboBox1_SelectedIndexChanged(null, null); // Reload current view
        }
        else
        {
            MessageBox.Show("Please select a full row to delete.");
        }
    }

    private void RefreshTables()
    {
        _users = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Customer");
        _sellers = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Seller");
        _products = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Product");
        _orders = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM [Order]"); // [Order] because it's a reserved word
        _categories = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Category");
    }
}
