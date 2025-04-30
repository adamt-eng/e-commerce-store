using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Checkout : Form
{
    private readonly Cart _cart;
    internal Checkout(Cart cart)
    {
        InitializeComponent();
        _cart = cart;
    }

    private void PlaceOrderButton_Click(object sender, EventArgs e)
    {
        if (paymentMethodComboBox.SelectedItem == null)
        {
            MessageBox.Show("Please select a payment method.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (ShippingAddressComboBox.SelectedItem == null)
        {
            MessageBox.Show("Please select a shipping address.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedShippingAddress = ShippingAddressComboBox.SelectedItem.ToString();
        var shippingAddressId = GetAddressIdFromSelection(selectedShippingAddress);
        var total = Convert.ToDecimal(totalPriceLabel.Text.Split(":").Skip(1).First().Trim());

        var insertOrderQuery = $"""
        INSERT INTO [dbo].[Order] 
        (Order_Date, Order_Status, Shipping_Address_ID, Billing_Address_ID, Customer_ID, Total_Price)
        VALUES (GETDATE(), 'Delivered', {shippingAddressId}, {shippingAddressId}, {Login.User.Value}, {total})
    """;
        Program.DatabaseHandler.ExecuteQuery(insertOrderQuery);

        var getOrderIdQuery = $"""
        SELECT TOP 1 Order_ID 
        FROM [dbo].[Order]
        WHERE Customer_ID = {Login.User.Value}
        ORDER BY Order_ID DESC
    """;
        var orderResult = Program.DatabaseHandler.ExecuteQuery(getOrderIdQuery);
        var orderId = Convert.ToInt32(((DataTable)orderResult).Rows[0]["Order_ID"]);

        var cartIdQuery = $"SELECT Cart_ID FROM Cart WHERE Customer_ID = {Login.User.Value}";
        var cartResult = Program.DatabaseHandler.ExecuteQuery(cartIdQuery);
        var cartId = Convert.ToInt32(((DataTable)cartResult).Rows[0]["Cart_ID"]);

        var cartItemsQuery = $"""
        SELECT a.Product_ID, a.Quantity
        FROM Added_To a
        WHERE a.Cart_ID = {cartId}
    """;
        var itemsResult = Program.DatabaseHandler.ExecuteQuery(cartItemsQuery);
        var itemsTable = (DataTable)itemsResult;

        foreach (DataRow row in itemsTable.Rows)
        {
            var productId = Convert.ToInt32(row["Product_ID"]);
            var quantity = Convert.ToInt32(row["Quantity"]);

            var priceQuery = $"SELECT Price FROM Product WHERE Product_ID = {productId}";
            var priceResult = Program.DatabaseHandler.ExecuteQuery(priceQuery);
            var unitPrice = Convert.ToDecimal(((DataTable)priceResult).Rows[0]["Price"]);

            var insertOrderProductQuery = $"""
            INSERT INTO order_contains_product (Order_ID, Product_ID, Quantity, Unit_Price)
            VALUES ({orderId}, {productId}, {quantity}, {unitPrice})
        """;
            Program.DatabaseHandler.ExecuteQuery(insertOrderProductQuery);

            var updateStockQuery = $"""
            UPDATE Product
            SET Quantity_In_Stock = Quantity_In_Stock - {quantity}
            WHERE Product_ID = {productId}
        """;
            Program.DatabaseHandler.ExecuteQuery(updateStockQuery);
        }

        Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Added_To WHERE Cart_ID = {cartId}");
        Program.DatabaseHandler.ExecuteQuery($"DELETE FROM Cart WHERE Cart_ID = {cartId}");

        new ThankYou(_cart).ShowDialog();
        Close();
    }

    private static int GetAddressIdFromSelection(string addressLabelCity)
    {
        var parts = addressLabelCity.Split(',');
        var label = parts[0].Trim();
        var city = parts[1].Trim();

        var query = $"""
                     
                                     SELECT Address_ID FROM Customer_Address
                                     WHERE Customer_ID = {Login.User.Value} AND Label = '{label}' AND City = '{city}'
                                 
                     """;
        var result = Program.DatabaseHandler.ExecuteQuery(query);
        var addressTable = (DataTable)result;
        return Convert.ToInt32(addressTable.Rows[0]["Address_ID"]);
    }


    private void backButton_Click(object sender, EventArgs e) => Close();

    private void Checkout_Load(object sender, EventArgs e)
    {
        var paymentQuery = $"SELECT Card_Number, CardHolder_Name FROM Payment WHERE Customer_ID = {Login.User.Value}";
        var paymentResult = Program.DatabaseHandler.ExecuteQuery(paymentQuery);
        var paymentTable = (DataTable)paymentResult;

        foreach (DataRow row in paymentTable.Rows)
        {
            paymentMethodComboBox.Items.Add(row["CardHolder_Name"].ToString());
        }

        var addressQuery = $"SELECT Address_ID, Label, City FROM Customer_Address WHERE Customer_ID = {Login.User.Value}";
        var addressResult = Program.DatabaseHandler.ExecuteQuery(addressQuery);
        var addressTable = (DataTable)addressResult;

        foreach (DataRow row in addressTable.Rows)
        {
            ShippingAddressComboBox.Items.Add($"{row["Label"]}, {row["City"]}");
        }

        var totalQuery = $"""
                              SELECT SUM(p.Price * a.Quantity) AS Total
                              FROM Cart c
                              JOIN Added_To a ON c.Cart_ID = a.Cart_ID
                              JOIN Product p ON a.Product_ID = p.Product_ID
                              WHERE c.Customer_ID = {Login.User.Value}
                          """;

        var totalResult = Program.DatabaseHandler.ExecuteQuery(totalQuery);
        var totalTable = (DataTable)totalResult;

        if (totalTable.Rows.Count > 0 && totalTable.Rows[0]["Total"] != DBNull.Value)
        {
            totalPriceLabel.Text += totalTable.Rows[0]["Total"].ToString();
        }
        else
        {
            totalPriceLabel.Text += "0.00";
        }
    }
}