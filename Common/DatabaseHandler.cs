using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace E_Commerce_Store.Common;

internal class DatabaseHandler(string connectionString)
{
    private readonly SqlConnection _sqlConnection = new(connectionString);

    internal object ExecuteQuery(string query)
    {
        _sqlConnection.Open();

        query = query.Trim();

        var sqlCommand = new SqlCommand(query, _sqlConnection) { CommandType = CommandType.Text };

        if (query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
        {
            var reader = sqlCommand.ExecuteReader();
            var resultTable = new DataTable();
            resultTable.Load(reader);
            reader.Close();
            _sqlConnection.Close();
            return resultTable;
        }

        if (query.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase) ||
            query.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase) ||
            query.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) ||
            query.StartsWith("sp_", StringComparison.OrdinalIgnoreCase) ||
            query.StartsWith("IF", StringComparison.OrdinalIgnoreCase) ||
            query.StartsWith("CREATE", StringComparison.OrdinalIgnoreCase))
        {
            var rowsAffected = sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            return rowsAffected;
        }

        _sqlConnection.Close();
        throw new InvalidOperationException("Query syntax incorrect.");
    }

    // Method to execute stored procedures with parameters
    internal void ExecuteParametrizedStoredProcedure(string procedureName, SqlParameter[] parameters)
    {
        _sqlConnection.Open();

        using (var command = new SqlCommand(procedureName, _sqlConnection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();
        }

        _sqlConnection.Close();
    }

    internal void ValidateDatabase()
    {
        try
        {
            CheckTableExistenceAndCreate("Customer", """
                                                     
                                                                 CREATE TABLE [dbo].[Customer] (
                                                                     [Customer_ID]   INT           IDENTITY (1, 1) NOT NULL,
                                                                     [First_Name]    VARCHAR (50)  NOT NULL,
                                                                     [Last_Name]     VARCHAR (50)  NOT NULL,
                                                                     [Email]         VARCHAR (100) COLLATE Latin1_General_CS_AS NOT NULL,
                                                                     [Pass_Hashed]   VARCHAR (64)  COLLATE Latin1_General_CS_AS NOT NULL,
                                                                     [Phone_Number]  VARCHAR (20)  NULL,
                                                                     [Date_Of_Birth] DATE          NULL,
                                                                     [Created_On]    DATETIME      DEFAULT (getdate()) NULL,
                                                                     PRIMARY KEY CLUSTERED ([Customer_ID] ASC),
                                                                     UNIQUE NONCLUSTERED ([Email] ASC)
                                                                 )
                                                             
                                                     """);

            CheckTableExistenceAndCreate("Cart", """
                                                 
                                                             CREATE TABLE [dbo].[Cart] (
                                                                 [Cart_ID]          INT             IDENTITY (1, 1) NOT NULL,
                                                                 [Customer_ID]      INT             NOT NULL,
                                                                 [Cart_Expiry_Date] DATETIME        NULL,
                                                                 [Total_Price]      DECIMAL (10, 2) DEFAULT ((0)) NULL,
                                                                 PRIMARY KEY CLUSTERED ([Cart_ID] ASC),
                                                                 UNIQUE NONCLUSTERED ([Customer_ID] ASC),
                                                                 FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer] ([Customer_ID])
                                                             )
                                                         
                                                 """);

            CheckTableExistenceAndCreate("Category", """
                                                     
                                                                 CREATE TABLE [dbo].[Category] (
                                                                     [Category_ID]          INT            IDENTITY (1, 1) NOT NULL,
                                                                     [Category_Name]        VARCHAR (100)  NOT NULL,
                                                                     [Category_Description] VARCHAR (1500) NULL,
                                                                     PRIMARY KEY CLUSTERED ([Category_ID] ASC)
                                                                 )
                                                             
                                                     """);

            CheckTableExistenceAndCreate("Seller", """
                                                   
                                                               CREATE TABLE [dbo].[Seller] (
                                                                   [Seller_ID]      INT           IDENTITY (1, 1) NOT NULL,
                                                                   [Seller_Name]    VARCHAR (100) NOT NULL,
                                                                   [Seller_Email]   VARCHAR (100) COLLATE Latin1_General_CS_AS NOT NULL,
                                                                   [Pass_Hashed]    VARCHAR (64)  COLLATE Latin1_General_CS_AS NOT NULL,
                                                                   [Phone_Number]   VARCHAR (20)  NULL,
                                                                   [Seller_Address] VARCHAR (255) NULL,
                                                                   PRIMARY KEY CLUSTERED ([Seller_ID] ASC),
                                                                   UNIQUE NONCLUSTERED ([Seller_Email] ASC)
                                                               )
                                                           
                                                   """);

            CheckTableExistenceAndCreate("Product", """
                                                    
                                                                CREATE TABLE [dbo].[Product] (
                                                                    [Product_ID]          INT             IDENTITY (1, 1) NOT NULL,
                                                                    [Product_Name]        VARCHAR (100)   NOT NULL,
                                                                    [Price]               DECIMAL (10, 2) NOT NULL,
                                                                    [Product_Description] VARCHAR (MAX)   NULL,
                                                                    [Quantity_In_Stock]   INT             DEFAULT ((0)) NOT NULL,
                                                                    [Published_At]        DATETIME        DEFAULT (getdate()) NULL,
                                                                    [Category_ID]         INT             NULL,
                                                                    [Seller_ID]           INT             NOT NULL,
                                                                    [Image_Link]          VARCHAR (2048)  NOT NULL,
                                                                    PRIMARY KEY CLUSTERED ([Product_ID] ASC),
                                                                    FOREIGN KEY ([Seller_ID]) REFERENCES [dbo].[Seller] ([Seller_ID]),
                                                                    FOREIGN KEY ([Category_ID]) REFERENCES [dbo].[Category] ([Category_ID]),
                                                                    CHECK ([Price] > (0)),
                                                                    CHECK ([Quantity_In_Stock] >= (0))
                                                                )
                                                            
                                                    """);

            CheckTableExistenceAndCreate("Added_To", """
                                                     
                                                                 CREATE TABLE [dbo].[Added_To] (
                                                                     [Cart_ID]    INT NOT NULL,
                                                                     [Product_ID] INT NOT NULL,
                                                                     [Quantity]   INT NOT NULL,
                                                                     PRIMARY KEY CLUSTERED ([Cart_ID] ASC, [Product_ID] ASC),
                                                                     FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product] ([Product_ID]),
                                                                     FOREIGN KEY ([Cart_ID]) REFERENCES [dbo].[Cart] ([Cart_ID]),
                                                                     CHECK ([Quantity] > (0))
                                                                 )
                                                             
                                                     """);

            CheckTableExistenceAndCreate("Admin", """
                                                  
                                                              CREATE TABLE [dbo].[Admin] (
                                                                  [Admin_ID]     INT           IDENTITY (1, 1) NOT NULL,
                                                                  [Admin_Name]   VARCHAR (100) NOT NULL,
                                                                  [Admin_Email]  VARCHAR (100) COLLATE Latin1_General_CS_AS NOT NULL,
                                                                  [Pass_Hashed]  VARCHAR (64)  COLLATE Latin1_General_CS_AS NOT NULL,
                                                                  [Phone_Number] VARCHAR (20)  NULL,
                                                                  PRIMARY KEY CLUSTERED ([Admin_ID] ASC),
                                                                  UNIQUE NONCLUSTERED ([Admin_Email] ASC)
                                                              )
                                                          
                                                  """);

            CheckTableExistenceAndCreate("Customer_Address", """
                                                             
                                                                         CREATE TABLE [dbo].[Customer_Address] (
                                                                             [Address_ID]          INT            IDENTITY (1, 1) NOT NULL,
                                                                             [Customer_ID]         INT            NOT NULL,
                                                                             [Label]               NVARCHAR (50)  NOT NULL,
                                                                             [City]                NVARCHAR (100) NOT NULL,
                                                                             [Address_Description] NVARCHAR (255) NOT NULL,
                                                                             PRIMARY KEY CLUSTERED ([Address_ID] ASC, [Customer_ID] ASC),
                                                                             FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer] ([Customer_ID])
                                                                         )
                                                                     
                                                             """);

            CheckTableExistenceAndCreate("Order", """
                                                  
                                                              CREATE TABLE [dbo].[Order] (
                                                                  [Order_ID]            INT             IDENTITY (1, 1) NOT NULL,
                                                                  [Order_Date]          DATETIME        DEFAULT (getdate()) NULL,
                                                                  [Order_Status]        NVARCHAR (50)   DEFAULT ('Pending') NOT NULL,
                                                                  [Shipping_Address_ID] INT             NOT NULL,
                                                                  [Billing_Address_ID]  INT             NOT NULL,
                                                                  [Customer_ID]         INT             NOT NULL,
                                                                  [Total_Price]         DECIMAL (10, 2) NOT NULL,
                                                                  PRIMARY KEY CLUSTERED ([Order_ID] ASC),
                                                                  FOREIGN KEY ([Shipping_Address_ID], [Customer_ID]) REFERENCES [dbo].[Customer_Address] ([Address_ID], [Customer_ID]),
                                                                  FOREIGN KEY ([Billing_Address_ID], [Customer_ID]) REFERENCES [dbo].[Customer_Address] ([Address_ID], [Customer_ID]),
                                                                  FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer] ([Customer_ID]),
                                                                  CHECK ([Order_Status] = 'Cancelled' OR [Order_Status] = 'Delivered' OR [Order_Status] = 'Shipped' OR [Order_Status] = 'Processing' OR [Order_Status] = 'Pending'),
                                                                  CHECK ([Total_Price] > (0))
                                                              )
                                                          
                                                  """);

            CheckTableExistenceAndCreate("order_contains_product", """
                                                                   
                                                                               CREATE TABLE [dbo].[order_contains_product] (
                                                                                   [Order_ID]   INT             NOT NULL,
                                                                                   [Product_ID] INT             NOT NULL,
                                                                                   [Quantity]   INT             NOT NULL,
                                                                                   [Unit_Price] DECIMAL (10, 2) NOT NULL,
                                                                                   PRIMARY KEY CLUSTERED ([Order_ID] ASC, [Product_ID] ASC),
                                                                                   FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product] ([Product_ID]),
                                                                                   FOREIGN KEY ([Order_ID]) REFERENCES [dbo].[Order] ([Order_ID]),
                                                                                   CHECK ([Quantity] > (0)),
                                                                                   CHECK ([Unit_Price] > (0))
                                                                               )
                                                                           
                                                                   """);

            CheckTableExistenceAndCreate("Payment", """
                                                    
                                                                CREATE TABLE [dbo].[Payment] (
                                                                    [Card_Number]      VARCHAR(20)  NOT NULL,
                                                                    [CardHolder_Name]  VARCHAR(100) NOT NULL,
                                                                    [Card_Expiry_Date] DATE         NOT NULL,
                                                                    [Customer_ID]      INT          NOT NULL,
                                                                    PRIMARY KEY CLUSTERED ([Customer_ID], [Card_Number]),
                                                                    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer]([Customer_ID])
                                                                )
                                                            
                                                    """);

            var spDeleteProductSql = """
                                     
                                         CREATE PROCEDURE [dbo].[sp_DeleteProduct]
                                             @Product_ID INT
                                         AS
                                         BEGIN
                                             DELETE FROM Product WHERE Product_ID = @Product_ID;
                                         END

                                     """;

            var fnGetPreviousOrdersSql = """
                                         
                                             CREATE FUNCTION [dbo].[fn_GetPreviousOrders]
                                                 (@CustomerId INT)
                                             RETURNS TABLE
                                             AS
                                             RETURN
                                             (
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
                                                     o.Customer_ID = @CustomerId
                                             );

                                         """;

            var fnGetTotalCartPriceSql = """
                                         
                                             CREATE FUNCTION [dbo].[fn_GetTotalCartPrice]
                                                 (@Customer_ID INT)
                                             RETURNS DECIMAL(18, 2)
                                             AS
                                             BEGIN
                                                 RETURN ISNULL((
                                                     SELECT SUM(p.Price * a.Quantity)
                                                     FROM Cart c
                                                     JOIN Added_To a ON c.Cart_ID = a.Cart_ID
                                                     JOIN Product p ON a.Product_ID = p.Product_ID
                                                     WHERE c.Customer_ID = @Customer_ID
                                                 ), 0);
                                             END

                                         """;

            var spPlaceOrderSql = """
                                  
                                      CREATE PROCEDURE [dbo].[sp_PlaceOrder]
                                          @Customer_ID INT,
                                          @Shipping_Label NVARCHAR(50),
                                          @Shipping_City NVARCHAR(100)
                                      AS
                                      BEGIN
                                          SET NOCOUNT ON;
                                  
                                          DECLARE @Address_ID INT,
                                                  @Total_Price DECIMAL(10, 2),
                                                  @Order_ID INT,
                                                  @Cart_ID INT;
                                  
                                          -- Get Address ID
                                          SELECT @Address_ID = Address_ID
                                          FROM Customer_Address
                                          WHERE Customer_ID = @Customer_ID AND Label = @Shipping_Label AND City = @Shipping_City;
                                  
                                          IF @Address_ID IS NULL
                                          BEGIN
                                              RETURN;
                                          END
                                  
                                          -- Get total price using function
                                          SELECT @Total_Price = dbo.fn_GetTotalCartPrice(@Customer_ID);
                                  
                                          IF @Total_Price <= 0
                                          BEGIN
                                              RETURN;
                                          END
                                  
                                          -- Get Cart_ID
                                          SELECT @Cart_ID = Cart_ID FROM Cart WHERE Customer_ID = @Customer_ID;
                                  
                                          IF @Cart_ID IS NULL
                                          BEGIN
                                              RETURN;
                                          END
                                  
                                          -- Insert order
                                          INSERT INTO [Order] (Order_Date, Shipping_Address_ID, Billing_Address_ID, Customer_ID, Total_Price)
                                          VALUES (GETDATE(), @Address_ID, @Address_ID, @Customer_ID, @Total_Price);
                                  
                                          SET @Order_ID = SCOPE_IDENTITY();
                                  
                                          -- Insert into order_contains_product and update stock
                                          INSERT INTO order_contains_product (Order_ID, Product_ID, Quantity, Unit_Price)
                                          SELECT 
                                              @Order_ID,
                                              a.Product_ID,
                                              a.Quantity,
                                              p.Price
                                          FROM Added_To a
                                          JOIN Product p ON a.Product_ID = p.Product_ID
                                          WHERE a.Cart_ID = @Cart_ID;
                                  
                                          -- Update stock
                                          UPDATE p
                                          SET Quantity_In_Stock = Quantity_In_Stock - a.Quantity
                                          FROM Product p
                                          JOIN Added_To a ON p.Product_ID = a.Product_ID
                                          WHERE a.Cart_ID = @Cart_ID;
                                  
                                          -- Delete from Added_To and Cart
                                          DELETE FROM Added_To WHERE Cart_ID = @Cart_ID;
                                          DELETE FROM Cart WHERE Cart_ID = @Cart_ID;
                                      END

                                  """;

            CheckProcFuncExistenceAndCreate("sp_DeleteProduct", spDeleteProductSql);
            CheckProcFuncExistenceAndCreate("sp_PlaceOrder", spPlaceOrderSql);
            CheckProcFuncExistenceAndCreate("fn_GetPreviousOrders", fnGetPreviousOrdersSql);
            CheckProcFuncExistenceAndCreate("fn_GetTotalCartPrice", fnGetTotalCartPriceSql);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error validating database: {ex.Message}", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CheckProcFuncExistenceAndCreate(string name, string sql)
    {
        var checkExistenceQuery = $"SELECT OBJECT_ID('dbo.{name}')";

        var existedBefore = ExecuteScalar(checkExistenceQuery) is not (DBNull or null);

        ExecuteQuery($"""
                          IF OBJECT_ID('dbo.{name}') IS NULL
                          BEGIN
                              EXEC('
                                  {sql.Replace("'", "''")}
                              ')
                          END
                      """);

        var existsNow = ExecuteScalar(checkExistenceQuery) is not (DBNull or null);

        if (!existedBefore && existsNow)
        {
            MessageBox.Show($"{name} created successfully.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    internal object ExecuteScalar(string query)
    {
        _sqlConnection.Open();
        using var cmd = new SqlCommand(query, _sqlConnection);
        var result = cmd.ExecuteScalar();
        _sqlConnection.Close();
        return result;
    }

    private void CheckTableExistenceAndCreate(string tableName, string createTableScript)
    {
        var checkTableQuery = $"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";

        if (ExecuteQuery(checkTableQuery) is not DataTable { Rows.Count: 0 }) return;

        ExecuteQuery(createTableScript);

        MessageBox.Show($"Table {tableName} created successfully.", "E-Commerce Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

}