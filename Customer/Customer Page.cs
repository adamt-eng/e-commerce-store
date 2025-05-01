using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer
{
    internal partial class CustomerPage : Form
    {
        internal CustomerPage() => InitializeComponent();
        private DataTable _products = new();

        private void CustomerPage_Load(object sender, EventArgs e)
        {
            _products.Columns.Add("Product_ID");
            _products.Columns.Add("Product_Name");
            _products.Columns.Add("Description");
            _products.Columns.Add("Quantity");
            _products.Columns.Add("Published_At");
            _products.Columns.Add("Price");
            _products.Columns.Add("Seller_Name");
            _products.Columns.Add("Category_Name");
            _products.Columns.Add("Image_Link");
            LoadProducts();
        }

        internal void LoadProducts()
        {
            var query = """
                SELECT p.Product_ID, p.Product_Name, p.Product_Description AS Description,
                        p.Quantity_In_Stock AS Quantity, p.Published_At, p.Price,
                        s.Seller_Name, c.Category_Name, p.Image_Link
                FROM Product p
                 LEFT JOIN Category c ON p.Category_ID = c.Category_ID
                 INNER JOIN Seller s ON p.Seller_ID = s.Seller_ID
                 WHERE p.Quantity_In_Stock > 0
                """;
            _products.Clear();
            foreach (DataRow row in ((DataTable)Program.DatabaseHandler.ExecuteQuery(query)).Rows)
            {
                _products.ImportRow(row);
            }
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            productsFlowLayoutPanel.Controls.Clear();
            foreach (DataRow row in _products.Rows)
            {
                // Create product panel
                Panel productPanel = new Panel
                {
                    Width = productsFlowLayoutPanel.Width - 25,
                    Height = 150,
                    BackColor = Color.FromArgb(69, 93, 127),
                    Margin = new Padding(0, 0, 0, 10)
                };

                // Add product image
                PictureBox productImage = new PictureBox
                {
                    Width = 130,
                    Height = 130,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(10, 10),
                    BackColor = Color.White
                };

                try
                {
                    string imageUrl = row["Image_Link"].ToString();
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            byte[] imageBytes = webClient.DownloadData(imageUrl);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                productImage.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
                catch
                {
                    // Use a placeholder image if the image can't be loaded
                    productImage.BackColor = Color.LightGray;
                }

                // Add product details
                Label nameLabel = new Label
                {
                    Text = row["Product_Name"].ToString(),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(241, 250, 238),
                    Location = new Point(150, 10),
                    Width = productPanel.Width - 160,
                    AutoSize = false
                };

                Label quantityLabel = new Label
                {
                    Text = $"In Stock: {row["Quantity"]}",
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(241, 250, 238),
                    Location = new Point(150, 40),
                    Width = 200
                };

                Label priceLabel = new Label
                {
                    Text = $"Price: ${row["Price"]}",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.FromArgb(241, 250, 238),
                    Location = new Point(150, 70),
                    Width = 200
                };

                Label categoryLabel = new Label
                {
                    Text = $"Category: {row["Category_Name"]}",
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.FromArgb(241, 250, 238),
                    Location = new Point(150, 100),
                    Width = 200
                };

                // Store product ID in the panel's Tag property
                productPanel.Tag = row["Product_ID"];

                // Add click event to the panel
                productPanel.Click += ProductPanel_Click;
                productImage.Click += (s, e) => ProductPanel_Click(productPanel, e);
                nameLabel.Click += (s, e) => ProductPanel_Click(productPanel, e);
                quantityLabel.Click += (s, e) => ProductPanel_Click(productPanel, e);
                priceLabel.Click += (s, e) => ProductPanel_Click(productPanel, e);
                categoryLabel.Click += (s, e) => ProductPanel_Click(productPanel, e);

                // Add controls to panel
                productPanel.Controls.Add(productImage);
                productPanel.Controls.Add(nameLabel);
                productPanel.Controls.Add(quantityLabel);
                productPanel.Controls.Add(priceLabel);
                productPanel.Controls.Add(categoryLabel);

                // Add panel to flow layout
                productsFlowLayoutPanel.Controls.Add(productPanel);
            }
        }

        private void ProductPanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null && sender is Control control)
            {
                panel = control.Parent as Panel;
            }
            if (panel != null && panel.Tag != null)
            {
                try
                {
                    int productId = Convert.ToInt32(panel.Tag);
                    new ProductView(productId).ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load product. Error: {ex.Message}", "E-Commerce Store",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SearchForProductsTextBox_TextChanged(object sender, EventArgs e)
        {
            var productView = _products.DefaultView;
            string searchText = searchForProductsTextBox.Text.ToLower();
            productView.RowFilter = string.Format(
                "Product_Name LIKE '%{0}%' OR Description LIKE '%{0}%' OR Category_Name LIKE '%{0}%'",
                searchText);
            DataTable filteredTable = productView.ToTable();
            _products = filteredTable;
            // Refresh the product display
            DisplayProducts();
        }

        private void MyProfileButton_Click(object sender, EventArgs e) => new MyProfile().ShowDialog();

        private void CartButton_Click(object sender, EventArgs e)
        {
            var query = $"""
                SELECT c.Cart_ID 
                FROM Cart c
                INNER JOIN Added_To at ON c.Cart_ID = at.Cart_ID
                WHERE c.Customer_ID = {Login.User.Value}
                """;
            var cartTable = (DataTable)Program.DatabaseHandler.ExecuteQuery(query);
            if (cartTable.Rows.Count > 0)
            {
                var cart = new Cart(Convert.ToInt32(cartTable.Rows[0]["Cart_ID"]));
                cart.ShowDialog();
                if (!cart.PurchaseDone) return;
                _products = new DataTable();
                CustomerPage_Load(null, null);
            }
            else
            {
                MessageBox.Show("Your cart is empty.", "E-Commerce Store",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CustomerPage_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}