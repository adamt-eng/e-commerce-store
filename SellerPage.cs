using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store
{
    internal partial class SellerPage : Form
    {
        private DataTable _products = new();

        internal SellerPage() => InitializeComponent();

        private void SellerPage_Load(object sender, EventArgs e)
        {
            // Define Products table with the necessary columns
            _products.Columns.Add("Product_ID");
            _products.Columns.Add("Product_Name");
            _products.Columns.Add("Price");
            _products.Columns.Add("Product_Description");
            _products.Columns.Add("Quantity_In_Stock");
            _products.Columns.Add("Published_At");
            _products.Columns.Add("Category_Name");

            // Load products for the current seller
            LoadSellerProducts();

            // Show the products in the DataGridView
            dataGridView1.DataSource = _products;
        }

        // Method to load products for the logged-in seller
        private void LoadSellerProducts()
        {
            // Assuming the seller's ID is stored in a global variable or session.
            int sellerId = Login.User.Value;  // Replace this with actual seller's ID logic

            string query = $"SELECT p.Product_ID, p.Product_Name, p.Price, p.Product_Description, p.Quantity_In_Stock, p.Published_At, c.Category_Name " +
                           "FROM Product p " +
                           "JOIN Category c ON p.Category_ID = c.Category_ID " +
                           $"WHERE p.Seller_ID = {sellerId}";

            // Execute the query and get the result
            var result = Program.DatabaseHandler.ExecuteQuery(query);

            // Populate the DataTable with the result
            _products.Clear();
            _products = (DataTable)result;
        }

        // Handle product deletion
        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                var selectedProductId = _products.Rows[selectedRowIndex]["Product_ID"];

                // Delete the product from the database using its Product_ID
                var query = $"DELETE FROM Product WHERE Product_ID = {selectedProductId}";
                Program.DatabaseHandler.ExecuteQuery(query);

                // Remove the product from the DataTable
                _products.Rows.RemoveAt(selectedRowIndex);

                MessageBox.Show("Product deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a full row to delete.");
            }
        }

        // Show AddProduct form for adding new products
        private void AddButton_Click_1(object sender, EventArgs e)
        {
            var addProduct = new AddProduct();
            addProduct.ShowDialog();

            // Refresh the product list after adding a new product
            LoadSellerProducts();
        }

        // Handle cell content clicks in DataGridView (optional, for handling edits, etc.)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can add logic here if you want to handle clicks on cells (e.g., for editing)
        }
    }
}
