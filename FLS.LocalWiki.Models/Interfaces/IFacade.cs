using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IFacade
    {
        IEnumerable<Article> AllArticles
        { 
            get; 
        }

        Article FindArticleById(int articleId);

        List<Article> FindArticlesByTitle(string title);

        Author FindAuthorById(int authorId);

        List<Author> FindAuthorsByLastname(string lastname);

        Admin FindAdminById(int adminId);

        List<Admin> FindAdminsByLastname(string lastname);

        User FindUserById(int userId);

        List<User> FindUsersByLastname(string lastname);
    }
}