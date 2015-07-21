using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private List<Article> m_allArticles;

        public ArticleRepository()
        {
            m_allArticles = new List<Article>();
        }

        public List<Article> GetAllArticles()
        {
            return m_allArticles;
        }

        public void AddArticle(Article article)
        {
            m_allArticles.Add(article);
        }        

        public int Count()
        {
            return m_allArticles.Count;
        }
    }
}
