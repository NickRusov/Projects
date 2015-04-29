using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocalWiki;
namespace UnitTestArticles
{
    [TestClass]
    public class UnitTestFacade
    {
        [TestMethod]
        public void FacadeTests()
        {
            // arrange
            UserRepository userRepo = new UserRepository();
            User firstUser = new User("Nick", "Rusov", 20);
            User secondUser = new User("Nickola", "Dusov", 24);
            User user3 = new User("Nickola", "Shrusov", 24);
            userRepo.AddUser(firstUser);
            userRepo.AddUser(secondUser);
            userRepo.AddUser(user3);

            AuthorRepository authorRepo = new AuthorRepository();
            Author author1 = new Author(firstUser, "jamesdon@example.com");
            Author author2 = new Author(secondUser, "jamesdon@example.com");
            authorRepo.AddAuthor(new Author(user3, "jamesdon@example.com"));

            AdminRepository adminRepo = new AdminRepository();
            string[] privelegies = { "Delete articles", "Delete comments" };
            Admin ad = new Admin(author1, privelegies);
            Admin ad2 = new Admin(author2, privelegies);
            adminRepo.AddAdmin(new Admin(user3, privelegies));

            ArticleRepository articleRepo=new ArticleRepository();
            Article art = new Article(new Author("Bay", "Michael", 45, "hello@example.com" ), "C# classes", "Reference type");
            Article art2 = new Article(new Author(ad2,"mail@example.com"), "C# structures", "Value type");
            Article art3 = new Article(new Author(ad2, "email@example.com"), "C# enumerations", "About enams");
            articleRepo.AddArticle(art2);
            articleRepo.AddArticle(art);
            articleRepo.AddArticle(art3);
            Comment comment1 = new Comment("Cool!", user3);
            art.AddComment(new Comment("Not bad.", ad2));
            Rating rating1 = new Rating(comment1, 8);
            Rating rating2 = new Rating("Really cool!", ad, 10);    //
            art.AddComment(comment1);
            art.AddRating(rating1);
            art.AddRating(rating2);
            /*uint expectedArticleId1 = 1;
            var expectedArticleId2 = 3;
            var expectedEmail = "emAil@example.com";
            var expectedAuthorId = 2;
            var expectedRating = 9;*/

            //var articlesAtAll = 3;

            // act
            //Facade facade = new Facade();
            /*var foundArticleById = Facade.FindArticleById(1);
            var foundArticleByTitle = Facade.FindArticleByTitle(articleRepo, "C# enumerations");
            var actualRating = Facade.GetArticleAverageRating(articleRepo, 1);*/

            // assert
            /*Assert.AreEqual(expectedArticleId1, foundArticleById.Id, 0, "Wrong ID.");
            Assert.AreEqual(expectedArticleId2, foundArticleByTitle.Id, 0, "Wrong article ID.");
            Assert.AreEqual(expectedEmail, foundArticleByTitle.Author.Email, true, "Wrong mail.");
            Assert.AreEqual(expectedAuthorId, foundArticleByTitle.Author.Id, 0, "Wrong user ID.");
            Assert.AreEqual(expectedRating, actualRating, 0, "Wrong rating.");*/
        }

        /*[TestMethod]
        public void FindArticleByTitle()
        {
            //arrange
            User firstUser = new User("Nick", "Rusov", 20);
            User secondUser = new User("Nickola", "Dusov", 24);
            User user3 = new User("Nickola", "Shrusov", 24);

            AuthorRepository authorRepo = new AuthorRepository();
            Author author = new Author("Nickolay", "Pusov", 28, "johndoe@example.com");
            Author author1 = new Author(firstUser, "jamesdon@example.com");
            Author author2 = new Author(secondUser, "jamesdon@example.com");
            authorRepo.AddAuthor(new Author(user3, "jamesdon@example.com"));

            AdminRepository adminRepo = new AdminRepository();
            string[] privelegies = { "Delete articles", "Delete comments" };
            Admin ad = new Admin(author, privelegies);
            Admin ad2 = new Admin(author2, privelegies);
            ArticleRepository articleRepo = new ArticleRepository();
            Article art2 = new Article(new Author(ad2, "mail@example.com"), "C# structures", "Value type");
            articleRepo.AddArticle(art2);
            var expectedArticleId = 1;
            var expectedEmail = "mAil@example.com";
            var expectedAuthorId = 2;

            //act
            var foundArticle = Facade.FindArticleByTitle(articleRepo, "C# structures");


            //assert
            Assert.AreEqual(expectedArticleId, foundArticle.Id, 0, "Wrong article ID.");
            Assert.AreEqual(expectedEmail, foundArticle.Author.Email, true, "Wrong mail.");
            Assert.AreEqual(expectedAuthorId, foundArticle.Author.Id, 0, "Wrong user ID.");
            
        }*/
    }
}
