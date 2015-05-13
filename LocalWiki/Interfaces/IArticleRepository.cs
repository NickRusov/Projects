using System;
using System.Collections.Generic;

namespace LocalWiki
{
    public interface IArticleRepository
    {
        List<Article> AllArticles { get; }

        void AddArticle(Article article);

        int Count();
    }
}
