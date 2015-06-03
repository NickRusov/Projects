using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IFacade
    {
        IEnumerable<Article> AllArticles
        { get; }
        Article FindArticleById(uint articleId);

        List<Article> FindArticlesByTitle(string title);


        Author FindAuthorById(uint authorId);

        List<Author> FindAuthorsByLastname(string lastname);


        Admin FindAdminById(uint adminId);

        List<Admin> FindAdminsByLastname(string lastname);


        User FindUserById(uint userId);

        List<User> FindUsersByLastname(string lastname);
    }
}