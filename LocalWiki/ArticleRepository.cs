using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class ArticleRepository : IArticleRepository
    {
        private List<Article> m_articles;

        public List<Article> AllArticles 
        { get { return m_articles; } }

        public void AddArticle(Article article)
        {
            m_articles.Add(article);
        }

        public ArticleRepository()
        {
            m_articles=new List<Article>();
        }

        public int Count()
        {
            return m_articles.Count;
        }

    }
}
