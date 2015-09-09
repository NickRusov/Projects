using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private const string m_articleTableName = "articles";
        private const string m_commentsTableName = "comments";
        private const string m_ratingsTableName = "ratings";

        private readonly string m_connectionString;
        private List<Article> m_allArticles;
        

        public string ConnectionString {
            get { return m_connectionString; }
        }

        public ArticleRepository(string connectionString)
        {
            m_connectionString = connectionString;
            m_allArticles = new List<Article>();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return m_allArticles;
        }

        public Article GetArticle(int id)
        {
            var dataset = DbHelper.GetArticle(id, ConnectionString);
            var articleRow = dataset.Tables[0].Rows[0];
            var article = new Article(new Author((string)articleRow["firstname"],
                            (string)articleRow["lastname"],
                            (short)articleRow["age"],
                            (int)articleRow["authorId"],
                            (string)articleRow["email"]),
                    (string)articleRow["title"], (string)articleRow["text"], id);
            foreach (DataRow row in dataset.Tables[1].Rows)
            {
                if (row["mark"] == DBNull.Value)
                {
                    article.AddComment(new Comment(
                        (string)row["text"],
                        new User(
                            (string)row["firstname"],
                            (string)row["lastname"],
                            (short)row["age"],
                            (int)row["userId"]),
                        (int)row["commentId"]));
                }
                else
                {
                    article.AddRating(new Rating(
                        (string)row["text"],
                        new User(
                            (string)row["firstname"],
                            (string)row["lastname"],
                            (short)row["age"],
                            (int)row["userId"]),
                        (byte)row["mark"],
                        (int)row["commentId"]));
                }
            }
            return article;
        }

        public bool AddComment(NewComment newComment)
        {
            const string insertCommandString = 
                @"INSERT INTO dbo.comments (userId, articleId, text)
                    VALUES (@userId, @articleId, @text);";
            var insertCommand = new SqlCommand(insertCommandString);
            insertCommand.Parameters.AddWithValue("@userId", newComment.UserId);
            insertCommand.Parameters.AddWithValue("@articleId", newComment.ArticleId);
            insertCommand.Parameters.AddWithValue("@text", newComment.Comment);
            return DbHelper.ExecuteCommand(insertCommand, ConnectionString) > 0;

        }

        //public  GetArticleComments(int articleId)
        //{
        //    var dataset = DbHelper.GetArticle(articleId);
        //    var articleRow = dataset.Tables[0].Rows[0];
        //    var article = new Article(new Author((string)articleRow["firstname"],
        //                    (string)articleRow["lastname"],
        //                    (short)articleRow["age"],
        //                    (int)articleRow["authorId"],
        //                    (string)articleRow["email"]),
        //            (string)articleRow["title"], (string)articleRow["text"], id);
        //    foreach (DataRow row in dataset.Tables[1].Rows)
        //    {
        //        if (row["mark"] == DBNull.Value)
        //        {
        //            article.AddComment(new Comment(
        //                (string)row["text"],
        //                new User(
        //                    (string)row["firstname"],
        //                    (string)row["lastname"],
        //                    (short)row["age"],
        //                    (int)row["userId"]),
        //                (int)row["commentId"]));
        //        }
        //        else
        //        {
        //            article.AddRating(new Rating(
        //                (string)row["text"],
        //                new User(
        //                    (string)row["firstname"],
        //                    (string)row["lastname"],
        //                    (short)row["age"],
        //                    (int)row["userId"]),
        //                (byte)row["mark"],
        //                (int)row["commentId"]));
        //        }
        //    }
        //    return article;
        //}

        public int LoadPage(int currentPage, int pageBy) 
        {
            var selectCommand = new SqlCommand(
                        @"SELECT article.articleId, article.title, u.firstname, u.lastname, author.email 
	                    FROM dbo.articles article
	                    JOIN dbo.users u
                        ON u.Id = article.authorId
                        JOIN dbo.authors author
                        ON u.Id = author.userId
                        ORDER BY title OFFSET @rows ROWS FETCH NEXT @pageBy ROWS ONLY");
            selectCommand.Parameters.AddWithValue("rows", (currentPage - 1) * pageBy);
            selectCommand.Parameters.AddWithValue("pageBy", pageBy);
            var table = DbHelper.ExecuteQuery(selectCommand, ConnectionString).Rows;
            //var table = DbHelper.GetArticlesFromDb(currentPage, pageBy, ConnectionString).Rows;
            foreach (DataRow row in table)
            {
                this.AddArticle(new Article(new Author((string)row["firstname"], (string)row["lastname"], 0, 0, (string)row["email"]), (string)(row["title"]), null, (int)(row["articleId"])));
            }
            return (int)Math.Ceiling(DbHelper.GetTotalInTable(m_articleTableName, ConnectionString) / Convert.ToDouble(pageBy));
        }

        public void AddArticle(Article article)
        {
            m_allArticles.Add(article);
        }        

        public int Count()
        {
            return DbHelper.GetTotalInTable(m_articleTableName, ConnectionString);
        }
    }
}
