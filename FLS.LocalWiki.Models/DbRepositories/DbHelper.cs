using System;
using System.Data;
using System.Data.SqlClient;


namespace FLS.LocalWiki.Models.Repositories
{
    public static class DbHelper
    {
        private static /*readonly*/ string m_connectionString;

        public static void SetConnectionString(string connectionString)
        {
            m_connectionString = connectionString;
        }

        public static DataTable GetArticlesFromDb(int currentPage, int pageBy)
        {
            var dataTable = new DataTable();            
            using (var adapter =
                    new SqlDataAdapter(@"SELECT article.articleId, article.title, u.firstname, u.lastname, author.email 
	                    FROM dbo.articles article
	                    JOIN dbo.users u
                        ON u.Id = article.authorId
                        JOIN dbo.authors author
                        ON u.Id = author.userId
                        ORDER BY title OFFSET @rows ROWS FETCH NEXT @pageBy ROWS ONLY", m_connectionString))
            {
                adapter.SelectCommand.Parameters.AddWithValue("rows", (currentPage - 1) * pageBy);
                adapter.SelectCommand.Parameters.AddWithValue("pageBy", pageBy);
                adapter.Fill(dataTable);                
            }
            return dataTable;
        }

        public static DataSet GetArticle(int articleId)
        {
            var d = new SqlDataAdapter(null, m_connectionString);
            var dataset = new DataSet();
            using (var adapter =
                    new SqlDataAdapter(
                        @"SELECT article.title, article.text,article.authorId, u.firstname, u.lastname, u.age, author.email 
	                    FROM dbo.articles article
	                    JOIN dbo.users u
                        ON u.Id = article.authorId
                        JOIN dbo.authors author
                        ON u.Id = author.userId
                        WHERE articleId = @articleId", m_connectionString))
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

        public static int GetTotalInTable(Table table)
        {
            int total;
            using (var adapter = 
                new SqlDataAdapter(String.Format("SELECT Count(*) FROM dbo.[{0}]", table.ToString()),
                    m_connectionString))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                total = (int)dataTable.Rows[0][0];
            }
            return total;
        }

        public static bool Insert(SqlCommand insertCommand)
        {
            bool inserted;
            using (var connection = new SqlConnection(m_connectionString))
            {
                //var insertCommand = new SqlCommand(insertQueryString);
                //insertCommand.Parameters.AddWithValue("@userId", newComment.UserId);
                //insertCommand.Parameters.AddWithValue("@articleId", newComment.ArticleId);
                //insertCommand.Parameters.AddWithValue("@text", newComment.Comment);
                insertCommand.Connection = connection;
                try
                {
                    connection.Open();
                    inserted = insertCommand.ExecuteNonQuery() > 0;
                }
                catch
                {
                    return false;
                }
            }
            return inserted;
        }
    }
}
