using System;
using System.Collections.Generic;
using System.Linq;
using LocalWiki;
using NMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestArticles
{
    [TestClass]
    public class FacadeTests
    {

        private MockFactory _factory = new MockFactory();

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        // [ExpectedException(typeof(NullReferenceException))]
        public void FindArticleByTitleTest()
        {
            var mockIArticleRepository = _factory.CreateMock<IArticleRepository>();
            List<Article> listToReturn = new List<Article>(3);
            listToReturn.Add(new Article(new Author("a", "Rusov", 20, "mail address"), "C# classes", "Some text about classes"));
            listToReturn.Add(new Article(new Author("b", "Rusov", 20, "mail address"), "C# interfaces",
                "Some text about interfaces"));
            listToReturn.Add(new Article(new Author("c", "Rusov", 20, "mail address"), "C# structures",
                "Some text about structures"));

            mockIArticleRepository.Expects.One.GetProperty(_ => _.AllArticles).WillReturn(listToReturn);
            

            var facade = new Facade(mockIArticleRepository.MockObject,null,null,null);
            Assert.AreEqual("a", facade.FindArticleByTitle("C# classes").Author.FirstName);
        }

        [TestMethod]
        public void FindArticleByIdTest()
        {
            // arrange
            IArticleRepository article = new FakeArticleRepoistiry();
            var facade = new Facade(article, null, null, null);
       
            // act
            var foundId = facade.FindArticleByTitle("C# classes").Id;
            
            // assert
            Assert.AreEqual((uint)1, foundId );
            //Assert.AreEqual(, facade.FindArticle("C#").Id);
        }

        [TestMethod]
        public void FindAuthorByLastnameTest()
        {
            // arrange
            var mockIAuthorRepository = _factory.CreateMock<IAuthorRepository>();
            var listToReturn = new List<Author>(3);
            listToReturn.Add(new Author("a", "Rusov", 20, "mail address"));
            listToReturn.Add(new Author("b", "Dusov", 20, "mail address"));
            listToReturn.Add(new Author("c", "Shrusov", 20, "mail address"));

            // act
            mockIAuthorRepository.Expects.One.GetProperty(_ => _.AllAuthors).WillReturn(listToReturn);
            var facade = new Facade(null, mockIAuthorRepository.MockObject, null, null);
            var foundFirstname = facade.FindAuthorByLastname("Rusov").FirstName;
            // assert
            Assert.AreEqual("a",foundFirstname );
        }
    }
}
