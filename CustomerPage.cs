using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store
{
    internal partial class CustomerPage : Form
    {
        internal CustomerPage() => InitializeComponent();

        private DataTable _products = new();

        private void CustomerPage_Load(object sender, EventArgs e)
        {
            // Initialize the columns for the product table
            _products.Columns.Add("Product_ID");
            _products.Columns.Add("Description");
            _products.Columns.Add("Status");
            _products.Columns.Add("Published_At");
            _products.Columns.Add("Price");
            _products.Columns.Add("Seller_ID");  // Foreign Key
            _products.Columns.Add("Category_Name");  // Foreign Key

            // Load all products with SQL
            LoadProducts();

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = _products;
        }

        // Load all products into the DataTable
        private void LoadProducts()
        {
            // Query to get all products
            var query = "SELECT * FROM Product";  // Assuming the table name is Product
            var result = Program.DatabaseHandler.ExecuteQuery(query);

            // Populate _products DataTable with results
            _products.Clear();
            _products = (DataTable)result;  // Directly assign the result to the _products DataTable
        }

        // Handle search input to filter products
        private void searchForProductsTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchForProductsTextBox.Text.ToLower();

            // Filter products based on the search term
            DataView productView = _products.DefaultView;
            productView.RowFilter = string.Format("Description LIKE '%{0}%' OR Category_Name LIKE '%{0}%'", searchTerm);

            // Bind filtered DataView to the DataGridView
            dataGridView1.DataSource = productView;
        }

        // Navigate to the user's profile page
        private void myProfileButton_Click(object sender, EventArgs e)
        {
            Hide();
            new MyProfile().ShowDialog();
            Show(); // Show the CustomerPage again after profile is closed
        }

        // Navigate to the user's cart page
        private void cartButton_Click(object sender, EventArgs e)
        {
            Hide();
            new Cart().ShowDialog();
            Show(); // Show the CustomerPage again after cart is closed
        }
    }
}
