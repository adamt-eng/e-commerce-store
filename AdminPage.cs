using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class AdminPage : Form
{
    private DataTable _users = new();
    private DataTable _sellers = new();
    private DataTable _products = new();
    private DataTable _categories = new();
    private DataTable _orders = new();
    internal AdminPage() => InitializeComponent();

    private void AdminPage_Load(object sender, EventArgs e)
    {
        comboBox1.SelectedIndex = 0;
        // Users table (based on "Customer")
        _users.Columns.Add("Customer_ID");
        _users.Columns.Add("FName");
        _users.Columns.Add("LName");
        _users.Columns.Add("Phone_Number");
        _users.Columns.Add("DOB");
        _users.Columns.Add("Email");

        // Sellers table
        _sellers.Columns.Add("Seller_ID");
        _sellers.Columns.Add("FName");
        _sellers.Columns.Add("LName");
        _sellers.Columns.Add("Phone_Number");
        _sellers.Columns.Add("Email");
        _sellers.Columns.Add("Address");

        // Products table
        _products.Columns.Add("Product_ID");
        _products.Columns.Add("Description");
        _products.Columns.Add("Status");
        _products.Columns.Add("Published_At");
        _products.Columns.Add("Price");
        _products.Columns.Add("Seller_ID");    // Foreign Key
        _products.Columns.Add("Category_Name");  // Foreign Key

        // Orders table
        _orders.Columns.Add("Order_ID");
        _orders.Columns.Add("Date");
        _orders.Columns.Add("Shipping_Address");
        _orders.Columns.Add("Status");
        _orders.Columns.Add("Customer_ID"); // Foreign Key
        _orders.Columns.Add("Billing_Address");

        // Categories table
        _categories.Columns.Add("Category_ID");
        _categories.Columns.Add("Name");
        _categories.Columns.Add("Description");


        // Dummy data for Users
        _users.Rows.Add("U001", "John", "Doe", "1234567890", "1990-01-01", "john@example.com");
        _users.Rows.Add("U002", "Jane", "Smith", "0987654321", "1992-03-15", "jane@example.com");

        // Dummy data for Sellers
        _sellers.Rows.Add("S001", "Alice", "Johnson", "1112223333", "alice@example.com", "123 Main St");
        _sellers.Rows.Add("S002", "Bob", "Williams", "4445556666", "bob@example.com", "456 Oak Ave");

        // Dummy data for Products
        _products.Rows.Add("P001", "Gaming Laptop", "Available", "2024-01-01", "1500.00", "S001", "Electronics");
        _products.Rows.Add("P002", "Smartphone", "Available", "2024-02-15", "800.00", "S002", "Electronics");

        // Dummy data for Orders
        _orders.Rows.Add("O001", "2025-04-01", "789 Pine St", "Shipped", "U001", "101 Cedar Blvd");
        _orders.Rows.Add("O002", "2025-04-02", "654 Maple Ave", "Processing", "U002", "202 Elm St");

        // Dummy data for Categories
        _categories.Rows.Add("C001", "Electronics", "Devices like phones, laptops, etc.");
        _categories.Rows.Add("C002", "Clothing", "Apparel and accessories.");

    }


    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 0)
        {
            //users sellers products orders categs
            loginButton.Show();
            dataGridView1.DataSource = _users;
            loginButton.Text = "Ban";
        }
        else if (comboBox1.SelectedIndex == 1)
        {
            loginButton.Show();
            dataGridView1.DataSource = _sellers;
            loginButton.Text = "Ban";
        }
        else if (comboBox1.SelectedIndex == 2)
        {
            loginButton.Show();
            dataGridView1.DataSource = _products;
            loginButton.Text = "Delete";
        }
        else if (comboBox1.SelectedIndex == 3)
        {
            dataGridView1.DataSource = _orders;
            loginButton.Hide();
        }
        else if (comboBox1.SelectedIndex == 4)
        {
            loginButton.Show();
            dataGridView1.DataSource = _categories;
            loginButton.Text = "Delete";
        }

        dataGridView1.Update();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }


    private void loginButton_Click_1(object sender, EventArgs e)
    {
        if(!(dataGridView1.SelectedRows.Count == 0)) {
        int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

        
        
            // Now determine which DataTable is currently shown
            if (dataGridView1.DataSource == _users)
            {
                _users.Rows.RemoveAt(selectedRowIndex);
                //SQL
            }
            else if (dataGridView1.DataSource == _sellers)
            {
                _sellers.Rows.RemoveAt(selectedRowIndex);
                //SQL
            }
            else if (dataGridView1.DataSource == _products)
            {
                _products.Rows.RemoveAt(selectedRowIndex);
            }
            else if (dataGridView1.DataSource == _orders)
            {
                _orders.Rows.RemoveAt(selectedRowIndex);
                //SQL
            }
            else if (dataGridView1.DataSource == _categories)
            {
                _categories.Rows.RemoveAt(selectedRowIndex);
                //SQL
            }
            else
            {
                MessageBox.Show("Unknown table selected.");
            }
        }

        else
        {
            MessageBox.Show("Please select a full row to delete.");
        }
    }
}