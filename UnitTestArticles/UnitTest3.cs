﻿using System;
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
        public void FindArticleTest()
        {
            var mockArticleRepository = _factory.CreateMock<ArticleRepository>();//<IArticles>();
            var mockAuthorRepository = _factory.CreateMock<AuthorRepository>();
            var mockAdminRepository = _factory.CreateMock<AdminRepository>();
            var mockUserRepository = _factory.CreateMock<UserRepository>();


            List<Article> listArticle = new List<Article>();
            listArticle.Add(new Article(new Author("a", "Rusov", 20, "mail adress"), "C# classes", "Some text about classes"));
            listArticle.Add(new Article(new Author("b", "Rusov", 20, "mail adress"), "C# interfaces",
                "Some text about interfaces"));
            listArticle.Add(new Article(new Author("c", "Rusov", 20, "mail adress"), "C# structures",
                "Some text about structures"));
            //listArticle

            mockArticleRepository.Expects.One.GetProperty(_ => _.AllArticles).WillReturn(listArticle);//new List<Article>());//(new Article(new Author("", "", 24, ""), "Title", "text"));
            /*mockArticleRepository.Expects.One.MethodWith(_ => _.AllArticles).WillReturn(new List<Article>());
            mockArticleRepository.Expects.One.MethodWith(_ => _.AllArticles).WillReturn(new List<Article>());
            mockArticleRepository.Expects.One.MethodWith(_ => _.AllArticles).WillReturn(new List<Article>());
*/
            //var articleRepository = new ArticleRepository(mock.MockObject);
            var facade = new Facade(mockArticleRepository.MockObject, mockAuthorRepository.MockObject, mockAdminRepository.MockObject,mockUserRepository.MockObject);
            var iArt = (IArticles) facade;
            Assert.AreEqual((uint)1, iArt.Find(1).Id);
        }


        /*public interface IArticles
        {
            //string Prop { get; set; }
            Article FindArticle(uint id); //{ get; }
            List<Article> AllArticles { get; }
            //string Method(Version version);
        }*/



       /* public class ArticleRepository
        {
            //private List<Article> m_articles;
            private IArticles _test;
            public ArticleRepository(IArticles test)
            {
                _test = test;
            }

        public List<Article> AllArticles
        {
            get
            {
                /*List<Article> list = new List<Article>(3);
                list.Add(new Article(new Author("", "Rusov", 20, "mail adress"), "C# classes", "Some text about classes"));
                list.Add(new Article(new Author("", "Rusov", 20, "mail adress"), "C# interfaces",
                    "Some text about interfaces"));
                list.Add(new Article(new Author("", "Rusov", 20, "mail adress"), "C# structures",
                    "Some text about structures"));#1#
                return _test.AllArticles;
            }
        }

            public Article FindArticle(uint id)
            {
                return _test.FindArticle(id);
                //return new Article(new Author("","",25,"" ),"","");
            }

            /*public string PropActions(string arg1)
            {
                _test.Prop = arg1;
                return _test.Prop + arg1;
            }#1#
            /*public Article Find(uint id)
            {
                return _test.Method(a, b, c, d);
            }
            public string GetVersion(Version version)
            {
                return _test.Method(version).ToString();
            }#1#
        }*/
    }
}
