using System;
using System.Data;
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

        // Procedure check
        if (query.StartsWith("sp_", StringComparison.OrdinalIgnoreCase))
        {
            // Execute the stored procedure
            var rowsAffected = sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            return rowsAffected;
        }

        if (query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
        {
            // For SELECT, return the data as a DataTable
            var reader = sqlCommand.ExecuteReader();
            var resultTable = new DataTable();
            resultTable.Load(reader);
            reader.Close();
            _sqlConnection.Close();
            return resultTable;
        }

        if (query.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase) || query.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase) || query.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase))
        {
            // For INSERT, DELETE, or UPDATE, execute the query and return the number of affected rows
            var rowsAffected = sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
            return rowsAffected;
        }

        _sqlConnection.Close();
        throw new InvalidOperationException("Query syntax incorrect.");
    }
}