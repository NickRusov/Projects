using System;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using LocalWiki;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestArticles
{
    [TestClass]
    public class ReadArticleTests
    {
        [TestMethod]
        public void ReadExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var text = facade.ReadArticleById(1);

            // assert
            Assert.AreEqual("Some text about classes", text);
        }

        [TestMethod]
        public void ReadExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var text = facade.ReadArticleByTitle("C# structures");

            // assert
            Assert.AreEqual("Some text about structures", text);
        }

        [TestMethod]
        public void ReadNonExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var text = facade.ReadArticleById(0);

            // assert
            Assert.AreEqual(null, text);
        }

        [TestMethod]
        public void ReadNonExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var text = facade.ReadArticleByTitle("C#");

            // assert
            Assert.AreEqual(null, text);
        }
    }


}
