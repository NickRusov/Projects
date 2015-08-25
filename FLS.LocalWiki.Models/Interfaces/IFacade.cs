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

        int CurrentPage
        {
            get;
            set;
        }

        int PageBy
        {
            get;
            set;
        }

        int TotalPages
        {
            get;
            set;
        }

        string AdminConnectionString { get; }

        string ArticleConnectionString { get; }

        string AuthorConnectionString { get; }

        string UserConnectionString { get; }

        int FillPage();

        Article FindArticleById(int articleId);

        bool AddComment(NewComment newComment);

        List<Article> FindArticlesByTitle(string title);

        Author FindAuthorById(int authorId);

        List<Author> FindAuthorsByLastname(string lastname);

        Admin FindAdminById(int adminId);

        List<Admin> FindAdminsByLastname(string lastname);

        User FindUserById(int userId);

        List<User> FindUsersByLastname(string lastname);
    }
}