using FLS.LocalWiki.Models.Entities;
using System.Collections.Generic;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles(); 

        void AddArticle(Article article);

        int Count();
    }
}
