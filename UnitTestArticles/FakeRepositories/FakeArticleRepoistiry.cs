using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Repositories;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.UnitTestsforModels.FakeRepositories
{
    public class FakeArticleRepoistiry : IArticleRepository
    {
        public List<Article> articles;

        public string ConnectionString
        {
            get { return ""; }
        }

        public bool AddComment(NewComment newComment)
        {
            return false;
        }
        public List<Article> GetAllArticles()
    {
                var listToReturn = new List<Article>
                {
                    new Article(new Author("a", "Rusov", 20,1,  "mail adress"),
                        "C# classes",
                        "Some text about classes", 1),
                    new Article(new Author("b","Rusov",21, 2, "mail adress"),
                        "C# interfaces",
                        "Some text about interfaces", 2),
                    new Article(new Author("c","Rusov",22, 3, "mail adress"),
                        "C# structures",
                        "Some text about structures", 3)
                };
                listToReturn[0].AddComment(new Comment("Not bad.", listToReturn[2].Author, 1));
                listToReturn[0].AddComment(new Comment("Cool!", listToReturn[1].Author, 2));
                
                listToReturn[0].AddRating(new Rating("firstComment", listToReturn[2].Author, 8, 3));
                listToReturn[0].AddRating(new Rating("secondComment", listToReturn[1].Author, 9, 4));
                return listToReturn;
            
        }

        public Article GetArticle(int articleId)
        {
            return new Article(new Author("a", "Rusov", 20, 1, "mail adress"),
                        "C# classes",
                        "Some text about classes", 1);
        }
        public int LoadPage(int currentPage, int pageBy)
        {
            //DataRowCollection rows = DbHelper.GetArticlesFromDb(currentPage, pageBy).Rows;
            //foreach (DataRow row in rows)
            //{
            //    this.AddArticle(new Article(new Author("firstname", "lastname", 20, 1, "email"), (string)(row["title"]), (string)(row["text"]), (int)(row["articleId"])));
            //}
            return 4;
        }

        public void AddArticle(Article article)
        {
            articles.Add(article);
        }

        public int Count()
        {
            return 3;
        }
    }
}
