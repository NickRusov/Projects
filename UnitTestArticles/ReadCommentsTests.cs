using System;
using System.Diagnostics;
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
            var comments = facade.ReadCommentsById(1);

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
            for (var i = 0; i < comments.Length; i++)
            {
                Assert.AreEqual(forChecking[i], comments[i]);
            }
            
        }

        [TestMethod]
        public void ReadExistingCommentsOfExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.ReadCommentsByTitle("C# classes");

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
            for (var i = 0; i < comments.Length; i++)
            {
                Assert.AreEqual(forChecking[i], comments[i]);
            }

        }


        [TestMethod]
        public void ReadNonExistingCommentsOfExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.ReadCommentsById(4);

            // assert
            Assert.AreEqual(null, comments);
        }

        [TestMethod]
        public void ReadNonExistingCommentsOfExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.ReadCommentsByTitle("C# intefaces");

            // assert
            Assert.AreEqual(null, comments); 
        }

        [TestMethod]
        public void ReadCommentsOfNonExistingArticleById()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.ReadCommentsById(100);

            // assert
            Assert.AreEqual(null, comments);
        }

        [TestMethod]
        public void ReadCommentsOfNonExistingArticleByTitle()
        {
            // arrange
            IArticleRepository articleRepository = new FakeArticleRepoistiry();
            var facade = new Facade(articleRepository, null, null, null);

            // act
            var comments = facade.ReadCommentsByTitle("C#");

            // assert
            Assert.AreEqual(null, comments);
        }

    }


}
