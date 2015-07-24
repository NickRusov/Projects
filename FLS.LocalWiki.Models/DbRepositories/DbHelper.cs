using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FLS.LocalWiki.Models.Repositories
{
    public static class DbHelper
    {
        private static string m_connectionString;

        public static void SetConnectionString(string connectionString)
        {
            m_connectionString = connectionString;
        }

        public static DataTable GetArticlesFromDb(int currentPage, int pageBy)
        {
            var dataTable = new DataTable();            
            using (SqlDataAdapter adapter =
                    new SqlDataAdapter(@"SELECT article.articleId, article.title, u.firstname, u.lastname, author.email 
	                    FROM dbo.articles article
	                    JOIN dbo.users u
                        ON u.Id = article.authorId
                        JOIN dbo.authors author
                        ON u.Id = author.userId
                        ORDER BY title OFFSET @rows ROWS FETCH NEXT @pageBy ROWS ONLY", m_connectionString))
            {
                adapter.SelectCommand.Parameters.AddWithValue("rows", (int)((currentPage - 1) * pageBy));
                adapter.SelectCommand.Parameters.AddWithValue("pageBy", (int)pageBy);
                adapter.Fill(dataTable);                
            }
            return dataTable;
        }

        public static DataSet GetArticle(int articleId)
        {
            var dataset = new DataSet();
            using (SqlDataAdapter adapter =
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
    }
}
