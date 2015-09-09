using System;
using System.Collections.Generic;
using System.Linq;
using NMock;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestArticles
{
    [TestClass]
    public class FacadeTests
    {
        private MockFactory m_factory = new MockFactory();
        private Mock<IArticleRepository> m_mockArticleRepository;
        private IFacade m_facade;

        [TestInitialize]
        public void Initialize()
        {
            m_mockArticleRepository = m_factory.CreateMock<IArticleRepository>();
            m_facade = new Facade(m_mockArticleRepository.MockObject, null, null, null);
        }

        [TestCleanup]
        public void Cleanup()
        {
            m_factory.VerifyAllExpectationsHaveBeenMet();
            m_factory.ClearExpectations();
        }

        [TestMethod]
        public void AllArticlesTest()
        {
            // arrange
            IEnumerable<Article> listToReturn = new List<Article>(3)
            {
                new Article(null, null, null, 1),
                new Article(null, null, null, 2),
                new Article(null, null, null, 3)
            };

            m_mockArticleRepository.Expects.One.Method(_ => _.GetAllArticles()).WillReturn(listToReturn);

            // act
            var articlesLoaded = m_facade.AllArticles.Count();

            // assert
            Assert.AreEqual(articlesLoaded, 3);
        }

        [TestMethod]
        public void FillPageTest()
        {
            // arrange
            //var mockArticleRepository = _factory.CreateMock<IArticleRepository>();
            //List<Article> listToReturn = new List<Article>(3)
            //{
            //    new Article(new Author("a", 
            //    "Rusov", 
            //    20, 
            //    1, 
            //    "mail address"),
            //    "C# classes",
            //    "Some text about classes", 
            //    1),

            //    new Article(new Author("b",
            //    "Rusov",
            //    20,
            //    2,
            //    "mail address"),
            //    "C# interfaces",
            //    "Some text about interfaces",
            //    2),

            //    new Article(new Author("c",
            //    "Rusov",
            //    20,
            //    3,
            //    "mail address"),
            //    "C# structures",
            //    "Some text about structures",
            //    3)
            //};

            m_mockArticleRepository.Expects.One.MethodWith(_ => _.LoadPage(1, 2)).WillReturn(2);

            // act
            int totalPages = m_facade.FillPage(1, 2);

            // assert
            Assert.AreEqual(totalPages, 2);
        }

        [TestMethod]
        public void FindArticleByIdTest()
        {
            //arrange
            var article = new Article(null, null, null, 1);
            m_mockArticleRepository.Expects.One.MethodWith(_ => _.GetArticle(1)).WillReturn(article);
            
            // act
            var articleId = m_facade.FindArticleById(1).Id;

            // assert
            Assert.AreEqual(articleId, 1);
        }

        [TestMethod]
        public void AddCommentTest()
        {
            //arrange
            NewComment comment = new NewComment();
            m_mockArticleRepository.Expects.One.MethodWith(_ => _.AddComment(comment)).WillReturn(true);

            // act
            var isAdded = m_facade.AddComment(comment);

            // assert
            Assert.AreEqual(isAdded, true);
        }


    }
}
