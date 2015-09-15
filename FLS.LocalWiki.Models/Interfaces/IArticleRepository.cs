using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IArticleRepository
    {
        string ConnectionString { get; }

        IEnumerable<Article> GetAllArticles();

        Article GetArticle(int articleId);

        Reviews GetReviews(int articleId);

        bool AddComment(NewComment newComment);

        int LoadPage(int currentPage, int pageBy);

        void AddArticle(Article article);

        int Count();
    }
}
