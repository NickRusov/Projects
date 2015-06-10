using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;
using StructureMap;


namespace FLS.LocalWiki.Initializing
{

    public sealed class SingleContainer
    {
        private static readonly SingleContainer instance = new SingleContainer();
        private static readonly Container container = new Container(x =>
                    {
                    x.For<IArticleRepository>().Use<ArticleRepository>();
                    x.For<IAdminRepository>().Use<AdminRepository>();
                    x.For<IAuthorRepository>().Use<AuthorRepository>();
                    x.For<IUserRepository>().Use<UserRepository>();
                    x.For<IFacade>().Use<Facade>();
                    });
        private SingleContainer() { }

        public static SingleContainer Instance
        {
            get
            {
                return instance;
            }
        }

        public Container Container
        {
            get
            {
                return container;
            }
        }

        public IFacade GetInitializedFacade(string connectionString)
        {
           var userRepository = Instance.Container.GetInstance<IUserRepository>();
           var authorRepository = Instance.Container.GetInstance<IAuthorRepository>();
           var adminRepository = Instance.Container.GetInstance<IAdminRepository>();
           var articleRepository = Instance.Container.GetInstance<IArticleRepository>();
           var facade = Instance.Container.
              With<IArticleRepository>(articleRepository).
              With<IAuthorRepository>(authorRepository).
              With<IAdminRepository>(adminRepository).
              With<IUserRepository>(userRepository).
              GetInstance<IFacade>();
           
           SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM users;", connectionString);
           DataSet dataset = new DataSet();
           sqlAdapter.TableMappings.Add("Table", "users");
           sqlAdapter.TableMappings.Add("Table1", "authors");
           sqlAdapter.TableMappings.Add("Table2", "admins");
           sqlAdapter.TableMappings.Add("Table3", "comments");
           sqlAdapter.TableMappings.Add("Table4", "ratings");
           sqlAdapter.TableMappings.Add("Table5", "articles");

           sqlAdapter.Fill(dataset, "users");

           sqlAdapter.SelectCommand.CommandText = "SELECT * FROM authors";
           sqlAdapter.Fill(dataset, "authors");

           sqlAdapter.SelectCommand.CommandText = "SELECT * FROM admins";
           sqlAdapter.Fill(dataset, "admins");

           sqlAdapter.SelectCommand.CommandText = "SELECT * FROM comments";
           sqlAdapter.Fill(dataset, "comments");

           sqlAdapter.SelectCommand.CommandText = "SELECT * FROM ratings";
           sqlAdapter.Fill(dataset, "ratings");

           sqlAdapter.SelectCommand.CommandText = "SELECT * FROM articles";
           sqlAdapter.Fill(dataset, "articles");

           dataset.Relations.Add("UserAuthor", dataset.Tables["users"].Columns["Id"], dataset.Tables["authors"].Columns["userId"]);
           dataset.Relations.Add("UserAdmin", dataset.Tables["users"].Columns["Id"], dataset.Tables["admins"].Columns["userId"]);

           dataset.Relations.Add("CommentRating", dataset.Tables["comments"].Columns["commentId"], dataset.Tables["ratings"].Columns["commentId"]);

           dataset.Relations.Add("ArticleComment", dataset.Tables["articles"].Columns["articleId"], dataset.Tables["comments"].Columns["articleId"]);
           
           foreach (DataRow row in dataset.Tables["users"].Rows)
           {
               var user = new User((string)(row["firstname"]), (string)(row["lastname"]), (System.Int16)(row["age"]), (int)(row["Id"]));
               userRepository.AddUser(user);
               var authors = row.GetChildRows("UserAuthor");
               if (authors.Length == 1)
               {
                   authorRepository.AddAuthor(new Author(user, (string)authors[0]["email"]));
               }
               var admins = row.GetChildRows("UserAdmin");
               if (admins.Length == 1)
               {
                   adminRepository.AddAdmin(new Admin(user, ((string)(admins[0]["privilegies"])).Split(',')));
               }

           }

           foreach (DataRow row in dataset.Tables["articles"].Rows)
           {
               var author = facade.FindAuthorById((int)(row["authorId"]));
               if (author == null)
               {
                   continue;
               }
               var article = new Article(author, (string)(row["title"]), (string)(row["text"]), (int)(row["articleId"]));
               var commentRows = row.GetChildRows("ArticleComment");

               foreach (var commentRow in commentRows)
               {
                   var reviewer = facade.FindUserById((int)(commentRow["userId"]));
                   if (reviewer == null)
                   {
                       continue;
                   }
                   var comment = new Comment((string)(commentRow["text"]), reviewer, (int)(commentRow["commentId"]));
                   var ratingRows = commentRow.GetChildRows("CommentRating");
                   if (ratingRows.Length == 1)
                   {
                       article.AddRating(new Rating(comment, (byte)(ratingRows[0]["mark"])));
                   }
                   else
                   {
                       article.AddComment(comment);
                   }
               }
               articleRepository.AddArticle(article);
           }

            return facade;
       }

        public IFacade GetInitializedFacade()
        {
            var userRepository = Instance.Container.GetInstance<IUserRepository>();
            var f = Instance.Container.With<IUserRepository>(userRepository).GetInstance<IFacade>();
            var firstUser = new User("Nick", "Rusov", 20, 1);
            var secondUser = new User("Nickola", "Dusov", 24, 2);
            var thirdUser = new User("Nickola", "Shrusov", 22, 3);
            userRepository.AddUser(firstUser);
            userRepository.AddUser(secondUser);
            userRepository.AddUser(thirdUser);


            var authorRepository = Instance.Container.GetInstance<IAuthorRepository>();
            var firstAuthor = new Author("Nickolay", "Pusov", 28, 4, "johndoe@example.com");
            var secondAuthor = new Author(firstUser, "jamesdon@example.com");
            var thirdAuthor = new Author(secondUser, "jamesdon@example.com");
            authorRepository.AddAuthor(new Author(thirdUser, "jamesdon@example.com"));
            authorRepository.AddAuthor(secondAuthor);
            authorRepository.AddAuthor(firstAuthor);
            authorRepository.AddAuthor(thirdAuthor);

            var adminRepository = Instance.Container.GetInstance<IAdminRepository>();
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


            var articleRepository = Instance.Container.GetInstance<IArticleRepository>();
            articleRepository.AddArticle(article);
            articleRepository.AddArticle(new Article(new Author("Michael", "Rusov", 20, 5, "mail #2"), "C# interfaces",
                "Some text about interfaces", 2));
            articleRepository.AddArticle(new Article(new Author("Vasiliy", "Rusov", 20, 6, "mail #3"), "C# structures",
                "Some text about structures", 3));

            return Instance.Container.
                With<IArticleRepository>(articleRepository).
                With<IAuthorRepository>(authorRepository).
                With<IAdminRepository>(adminRepository).
                With<IUserRepository>(userRepository).
                GetInstance<IFacade>();
        }
    }
      
   }
