using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class SellerPage : Form
{
    private readonly DataTable _products = new ();

    internal SellerPage() => InitializeComponent();

    private void AdminPage_Load(object sender, EventArgs e)
    {


        // Define Products table
        _products.Columns.Add("Product_ID");
        _products.Columns.Add("Description");
        _products.Columns.Add("Status");
        _products.Columns.Add("Published_At");
        _products.Columns.Add("Price");
        _products.Columns.Add("Category_Name");  // Foreign Key

        //show
        dataGridView1.DataSource = _products;
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void DeleteButton_Click_1(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count != 0)
        {
            var selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            _products.Rows.RemoveAt(selectedRowIndex);
            //delete-SQL
        }
        else
        {
            MessageBox.Show("Please select a full row to delete.");
        }
    }

    private void AddButton_Click_1(object sender, EventArgs e)
    {
        var addProduct = new AddProduct();
        addProduct.ShowDialog();
    }
}

