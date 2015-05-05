using System;
using System.Collections.Generic;
using System.Linq;
using LocalWiki;
using NMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestArticles
{
    [TestClass]
    public class UnitTest3
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
        public void PropertyTest()
        {
            var mockIArticleRepository = _factory.CreateMock<IArticleRepository>();
            var mockIAuthorRepository = _factory.CreateMock<IAuthorRepository>();
            var mockIAdminRepository = _factory.CreateMock<IAdminRepository>();
            var mockIUserRepository = _factory.CreateMock<IUserRepository>();
            List<Article> listToReturn = new List<Article>(3);
            listToReturn.Add(new Article(new Author("a", "Rusov", 20, "mail address"), "C# classes", "Some text about classes"));
            listToReturn.Add(new Article(new Author("b", "Rusov", 20, "mail address"), "C# interfaces",
                "Some text about interfaces"));
            listToReturn.Add(new Article(new Author("c", "Rusov", 20, "mail address"), "C# structures",
                "Some text about structures"));

            mockIArticleRepository.Expects.One.GetProperty(_ => _.AllArticles).WillReturn(listToReturn);
            

            var facade = new Facade(mockIArticleRepository.MockObject,mockIAuthorRepository.MockObject,mockIAdminRepository.MockObject,mockIUserRepository.MockObject);
            Assert.AreEqual("a", facade.FindArticle("C# classes").Author.FirstName);
        }

        [TestMethod]
        public void FindArticleByIdTest()
        {
            // arrange
            IArticleRepository Iarticle = new FakeArticleRepoistiry();
            IAuthorRepository Iauthor = new AuthorRepository();
            IAdminRepository Iadmin = new AdminRepository();
            IUserRepository Iuser = new UserRepository();
            var facade = new Facade(Iarticle,Iauthor,Iadmin,Iuser);

            

            // act
            uint foundId = facade.FindArticle("C# classes").Id;
            // assert

            Assert.AreEqual((uint)4, foundId );
            //Assert.AreEqual(, facade.FindArticle("C#").Id);
        }

        [TestMethod]
        public void FindAuthorByLastnameTest()
        {
            // arrange
            var mockIArticleRepository = _factory.CreateMock<IArticleRepository>();
            var mockIAuthorRepository = _factory.CreateMock<IAuthorRepository>();
            var mockIAdminRepository = _factory.CreateMock<IAdminRepository>();
            var mockIUserRepository = _factory.CreateMock<IUserRepository>();
            List<Author> listToReturn = new List<Author>(3);
            listToReturn.Add(new Author("a", "Rusov", 20, "mail address"));
            listToReturn.Add(new Author("b", "Dusov", 20, "mail address"));
            listToReturn.Add(new Author("c", "Shrusov", 20, "mail address"));

            // act
            mockIAuthorRepository.Expects.One.GetProperty(_ => _.AllAuthors).WillReturn(listToReturn);
            var facade = new Facade(mockIArticleRepository.MockObject, mockIAuthorRepository.MockObject, mockIAdminRepository.MockObject, mockIUserRepository.MockObject);
            var foundFirstname = facade.FindAuthor("Rusov").FirstName;
            // assert
            Assert.AreEqual("a",foundFirstname );
        }
    }
}
