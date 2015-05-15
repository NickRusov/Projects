using FLS.LocalWiki.Models.Entities;
using System.Collections.Generic;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> AllArticles { get; }

        void AddArticle(Article article);

        int Count();
    }
}
