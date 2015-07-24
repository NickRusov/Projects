using System.Collections.Generic;
using System.Data;
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
                if (row["mark"] == System.DBNull.Value)
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

        public void LoadPage(int currentPage, int pageBy) 
        {
            var table = DbHelper.GetArticlesFromDb(currentPage, pageBy).Rows;
            foreach (DataRow row in table)
            {
                this.AddArticle(new Article(new Author((string)row["firstname"], (string)row["lastname"], 0, 0, (string)row["email"]), (string)(row["title"]), null, (int)(row["articleId"])));
            }
            return;
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
