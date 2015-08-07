using System.Collections.Generic;
using System.Data;
using System;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class DbArticleRepository : IArticleRepository
    {
        private List<Article> m_allArticles;

        public DbArticleRepository()
        {
            m_allArticles = new List<Article>();
        }

        public List<Article> GetAllArticles()
        {
            return m_allArticles;
        }

        public Article GetArticle(int id)
        {
            var dataset = DbHelper.GetArticle(id);
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
            const string insertQueryString = 
                @"INSERT INTO dbo.comments (userId, articleId, text)
                    VALUES (@userId, @articleId, @text);";
            var insertCommand = new System.Data.SqlClient.SqlCommand(insertQueryString);
            insertCommand.Parameters.AddWithValue("@userId", newComment.UserId);
            insertCommand.Parameters.AddWithValue("@articleId", newComment.ArticleId);
            insertCommand.Parameters.AddWithValue("@text", newComment.Comment);
            return DbHelper.Insert(insertCommand);

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
            var table = DbHelper.GetArticlesFromDb(currentPage, pageBy).Rows;
            foreach (DataRow row in table)
            {
                this.AddArticle(new Article(new Author((string)row["firstname"], (string)row["lastname"], 0, 0, (string)row["email"]), (string)(row["title"]), null, (int)(row["articleId"])));
            }
            return (int)Math.Ceiling(DbHelper.GetTotalInTable(Table.articles) / Convert.ToDouble(pageBy));
        }

        public void AddArticle(Article article)
        {
            m_allArticles.Add(article);
        }        

        public int Count()
        {
            return DbHelper.GetTotalInTable(Table.articles);
        }
    }
}
