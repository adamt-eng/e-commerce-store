using System;
using System.Data;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

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

        foreach (DataRow row in ((DataTable)Program.DatabaseHandler.ExecuteQuery(query)).Rows)
        {
            _products.ImportRow(row);
        }

        productsDataGridView.DataSource = _products;
    }

    private void searchForProductsTextBox_TextChanged(object sender, EventArgs e)
    {
        var productView = _products.DefaultView;
        productView.RowFilter = string.Format("Description LIKE '%{0}%' OR Category_Name LIKE '%{0}%'", searchForProductsTextBox.Text.ToLower());

        productsDataGridView.DataSource = productView;
    }

    private void myProfileButton_Click(object sender, EventArgs e) => new MyProfile().ShowDialog();

    private void cartButton_Click(object sender, EventArgs e)
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
            MessageBox.Show("Your cart is empty.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


    private void productsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        try
        {
            new ProductView(int.Parse(productsDataGridView.Rows[e.RowIndex].Cells["Product_ID"].Value.ToString())).ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load product. Error: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CustomerPage_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
}