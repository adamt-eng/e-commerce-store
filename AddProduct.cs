using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce_Store
{
    internal partial class AddProduct : Form
    {
        internal AddProduct() => InitializeComponent();

        private void ProductAdd_Load(object sender, EventArgs e)
        {
            // Enable all textboxes to be editable
            foreach (var control in Controls.OfType<TextBox>())
            {
                control.ReadOnly = false;
            }

            // Load categories into the ComboBox
            var categories = (DataTable)Program.DatabaseHandler.ExecuteQuery("SELECT Category_Name, Category_ID FROM Category");
            foreach (DataRow row in categories.Rows)
            {
                categoryComboBox.Items.Add(new { Text = row["Category_Name"].ToString(), Value = row["Category_ID"] });
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Get entered product details
            var productName = nameTextBox.Text.Trim();
            var productDescription = descriptionTextBox.Text.Trim();
            var priceText = priceTextBox.Text.Trim();
            var stockText = stockTextBox.Text.Trim();
            var category = categoryComboBox.SelectedItem as dynamic;
            var sellerId = 1; // Assuming the seller's ID is known (e.g., logged-in user ID)
            var imageLink = "defaultImageLink"; // Replace with actual image link logic

            // Validate inputs
            if (string.IsNullOrWhiteSpace(productName) ||
                string.IsNullOrWhiteSpace(priceText) ||
                string.IsNullOrWhiteSpace(stockText) ||
                string.IsNullOrWhiteSpace(category?.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate price
            if (!decimal.TryParse(priceText, out var price))
            {
                MessageBox.Show("Price must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate stock
            if (!int.TryParse(stockText, out var stock))
            {
                MessageBox.Show("Stock must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected category ID
            var categoryId = category?.Value;

            // Insert product into the database
            try
            {
                var query = $@"
                    INSERT INTO Product (Product_Name, Price, Product_Description, Quantity_In_Stock, Published_At, Category_ID, Seller_ID, Image_Link)
                    VALUES ('{productName}', {price}, '{productDescription}', {stock}, '{DateTime.Now:yyyy-MM-dd}', {categoryId}, {sellerId}, '{imageLink}')
                ";

                Program.DatabaseHandler.ExecuteQuery(query);

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form fields after successful addition
                nameTextBox.Clear();
                priceTextBox.Clear();
                descriptionTextBox.Clear();
                stockTextBox.Clear();
                categoryComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add product. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
