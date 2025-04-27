using System;
using System.Data;
using System.Windows.Forms;

namespace E_Commerce_Store;

internal partial class SellerPage : Form
{
  
    DataTable products = new DataTable();
   
    internal SellerPage() => InitializeComponent();

    private void AdminPage_Load(object sender, EventArgs e)
    {
     

        // Define Products table
        products.Columns.Add("Product_ID");
        products.Columns.Add("Description");
        products.Columns.Add("Status");
        products.Columns.Add("Published_At");
        products.Columns.Add("Price");
        products.Columns.Add("Category_Name");  // Foreign Key

        //populate-SQL
        products.Rows.Add("P001", "Gaming Laptop", "Available", "2024-01-01", "1500.00",  "Electronics");
        products.Rows.Add("P002", "Smartphone", "Available", "2024-02-15", "800.00", "Electronics");

        //show
        dataGridView1.DataSource = products;
    }


    

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }


    private void DeleteButton_Click_1(object sender, EventArgs e)
    {
        if(!(dataGridView1.SelectedRows.Count == 0)) {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            products.Rows.RemoveAt(selectedRowIndex);

            //delete-SQL


        }

        else
        {
            MessageBox.Show("Please select a full row to delete.");
        }
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
       //show dialogue box
    }
}

