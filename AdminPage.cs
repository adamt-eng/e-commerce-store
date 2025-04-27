using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class AdminPage : Form
{
    DataTable users = new DataTable();
    DataTable sellers = new DataTable();
    DataTable products = new DataTable();
    DataTable categories = new DataTable();
    DataTable orders = new DataTable();
    internal AdminPage() => InitializeComponent();

    private void AdminPage_Load(object sender, EventArgs e)
    {
        comboBox1.SelectedIndex = 0;
        // Users table (based on "Customer")
        users.Columns.Add("Customer_ID");
        users.Columns.Add("FName");
        users.Columns.Add("LName");
        users.Columns.Add("Phone_Number");
        users.Columns.Add("DOB");
        users.Columns.Add("Email");

        // Sellers table
        sellers.Columns.Add("Seller_ID");
        sellers.Columns.Add("FName");
        sellers.Columns.Add("LName");
        sellers.Columns.Add("Phone_Number");
        sellers.Columns.Add("Email");
        sellers.Columns.Add("Address");

        // Products table
        products.Columns.Add("Product_ID");
        products.Columns.Add("Description");
        products.Columns.Add("Status");
        products.Columns.Add("Published_At");
        products.Columns.Add("Price");
        products.Columns.Add("Seller_ID");    // Foreign Key
        products.Columns.Add("Category_Name");  // Foreign Key

        // Orders table
        orders.Columns.Add("Order_ID");
        orders.Columns.Add("Date");
        orders.Columns.Add("Shipping_Address");
        orders.Columns.Add("Status");
        orders.Columns.Add("Customer_ID"); // Foreign Key
        orders.Columns.Add("Billing_Address");

        // Categories table
        categories.Columns.Add("Category_ID");
        categories.Columns.Add("Name");
        categories.Columns.Add("Description");


        // Dummy data for Users
        users.Rows.Add("U001", "John", "Doe", "1234567890", "1990-01-01", "john@example.com");
        users.Rows.Add("U002", "Jane", "Smith", "0987654321", "1992-03-15", "jane@example.com");

        // Dummy data for Sellers
        sellers.Rows.Add("S001", "Alice", "Johnson", "1112223333", "alice@example.com", "123 Main St");
        sellers.Rows.Add("S002", "Bob", "Williams", "4445556666", "bob@example.com", "456 Oak Ave");

        // Dummy data for Products
        products.Rows.Add("P001", "Gaming Laptop", "Available", "2024-01-01", "1500.00", "S001", "Electronics");
        products.Rows.Add("P002", "Smartphone", "Available", "2024-02-15", "800.00", "S002", "Electronics");

        // Dummy data for Orders
        orders.Rows.Add("O001", "2025-04-01", "789 Pine St", "Shipped", "U001", "101 Cedar Blvd");
        orders.Rows.Add("O002", "2025-04-02", "654 Maple Ave", "Processing", "U002", "202 Elm St");

        // Dummy data for Categories
        categories.Rows.Add("C001", "Electronics", "Devices like phones, laptops, etc.");
        categories.Rows.Add("C002", "Clothing", "Apparel and accessories.");

    }


    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 0)
        {
            //users sellers products orders categs
            loginButton.Show();
            dataGridView1.DataSource = users;
            loginButton.Text = "Ban";
        }
        else if (comboBox1.SelectedIndex == 1)
        {
            loginButton.Show();
            dataGridView1.DataSource = sellers;
            loginButton.Text = "Ban";
        }
        else if (comboBox1.SelectedIndex == 2)
        {
            loginButton.Show();
            dataGridView1.DataSource = products;
            loginButton.Text = "Delete";
        }
        else if (comboBox1.SelectedIndex == 3)
        {
            dataGridView1.DataSource = orders;
            loginButton.Hide();
        }
        else if (comboBox1.SelectedIndex == 4)
        {
            loginButton.Show();
            dataGridView1.DataSource = categories;
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
            if (dataGridView1.DataSource == users)
            {
                users.Rows.RemoveAt(selectedRowIndex);
                //SQL
            }
            else if (dataGridView1.DataSource == sellers)
            {
                sellers.Rows.RemoveAt(selectedRowIndex);
                //SQL
            }
            else if (dataGridView1.DataSource == products)
            {
                products.Rows.RemoveAt(selectedRowIndex);
            }
            else if (dataGridView1.DataSource == orders)
            {
                orders.Rows.RemoveAt(selectedRowIndex);
                //SQL
            }
            else if (dataGridView1.DataSource == categories)
            {
                categories.Rows.RemoveAt(selectedRowIndex);
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