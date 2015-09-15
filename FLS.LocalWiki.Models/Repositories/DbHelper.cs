using System;
using System.Data;
using System.Data.SqlClient;


namespace FLS.LocalWiki.Models.Repositories
{
    public static class DbHelper
    {
        public static int GetTotalInTable(string tableName, string connectionString)
        {
            int total;
            using (var adapter =
                new SqlDataAdapter(String.Format("SELECT Count(*) FROM dbo.[{0}]", tableName),
                    connectionString))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                total = (int)dataTable.Rows[0][0];
            }
            return total;
        }

        public static DataTable ExecuteQuery(SqlCommand selectCommand, string connectionString)
        {
            var dataTable = new DataTable();
            using (var adapter = new SqlDataAdapter(selectCommand))
            {
                selectCommand.Connection = new SqlConnection(connectionString);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        public static int ExecuteCommand(SqlCommand command, string connectionString)
        {
            int affected;
            using (var connection = new SqlConnection(connectionString))
            {
                command.Connection = connection;
                command.Connection.Open();
                affected = command.ExecuteNonQuery();
            }
            return affected;
        }
    }
}
