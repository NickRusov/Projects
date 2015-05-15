using System;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using LocalWiki;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestArticles
{
    [TestClass]
    public class GetAverageRatingTests
    {
        [TestMethod]
        public void GetAverageRatingOfExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var averageRating = facade.GetArticleAverageRatingById(1);

            // assert
            Assert.AreEqual(8.5d, averageRating);
        }

        [TestMethod]
        public void GetAverageRatingOfExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var averageRating = facade.GetArticleAverageRatingByTitle("C# classes");

            // assert
            Assert.AreEqual(8.5d, averageRating);
        }

        [TestMethod]
        public void GetAverageRatingOfNonExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var averageRating = facade.GetArticleAverageRatingById(100);

            // assert
            Assert.AreEqual(null, averageRating);
        }

        [TestMethod]
        public void GetAverageRatingOfNonExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var averageRating = facade.GetArticleAverageRatingByTitle("C#");

            // assert
            Assert.AreEqual(null, averageRating);
        }
    }
}

