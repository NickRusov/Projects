using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;
using StructureMap;

namespace FLS.LocalWiki.WebApplication.Models
{
    public static class Initializer
    {
        private readonly static Container container = new Container(x =>
            {
                x.For<IArticleRepository>().Use<ArticleRepository>();
                x.For<IAdminRepository>().Use<AdminRepository>();
                x.For<IAuthorRepository>().Use<AuthorRepository>();
                x.For<IUserRepository>().Use<UserRepository>();
                x.For<IFacade>().Use<Facade>();               
            });

        public static IFacade GetInitializedFacade()
        {                      
            var userRepository = container.GetInstance<IUserRepository>();
            var f = container.With<IUserRepository>(userRepository).GetInstance<IFacade>();
            var firstUser = new User("Nick", "Rusov", 20, 1);
            var secondUser = new User("Nickola", "Dusov", 24, 2);
            var thirdUser = new User("Nickola", "Shrusov", 22, 3);
            userRepository.AddUser(firstUser);
            userRepository.AddUser(secondUser);
            userRepository.AddUser(thirdUser);


            var authorRepository = container.GetInstance<IAuthorRepository>();
            var firstAuthor = new Author("Nickolay", "Pusov", 28, 4, "johndoe@example.com");
            var secondAuthor = new Author(firstUser, "jamesdon@example.com");
            var thirdAuthor = new Author(secondUser, "jamesdon@example.com");
            authorRepository.AddAuthor(new Author(thirdUser, "jamesdon@example.com"));
            authorRepository.AddAuthor(secondAuthor);
            authorRepository.AddAuthor(firstAuthor);
            authorRepository.AddAuthor(thirdAuthor);

            var adminRepository = container.GetInstance<IAdminRepository>();
            string[] privelegies = { "Delete articles", "Delete comments" };
            var firstAdmin = new Admin(firstAuthor, privelegies);
            var secondAdmin = new Admin(thirdAuthor, privelegies);
            adminRepository.AddAdmin(new Admin(thirdUser, privelegies));
            adminRepository.AddAdmin(firstAdmin);
            adminRepository.AddAdmin(secondAdmin);


            var article = new Article(new Author(secondAdmin, "mail #1"), "C# classes", "Some text about classes", 1);

            var firstComment = new Comment("Cool!", thirdAuthor, 1);
            article.AddComment(new Comment("Not bad.", secondAdmin, 2));
            var firstRating = new Rating(firstComment, 8);
            var secondRating = new Rating("Really cool!", firstAdmin, 10, 3);
            article.AddComment(firstComment);
            article.AddRating(firstRating);
            article.AddRating(secondRating);


            var articleRepository = container.GetInstance<IArticleRepository>();
            articleRepository.AddArticle(article);
            articleRepository.AddArticle(new Article(new Author("Michael", "Rusov", 20, 5, "mail #2"), "C# interfaces",
                "Some text about interfaces", 2));
            articleRepository.AddArticle(new Article(new Author("Vasiliy", "Rusov", 20, 6, "mail #3"), "C# structures",
                "Some text about structures", 3));

            return container.
                With<IArticleRepository>(articleRepository).
                With<IAuthorRepository>(authorRepository).
                With<IAdminRepository>(adminRepository).
                With<IUserRepository>(userRepository).
                GetInstance<IFacade>();
        }
    }
}