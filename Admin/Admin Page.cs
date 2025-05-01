using System;
using System.Data;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Admin;

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
        comboBox.SelectedIndex = 0;
    }

    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        addButton.Hide();
        orderStatusComboBox.Hide();
        RefreshTables();

        switch (comboBox.SelectedIndex)
        {
            case 0:
                dataGridView.DataSource = _users;
                deleteButton.Text = "Ban";
                deleteButton.Show();
                break;
            case 1:
                dataGridView.DataSource = _sellers;
                deleteButton.Text = "Ban";
                deleteButton.Show();
                break;
            case 2:
                dataGridView.DataSource = _products;
                deleteButton.Text = "Delete";
                deleteButton.Show();
                break;
            case 3:
                dataGridView.DataSource = _orders;
                orderStatusComboBox.Show();
                deleteButton.Hide();
                break;
            case 4:
                addButton.Show();
                dataGridView.DataSource = _categories;
                deleteButton.Text = "Delete";
                deleteButton.Show();
                break;
        }

        dataGridView.Update();
    }

    internal void RefreshCategories()
    {
        RefreshTables();
        dataGridView.DataSource = _categories;
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                var selectedRowIndex = selectedRow.Index;

                if (selectedRowIndex < 0) return;

                if (dataGridView.DataSource == _users)
                {
                    var customerId = _users.Rows[selectedRowIndex]["Customer_ID"];
                    Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Customer WHERE Customer_ID = {customerId}");
                }
                else if (dataGridView.DataSource == _sellers)
                {
                    var sellerId = _sellers.Rows[selectedRowIndex]["Seller_ID"];
                    Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Seller WHERE Seller_ID = {sellerId}");
                }
                else if (dataGridView.DataSource == _products)
                {
                    var productId = _products.Rows[selectedRowIndex]["Product_ID"];
                    Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Product WHERE Product_ID = {productId}");
                    // Program.DatabaseHandler.ExecuteQuery($"sp_DeleteProduct {productId}");
                }
                else if (dataGridView.DataSource == _categories)
                {
                    var categoryId = _categories.Rows[selectedRowIndex]["Category_ID"];
                    Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Category WHERE Category_ID = {categoryId}");
                }
                else
                {
                    return;
                }

                MessageBox.Show("Product deleted successfully.", "E-Commerce Store", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ComboBox_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show("Please select a full row to delete.", "E-Commerce Store", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        catch
        {
            MessageBox.Show("Invalid row.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RefreshTables()
    {
        _users = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Customer");
        _sellers = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Seller");
        _products = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Product");
        _orders = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM [Order]");
        _categories = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT * FROM Category");
    }

    private void AddButton_Click(object sender, EventArgs e) => new AddCategory().ShowDialog();

    private void RegisterButton_Click(object sender, EventArgs e)
    {
        var register = new Register { RegisterAsAdmin = true };
        register.ShowDialog();
    }

    private void AdminPage_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

    private void OrderStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                var selectedRowIndex = selectedRow.Index;

                if (selectedRowIndex < 0) return;

                var orderId = _orders.Rows[selectedRowIndex]["Order_ID"];
                var newStatus = orderStatusComboBox.SelectedItem.ToString();

                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Please select a valid status.", "E-Commerce Store", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Program.DatabaseHandler.ExecuteQuery(
                    $"UPDATE [Order] SET Order_Status = '{newStatus}' WHERE Order_ID = {orderId}");

                MessageBox.Show("Order status updated successfully.", "E-Commerce Store", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ComboBox_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show("Please select a full row to update.", "E-Commerce Store", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        catch
        {
            MessageBox.Show("Invalid row.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}