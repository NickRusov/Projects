using System.Linq;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using LocalWiki;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestArticles
{
    [TestClass]
    public class ReadCommentsTests
    {
        [TestMethod]
        public void ReadExistingCommentsOfExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.FindArticleById(1).Comments;

            // assert
            string[] forChecking = 
            {
            @"Comment # 1
User # 3
first name: c
last name: Rusov
age: 22
Not bad.
",
            @"Comment # 2
User # 2
first name: b
last name: Rusov
age: 21
Cool!
"
             };
            Assert.AreEqual(comments[0].ToString(),forChecking[0]);
        }



        [TestMethod]
        public void ReadNonExistingCommentsOfExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.FindArticleById(1).Comments;

            // assert
            Assert.AreEqual(2, comments.Count);
        }

        [TestMethod]
        public void ReadCommentsOfNonExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.FindArticlesByTitle("C#");

            // assert
            Assert.AreEqual(0, comments.Count);
        }

    }


}
