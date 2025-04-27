using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace E_Commerce_Store;

public class DatabaseHandler(string connectionString)
{
    private readonly SqlConnection _sqlConnection = new(connectionString);

    public object ExecuteQuery(string query)
    {
        _sqlConnection.Open();
        var cmd = new SqlCommand(query, _sqlConnection);
        cmd.CommandType = CommandType.Text;

        // Determine the type of SQL statement and act accordingly
        if (query.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
        {
            // For SELECT, return the data as a DataTable
            var reader = cmd.ExecuteReader();
            var resultTable = new DataTable();
            resultTable.Load(reader);
            reader.Close();
            _sqlConnection.Close();
            return resultTable;
        }

        if (query.Trim().StartsWith("INSERT", StringComparison.OrdinalIgnoreCase) ||
            query.Trim().StartsWith("DELETE", StringComparison.OrdinalIgnoreCase) ||
            query.Trim().StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase))
        {
            // For INSERT, DELETE, or UPDATE, execute the query and return the number of affected rows
            var rowsAffected = cmd.ExecuteNonQuery();
            _sqlConnection.Close();
            return rowsAffected;
        }

        _sqlConnection.Close();
        throw new InvalidOperationException("Unsupported SQL query type.");
    }
}

internal static class Program
{
    internal static SqlConnection SqlConnection =
        new(
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\adamt\\Desktop\\E commerce store.mdf\";Integrated Security=True;Connect Timeout=30");

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        LoadAdminTable();
        LoadCategoryTable();
        LoadSellerTable();
        LoadCustomerTable();
        LoadCustomerAddressTable();
        LoadPaymentTable();
        LoadProductTable();
        LoadOrderTable();
        LoadCartTable();
        LoadProductManagesTable();
        LoadCategoryManagesTable();
        LoadOrderContainsProductTable();
        LoadAddedToTable();

        Application.Run(new Login());
    }

    private static void LoadAdminTable()
    {
        SqlConnection.Open();
        var cmd = new SqlCommand("SELECT Admin_ID, Admin_Name, Admin_Email, Phone_Number FROM Admin", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblAdmin = new DataTable();
        tblAdmin.Columns.Add("Admin ID");
        tblAdmin.Columns.Add("Name");
        tblAdmin.Columns.Add("Email");
        tblAdmin.Columns.Add("Phone");

        while (reader.Read())
        {
            var row = tblAdmin.NewRow();
            row["Admin ID"] = reader["Admin_ID"].ToString();
            row["Name"] = reader["Admin_Name"].ToString();
            row["Email"] = reader["Admin_Email"].ToString();
            row["Phone"] = reader["Phone_Number"].ToString();
            tblAdmin.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadCategoryTable()
    {
        SqlConnection.Open();
        var cmd = new SqlCommand("SELECT Category_ID, Category_Name, Category_Description FROM Category", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblCategory = new DataTable();
        tblCategory.Columns.Add("Category ID");
        tblCategory.Columns.Add("Name");
        tblCategory.Columns.Add("Description");

        while (reader.Read())
        {
            var row = tblCategory.NewRow();
            row["Category ID"] = reader["Category_ID"].ToString();
            row["Name"] = reader["Category_Name"].ToString();
            row["Description"] = reader["Category_Description"].ToString();
            tblCategory.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadSellerTable()
    {
        SqlConnection.Open();
        var cmd =
            new SqlCommand("SELECT Seller_ID, Seller_Name, Seller_Email, Phone_Number, Seller_Address FROM Seller",
                SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblSeller = new DataTable();
        tblSeller.Columns.Add("Seller ID");
        tblSeller.Columns.Add("Name");
        tblSeller.Columns.Add("Email");
        tblSeller.Columns.Add("Phone");
        tblSeller.Columns.Add("Address");

        while (reader.Read())
        {
            var row = tblSeller.NewRow();
            row["Seller ID"] = reader["Seller_ID"].ToString();
            row["Name"] = reader["Seller_Name"].ToString();
            row["Email"] = reader["Seller_Email"].ToString();
            row["Phone"] = reader["Phone_Number"].ToString();
            row["Address"] = reader["Seller_Address"].ToString();
            tblSeller.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadCustomerTable()
    {
        SqlConnection.Open();
        var cmd =
            new SqlCommand(
                "SELECT Customer_ID, First_Name, Last_Name, Email, Phone_Number, Date_Of_Birth FROM Customer", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblCustomer = new DataTable();
        tblCustomer.Columns.Add("Customer ID");
        tblCustomer.Columns.Add("First Name");
        tblCustomer.Columns.Add("Last Name");
        tblCustomer.Columns.Add("Email");
        tblCustomer.Columns.Add("Phone");
        tblCustomer.Columns.Add("DOB");

        while (reader.Read())
        {
            var row = tblCustomer.NewRow();
            row["Customer ID"] = reader["Customer_ID"].ToString();
            row["First Name"] = reader["First_Name"].ToString();
            row["Last Name"] = reader["Last_Name"].ToString();
            row["Email"] = reader["Email"].ToString();
            row["Phone"] = reader["Phone_Number"].ToString();
            row["DOB"] = reader["Date_Of_Birth"].ToString();
            tblCustomer.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadCustomerAddressTable()
    {
        SqlConnection.Open();
        var cmd =
            new SqlCommand("SELECT Address_ID, Customer_ID, Label, City, Address_Description FROM Customer_Address",
                SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblCustomerAddress = new DataTable();
        tblCustomerAddress.Columns.Add("Address ID");
        tblCustomerAddress.Columns.Add("Customer ID");
        tblCustomerAddress.Columns.Add("Label");
        tblCustomerAddress.Columns.Add("City");
        tblCustomerAddress.Columns.Add("Address Description");

        while (reader.Read())
        {
            var row = tblCustomerAddress.NewRow();
            row["Address ID"] = reader["Address_ID"].ToString();
            row["Customer ID"] = reader["Customer_ID"].ToString();
            row["Label"] = reader["Label"].ToString();
            row["City"] = reader["City"].ToString();
            row["Address Description"] = reader["Address_Description"].ToString();
            tblCustomerAddress.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadPaymentTable()
    {
        SqlConnection.Open();
        var cmd =
            new SqlCommand("SELECT Card_Number, CardHolder_Name, Card_Expiry_Date, Customer_ID FROM Payment", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblPayment = new DataTable();
        tblPayment.Columns.Add("Card Number");
        tblPayment.Columns.Add("Holder Name");
        tblPayment.Columns.Add("Expiry Date");
        tblPayment.Columns.Add("Customer ID");

        while (reader.Read())
        {
            var row = tblPayment.NewRow();
            row["Card Number"] = reader["Card_Number"].ToString();
            row["Holder Name"] = reader["CardHolder_Name"].ToString();
            row["Expiry Date"] = reader["Card_Expiry_Date"].ToString();
            row["Customer ID"] = reader["Customer_ID"].ToString();
            tblPayment.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadProductTable()
    {
        SqlConnection.Open();
        var cmd =
            new SqlCommand(
                "SELECT Product_ID, Product_Name, Price, Quantity_In_Stock, Category_ID, Seller_ID FROM Product", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblProduct = new DataTable();
        tblProduct.Columns.Add("Product ID");
        tblProduct.Columns.Add("Name");
        tblProduct.Columns.Add("Price");
        tblProduct.Columns.Add("Quantity");
        tblProduct.Columns.Add("Category ID");
        tblProduct.Columns.Add("Seller ID");

        while (reader.Read())
        {
            var row = tblProduct.NewRow();
            row["Product ID"] = reader["Product_ID"].ToString();
            row["Name"] = reader["Product_Name"].ToString();
            row["Price"] = reader["Price"].ToString();
            row["Quantity"] = reader["Quantity_In_Stock"].ToString();
            row["Category ID"] = reader["Category_ID"].ToString();
            row["Seller ID"] = reader["Seller_ID"].ToString();
            tblProduct.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadOrderTable()
    {
        SqlConnection.Open();
        var cmd =
            new SqlCommand(
                "SELECT Order_ID, Order_Date, Order_Status, Shipping_Address_ID, Billing_Address_ID, Customer_ID, Total_Price FROM [Order]",
                SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblOrder = new DataTable();
        tblOrder.Columns.Add("Order ID");
        tblOrder.Columns.Add("Order Date");
        tblOrder.Columns.Add("Status");
        tblOrder.Columns.Add("Shipping Address ID");
        tblOrder.Columns.Add("Billing Address ID");
        tblOrder.Columns.Add("Customer ID");
        tblOrder.Columns.Add("Total Price");

        while (reader.Read())
        {
            var row = tblOrder.NewRow();
            row["Order ID"] = reader["Order_ID"].ToString();
            row["Order Date"] = reader["Order_Date"].ToString();
            row["Status"] = reader["Order_Status"].ToString();
            row["Shipping Address ID"] = reader["Shipping_Address_ID"].ToString();
            row["Billing Address ID"] = reader["Billing_Address_ID"].ToString();
            row["Customer ID"] = reader["Customer_ID"].ToString();
            row["Total Price"] = reader["Total_Price"].ToString();
            tblOrder.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadCartTable()
    {
        SqlConnection.Open();
        var cmd = new SqlCommand("SELECT Cart_ID, Customer_ID, Cart_Expiry_Date, Total_Price FROM Cart", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblCart = new DataTable();
        tblCart.Columns.Add("Cart ID");
        tblCart.Columns.Add("Customer ID");
        tblCart.Columns.Add("Expiry Date");
        tblCart.Columns.Add("Total Price");

        while (reader.Read())
        {
            var row = tblCart.NewRow();
            row["Cart ID"] = reader["Cart_ID"].ToString();
            row["Customer ID"] = reader["Customer_ID"].ToString();
            row["Expiry Date"] = reader["Cart_Expiry_Date"].ToString();
            row["Total Price"] = reader["Total_Price"].ToString();
            tblCart.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadProductManagesTable()
    {
        SqlConnection.Open();
        var cmd = new SqlCommand("SELECT Product_ID, Admin_ID FROM Product_Manages", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblProductManages = new DataTable();
        tblProductManages.Columns.Add("Product ID");
        tblProductManages.Columns.Add("Admin ID");

        while (reader.Read())
        {
            var row = tblProductManages.NewRow();
            row["Product ID"] = reader["Product_ID"].ToString();
            row["Admin ID"] = reader["Admin_ID"].ToString();
            tblProductManages.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadCategoryManagesTable()
    {
        SqlConnection.Open();
        var cmd = new SqlCommand("SELECT Category_ID, Admin_ID FROM Category_Manages", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblCategoryManages = new DataTable();
        tblCategoryManages.Columns.Add("Category ID");
        tblCategoryManages.Columns.Add("Admin ID");

        while (reader.Read())
        {
            var row = tblCategoryManages.NewRow();
            row["Category ID"] = reader["Category_ID"].ToString();
            row["Admin ID"] = reader["Admin_ID"].ToString();
            tblCategoryManages.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadOrderContainsProductTable()
    {
        SqlConnection.Open();
        var cmd = new SqlCommand("SELECT Order_ID, Product_ID, Quantity, Unit_Price FROM order_contains_product",
            SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblOrderContains = new DataTable();
        tblOrderContains.Columns.Add("Order ID");
        tblOrderContains.Columns.Add("Product ID");
        tblOrderContains.Columns.Add("Quantity");
        tblOrderContains.Columns.Add("Unit Price");

        while (reader.Read())
        {
            var row = tblOrderContains.NewRow();
            row["Order ID"] = reader["Order_ID"].ToString();
            row["Product ID"] = reader["Product_ID"].ToString();
            row["Quantity"] = reader["Quantity"].ToString();
            row["Unit Price"] = reader["Unit_Price"].ToString();
            tblOrderContains.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }

    private static void LoadAddedToTable()
    {
        SqlConnection.Open();
        var cmd = new SqlCommand("SELECT Cart_ID, Product_ID, Quantity FROM Added_To", SqlConnection);
        cmd.CommandType = CommandType.Text;

        var reader = cmd.ExecuteReader();
        var tblAddedTo = new DataTable();
        tblAddedTo.Columns.Add("Cart ID");
        tblAddedTo.Columns.Add("Product ID");
        tblAddedTo.Columns.Add("Quantity");

        while (reader.Read())
        {
            var row = tblAddedTo.NewRow();
            row["Cart ID"] = reader["Cart_ID"].ToString();
            row["Product ID"] = reader["Product_ID"].ToString();
            row["Quantity"] = reader["Quantity"].ToString();
            tblAddedTo.Rows.Add(row);
        }

        reader.Close();
        SqlConnection.Close();
    }
}