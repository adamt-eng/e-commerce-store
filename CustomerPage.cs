using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class CustomerPage : Form
{
    internal CustomerPage() => InitializeComponent();

    private readonly DataTable _products = new();

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

        LoadProducts();
    }

    internal void LoadProducts()
    {
        var query = """
                    SELECT 
                        p.Product_ID, 
                        p.Product_Name,
                        p.Product_Description AS Description, 
                        p.Quantity_In_Stock AS Quantity,
                        p.Published_At, 
                        p.Price, 
                        s.Seller_Name, 
                        c.Category_Name
                    FROM 
                        Product p
                    LEFT JOIN 
                        Category c ON p.Category_ID = c.Category_ID
                    INNER JOIN 
                        Seller s ON p.Seller_ID = s.Seller_ID
                    WHERE
                        p.Quantity_In_Stock > 0
                    """;

        var result = Program.DatabaseHandler.ExecuteQuery(query);

        foreach (DataRow row in ((DataTable)result).Rows) _products.ImportRow(row);

        dataGridView1.DataSource = _products;
    }

    private void searchForProductsTextBox_TextChanged(object sender, EventArgs e)
    {
        var searchTerm = searchForProductsTextBox.Text.ToLower();

        var productView = _products.DefaultView;
        productView.RowFilter = string.Format("Description LIKE '%{0}%' OR Category_Name LIKE '%{0}%'", searchTerm);

        dataGridView1.DataSource = productView;
    }

    private void myProfileButton_Click(object sender, EventArgs e)
    {
        Hide();
        new MyProfile().ShowDialog();
        Show();
    }

    private void cartButton_Click(object sender, EventArgs e)
    {
        var query = $"""
                     
                             SELECT c.Cart_ID 
                             FROM Cart c
                             INNER JOIN Added_To at ON c.Cart_ID = at.Cart_ID
                             WHERE c.Customer_ID = {Login.User.Value} 
                         
                     """;

        var result = Program.DatabaseHandler.ExecuteQuery(query);
        var cartTable = (DataTable)result;

        if (cartTable.Rows.Count > 0)
        {
            var cartId = Convert.ToInt32(cartTable.Rows[0]["Cart_ID"]);
            Hide();
            new Cart(cartId).ShowDialog();
            Show();
        }
        else
        {
            MessageBox.Show("Your cart is empty or doesn't exist. Please add products to your cart.");
        }
    }


    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        try
        {
            new ProductView(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Product_ID"].Value.ToString())).ShowDialog();
        }
        catch
        {
            // ignored
        }
    }
}