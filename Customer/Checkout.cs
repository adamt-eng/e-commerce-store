using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

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

        var parts = ShippingAddressComboBox.SelectedItem.ToString().Split(',');
        var query = $"""
                     
                                     SELECT Address_ID FROM Customer_Address
                                     WHERE Customer_ID = {Login.User.Value} AND Label = '{parts[0].Trim()}' AND City = '{parts[1].Trim()}'
                                 
                     """;

        var shippingAddressId = Convert.ToInt32(((DataTable)Program.DatabaseHandler.ExecuteQuery(query)).Rows[0]["Address_ID"]);
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

        var cartResult = Program.DatabaseHandler.ExecuteQuery($"SELECT Cart_ID FROM Cart WHERE Customer_ID = {Login.User.Value}");
        var cartId = Convert.ToInt32(((DataTable)cartResult).Rows[0]["Cart_ID"]);

        var cartItemsQuery = $"""
                                  SELECT a.Product_ID, a.Quantity
                                  FROM Added_To a
                                  WHERE a.Cart_ID = {cartId}
                              """;

        foreach (DataRow row in ((DataTable)Program.DatabaseHandler.ExecuteQuery(cartItemsQuery)).Rows)
        {
            var productId = Convert.ToInt32(row["Product_ID"]);
            var quantity = Convert.ToInt32(row["Quantity"]);

            var priceResult = Program.DatabaseHandler.ExecuteQuery($"SELECT Price FROM Product WHERE Product_ID = {productId}");
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

    private void backButton_Click(object sender, EventArgs e) => Close();

    private void Checkout_Load(object sender, EventArgs e)
    {
        var flag = false;

        foreach (DataRow row in ((DataTable)Program.DatabaseHandler.ExecuteQuery($"SELECT Card_Number, CardHolder_Name FROM Payment WHERE Customer_ID = {Login.User.Value}")).Rows)
        {
            paymentMethodComboBox.Items.Add(row["CardHolder_Name"].ToString());
            flag = true;
        }

        if (flag)
        {
            paymentMethodComboBox.SelectedIndex = 0;
        }
        
        flag = false;

        foreach (DataRow row in ((DataTable)Program.DatabaseHandler.ExecuteQuery($"SELECT Address_ID, Label, City FROM Customer_Address WHERE Customer_ID = {Login.User.Value}")).Rows)
        {
            ShippingAddressComboBox.Items.Add($"{row["Label"]}, {row["City"]}");
            flag = true;
        }

        if (flag)
        {
            ShippingAddressComboBox.SelectedIndex = 0;
        }

        var query = $"""
                         SELECT SUM(p.Price * a.Quantity) AS Total
                         FROM Cart c
                         JOIN Added_To a ON c.Cart_ID = a.Cart_ID
                         JOIN Product p ON a.Product_ID = p.Product_ID
                         WHERE c.Customer_ID = {Login.User.Value}
                     """;
        var totalTable = (DataTable)(Program.DatabaseHandler.ExecuteQuery(query));

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