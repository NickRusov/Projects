using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class ArticleRepository : IArticleRepository
    {

        public List<Article> AllArticles
        {
            get; 
            private set; 
            
        }

        public void AddArticle(Article article)
        {
            AllArticles.Add(article);
        }

        public ArticleRepository()
        {
            AllArticles = new List<Article>();
        }

        public int Count()
        {
            return AllArticles.Count;
        }

    }
}
