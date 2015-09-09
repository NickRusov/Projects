using System;
using System.Data;
using System.Data.SqlClient;


namespace FLS.LocalWiki.Models.Repositories
{
    public static class DbHelper
    {
//        public static DataTable GetArticlesFromDb(int currentPage, int pageBy, string connectionString)
//        {
//            var dataTable = new DataTable();            
//            using (var adapter =
//                    new SqlDataAdapter(@"SELECT article.articleId, article.title, u.firstname, u.lastname, author.email 
//	                    FROM dbo.articles article
//	                    JOIN dbo.users u
//                        ON u.Id = article.authorId
//                        JOIN dbo.authors author
//                        ON u.Id = author.userId
//                        ORDER BY title OFFSET @rows ROWS FETCH NEXT @pageBy ROWS ONLY", connectionString))
//            {
//                adapter.SelectCommand.Parameters.AddWithValue("rows", (currentPage - 1) * pageBy);
//                adapter.SelectCommand.Parameters.AddWithValue("pageBy", pageBy);
//                adapter.Fill(dataTable);                
//            }
//            return dataTable;
//        }

        public static DataSet GetArticle(int articleId, string connectionString)
        {
            var dataset = new DataSet();
            using (var adapter =
                    new SqlDataAdapter(
                        @"SELECT article.title, article.text,article.authorId, u.firstname, u.lastname, u.age, author.email 
	                    FROM dbo.articles article
	                    JOIN dbo.users u
                        ON u.Id = article.authorId
                        JOIN dbo.authors author
                        ON u.Id = author.userId
                        WHERE articleId = @articleId", connectionString))
            {                
                adapter.SelectCommand.Parameters.AddWithValue("articleId", articleId);
                adapter.Fill(dataset);
                adapter.SelectCommand.CommandText = 
                @"SELECT c.*, r.mark, u.firstname, u.lastname, u.age
                  FROM [dbo].[comments] c
                  LEFT OUTER JOIN [dbo].[ratings] r
                  ON c.commentId = r.commentId
                  JOIN [dbo].[users] u
                  ON c.userId = u.Id
                  WHERE articleId = @articleId";
                adapter.Fill(dataset, "Table1");
            }
            return dataset;
        }

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
