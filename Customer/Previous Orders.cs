using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using E_Commerce_Store.Common;

namespace E_Commerce_Store.Customer;

internal partial class PreviousOrders : Form
{
    private readonly DataTable _orders = new();
    private readonly DataTable _orderDetails = new();

    internal PreviousOrders() => InitializeComponent();

    private void PreviousOrders_Load(object sender, EventArgs e)
    {
        _orders.Columns.Add("Order_ID");
        _orders.Columns.Add("Order_Date");
        _orders.Columns.Add("Status");
        _orders.Columns.Add("Total");

        _orderDetails.Columns.Add("Order_ID");
        _orderDetails.Columns.Add("Product_ID");
        _orderDetails.Columns.Add("Description");
        _orderDetails.Columns.Add("Quantity");
        _orderDetails.Columns.Add("Unit_Price");
        _orderDetails.Columns.Add("Seller_Name");
        _orderDetails.Columns.Add("Category_Name");

        var query = $"""
                         SELECT 
                             o.Order_ID,
                             o.Order_Date,
                             o.Order_Status,
                             o.Total_Price,
                             p.Product_ID,
                             p.Product_Description AS Description,
                             ocp.Quantity,
                             ocp.Unit_Price,
                             s.Seller_Name,
                             c.Category_Name
                         FROM 
                             [dbo].[Order] o
                         JOIN 
                             order_contains_product ocp ON o.Order_ID = ocp.Order_ID
                         JOIN 
                             Product p ON ocp.Product_ID = p.Product_ID
                         JOIN 
                             Seller s ON p.Seller_ID = s.Seller_ID
                         JOIN 
                             Category c ON p.Category_ID = c.Category_ID
                         WHERE 
                             o.Customer_ID = {Login.User.Value}
                         ORDER BY 
                             o.Order_Date DESC
                     """;

        var table = (DataTable)Program.DatabaseHandler.ExecuteQuery(query);

        var orderIds = _orders.AsEnumerable().Select(r => r["Order_ID"]).ToHashSet();

        foreach (DataRow row in table.Rows)
        {
            var orderId = row["Order_ID"].ToString();

            if (!orderIds.Contains(orderId))
            {
                _orders.Rows.Add(
                    row["Order_ID"],
                    ((DateTime)row["Order_Date"]).ToString("yyyy-MM-dd"),
                    row["Order_Status"],
                    row["Total_Price"]
                );
                orderIds.Add(orderId);
            }

            _orderDetails.Rows.Add(
                row["Order_ID"],
                row["Product_ID"],
                row["Description"],
                row["Quantity"],
                row["Unit_Price"],
                row["Seller_Name"],
                row["Category_Name"]
            );
        }

        ordersGridView.DataSource = _orders;
        ordersGridView.SelectionChanged += OrdersGridView_SelectionChanged;

        if (ordersGridView.Rows.Count > 0)
        {
            ordersGridView.Rows[0].Selected = true;
        }
    }

    private void OrdersGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (ordersGridView.SelectedRows.Count != 0)
        {
            detailsGridView.DataSource = new DataView(_orderDetails)
            {
                RowFilter = $"Order_ID = '{ordersGridView.SelectedRows[0].Cells["Order_ID"].Value.ToString()}'"
            };
        }
    }
}
