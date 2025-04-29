using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class ProductView : Form
{
    internal int ProductId;

    internal ProductView(int productId)
    {
        InitializeComponent();
        ProductId = productId;
    }

    private void ProductView_Load(object sender, EventArgs e)
    {
        var query = $"""
                      SELECT 
                          p.Product_ID, 
                          p.Product_Name,
                          p.Product_Description AS Description, 
                          p.Quantity_In_Stock AS Quantity, 
                          p.Published_At, 
                          p.Price, 
                          p.Image_Link,
                          s.Seller_Name, 
                          c.Category_Name
                      FROM 
                          Product p
                      LEFT JOIN 
                          Category c ON p.Category_ID = c.Category_ID
                      INNER JOIN 
                          Seller s ON p.Seller_ID = s.Seller_ID
                      WHERE p.Product_ID = {ProductId}
                     """;

        var result = Program.DatabaseHandler.ExecuteQuery(query);
        var product = ((DataTable)result).Rows[0];

        titleLabel.Text = product["Product_Name"].ToString();
        productDescriptionLabel.Text = product["Description"].ToString();
        priceLabel.Text = $"Price: ${product["Price"]}";
        stockLabel.Text = $"Stock: {product["Quantity"]}";
        publishedAtLabel.Text = $"Published At: {(DateTime)product["Published_At"]:yyyy-MM-dd}";
        sellerLabel.Text = $"Seller: {product["Seller_Name"]}";
        _ = LoadImageFromUrlAsync(product["Image_Link"].ToString());
        inCartNumericUpDown.Maximum = Convert.ToDecimal(product["Quantity"]);
    }

    private async Task LoadImageFromUrlAsync(string url)
    {
        try
        {
            using var client = new HttpClient();
            var imageData = await client.GetByteArrayAsync(url);

            using var ms = new MemoryStream(imageData);
            productImageButton.BackgroundImage = Image.FromStream(ms);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading image: {ex.Message}");
        }
    }

    private void inCartNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        var customerId = Login.User.Value;
        var quantity = (int)inCartNumericUpDown.Value;

        var cartId = GetOrCreateCartId(customerId, quantity > 0);
        if (cartId == null)
        {
            MessageBox.Show("No cart exists, and product quantity is 0. Nothing to do.");
            return;
        }

        if (quantity <= 0)
        {
            var removeQuery = $"""
                           DELETE FROM Added_To
                           WHERE Cart_ID = {cartId} AND Product_ID = {ProductId}
                           """;
            Program.DatabaseHandler.ExecuteQuery(removeQuery);
            UpdateCartTotalPrice(cartId.Value);
            MessageBox.Show("Product removed from cart.");
        }
        else
        {
            var checkProductQuery = $"""
                                 SELECT Quantity FROM Added_To
                                 WHERE Cart_ID = {cartId} AND Product_ID = {ProductId}
                                 """;
            var productResult = Program.DatabaseHandler.ExecuteQuery(checkProductQuery);
            var productTable = (DataTable)productResult;

            if (productTable.Rows.Count > 0)
            {
                var updateQuery = $"""
                               UPDATE Added_To
                               SET Quantity = {quantity}
                               WHERE Cart_ID = {cartId} AND Product_ID = {ProductId}
                               """;
                Program.DatabaseHandler.ExecuteQuery(updateQuery);
                MessageBox.Show("Product quantity updated in cart.");
            }
            else
            {
                var insertQuery = $"""
                               INSERT INTO Added_To (Cart_ID, Product_ID, Quantity)
                               VALUES ({cartId}, {ProductId}, {quantity})
                               """;
                Program.DatabaseHandler.ExecuteQuery(insertQuery);
                MessageBox.Show("Product added to cart.");
            }

            UpdateCartTotalPrice(cartId.Value);
        }
    }

    private static int? GetOrCreateCartId(int customerId, bool shouldCreate)
    {
        var checkQuery = $"SELECT Cart_ID FROM Cart WHERE Customer_ID = {customerId}";
        var result = (DataTable)Program.DatabaseHandler.ExecuteQuery(checkQuery);

        if (result.Rows.Count > 0)
        {
            return Convert.ToInt32(result.Rows[0]["Cart_ID"]);
        }

        if (!shouldCreate)
        {
            return null;
        }

        var expiry = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss");
        var createQuery = $"""
                       INSERT INTO Cart (Customer_ID, Total_Price, Cart_Expiry_Date)
                       VALUES ({customerId}, 0, '{expiry}')
                       """;
        Program.DatabaseHandler.ExecuteQuery(createQuery);

        var getNewCartQuery = $"SELECT Cart_ID FROM Cart WHERE Customer_ID = {customerId}";
        var newCartResult = (DataTable)Program.DatabaseHandler.ExecuteQuery(getNewCartQuery);
        return newCartResult.Rows.Count > 0? Convert.ToInt32(newCartResult.Rows[0]["Cart_ID"]) : null;
    }

    private static void UpdateCartTotalPrice(int cartId)
    {
        var updateCartQuery = $"""
                           UPDATE Cart
                           SET Total_Price = (SELECT SUM(p.Price * at.Quantity)
                                              FROM Added_To at
                                              JOIN Product p ON at.Product_ID = p.Product_ID
                                              WHERE at.Cart_ID = {cartId})
                           WHERE Cart_ID = {cartId}
                           """;
        Program.DatabaseHandler.ExecuteQuery(updateCartQuery);
    }
}
