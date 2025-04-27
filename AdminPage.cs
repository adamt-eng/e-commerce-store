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
    }


    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 0)
        {
            //users sellers products orders categs
            dataGridView1.DataSource = users;
        }
        else if (comboBox1.SelectedIndex == 1)
        {
            dataGridView1.DataSource = sellers;
        }
        else if (comboBox1.SelectedIndex == 2)
        {
            dataGridView1.DataSource = products;
        }
        else if (comboBox1.SelectedIndex == 3)
        {
            dataGridView1.DataSource = orders;
        }
        else if (comboBox1.SelectedIndex == 4)
        {
            dataGridView1.DataSource = categories;
        }

        dataGridView1.Update();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}