using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
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
