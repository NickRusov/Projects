using System;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.UnitTestsforModels.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FLS.LocalWiki.UnitTestsforModels
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
            var foundArticle = facade.FindArticleById(1);

            // assert
            Assert.AreEqual(8.5d, foundArticle.AverageRating);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetAverageRatingOfNonExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var foundArticle = facade.FindArticleById(100);

            // assert
            Assert.AreEqual(null, foundArticle.AverageRating);
        }

    }
}

