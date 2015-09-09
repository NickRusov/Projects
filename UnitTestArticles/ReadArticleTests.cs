using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.UnitTestsforModels.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FLS.LocalWiki.UnitTestsforModels
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
            var text = facade.FindArticleById(1).Text;

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
            var text = facade.FindArticlesByTitle("C# structures")[0].Text;

            // assert
            Assert.AreEqual("Some text about structures", text);
        }


    }


}
