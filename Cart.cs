using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class Cart : Form
{
    internal int CartId;

    internal Cart(int cartId)
    {
        InitializeComponent();
        CartId = cartId;
    }

    private void Cart_Load(object sender, EventArgs e)
    {
        Program.DatabaseHandler.ExecuteQuery($"""
                                              UPDATE Cart
                                              SET Cart_Expiry_Date = DATEADD(DAY, 7, GETDATE())
                                              WHERE Cart_ID = {CartId}
                                              """);

        var query = $"""
                     SELECT 
                         at.Product_ID,
                         p.Product_Name AS Item,
                         p.Price,
                         at.Quantity,
                         at.Quantity * p.Price AS Total
                     FROM 
                         Added_To at
                     JOIN 
                         Product p ON at.Product_ID = p.Product_ID
                     WHERE 
                         at.Cart_ID = {CartId}
                     """;

        CartTable.DataSource = (DataTable)(Program.DatabaseHandler.ExecuteQuery(query));
        TotalPriceLabel.Text = $"Total: ${Convert.ToDecimal(((DataTable)Program.DatabaseHandler.ExecuteQuery($"SELECT SUM(p.Price * at.Quantity) AS TotalPrice FROM Added_To at JOIN Product p ON at.Product_ID = p.Product_ID WHERE at.Cart_ID = {CartId}")).Rows[0]["TotalPrice"])}";
    }

    private void backToHomePageButton_Click(object sender, EventArgs e)
    {
        Login.MainForm.Show();
        Close();
    }

    private void proceedToCheckoutButton_Click(object sender, EventArgs e)
    {
        Close();
        new Checkout().ShowDialog();
    }
}
