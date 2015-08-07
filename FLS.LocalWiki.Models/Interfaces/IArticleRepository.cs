using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();

        Article GetArticle(int id);

        bool AddComment(NewComment newComment);

        int LoadPage(int currentPage, int pageBy);

        void AddArticle(Article article);

        int Count();
    }
}
