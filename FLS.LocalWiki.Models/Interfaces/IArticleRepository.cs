using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles(); 

        void AddArticle(Article article);

        int Count();
    }
}
