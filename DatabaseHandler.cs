using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace E_Commerce_Store;

internal class DatabaseHandler(string connectionString)
{
    private readonly SqlConnection _sqlConnection = new(connectionString);

    internal object ExecuteQuery(string query)
    {
        _sqlConnection.Open();

        query = query.Trim();

        var sqlCommand = new SqlCommand(query, _sqlConnection);
        sqlCommand.CommandType = CommandType.Text;

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