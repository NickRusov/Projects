using System;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.ConsoleApplicaion
{
    public class Report
    {
        private readonly IFacade m_facade;

        public Report(IFacade facade)
        {
            this.m_facade = facade;
        }

        public void DisplayInfoAboutArticle(uint articleId)
        {
            var foundArticle = m_facade.FindArticleById(articleId);
            if (foundArticle != null)
                Console.WriteLine(foundArticle+"Average rating:"+foundArticle.AverageRating.ToString()+"\n");
            else
                Console.WriteLine("Article with id = {0} does not exist", articleId);
        }

        public void ReadArticle(uint articleId)
        {
            var foundArticle = m_facade.FindArticleById(articleId);
            if (foundArticle != null)
                Console.WriteLine(foundArticle + foundArticle.Text);
            else
                Console.WriteLine("Article with id = {0} does not exist", articleId);
        }

        public void FindArticles(string title)
        {
            var foundArticles = m_facade.FindArticlesByTitle(title);
            if (foundArticles.Count > 0)
                foreach (var article in foundArticles)
                    Console.WriteLine(article + "Average rating:" + article.AverageRating.ToString());
            else
                Console.WriteLine("Article with title {0} does not exist", title);
        }


        public void DisplayAuthor(uint authorId)
        {
            var foundAuthor = m_facade.FindAuthorById(authorId);
            if (foundAuthor != null)
                Console.WriteLine(m_facade.FindAuthorById(authorId).ToString());
            else
                Console.WriteLine("Author with id = {0} does not exist", authorId);
        }

        public void FindAuthors(string lastname)
        {
            var foundAuthors = m_facade.FindAuthorsByLastname(lastname);
            if (foundAuthors.Count > 0)
                foreach (var author in foundAuthors)
                    Console.WriteLine(author);
            else
                Console.WriteLine("Author with lastname \"{0}\" does not exist", lastname);
        }

        
        public void DisplayAdmin(uint adminId)
        {
            var foundAdmin = m_facade.FindAdminById(adminId);
            if (foundAdmin != null)
                Console.WriteLine(foundAdmin.ToString());
            else
                Console.WriteLine("Admin with id = {0} does not exist", adminId);
        }

        public void FindAdmins(string lastname)
        {
            var foundAdmins = m_facade.FindAdminsByLastname(lastname);
            if (foundAdmins.Count > 0)
                foreach (var admin in foundAdmins)
                    Console.WriteLine(admin);
            else
                Console.WriteLine("Admin with lastname \"{0}\" does not exist", lastname);
        }


        
        public void DisplayUser(uint userId)
        {
            var foundUser = m_facade.FindUserById(userId);
            if (foundUser != null)
                Console.WriteLine(m_facade.FindUserById(userId));
            else
                Console.WriteLine("User with id = {0} does not exist", userId);
        }

        public void FindUsers(string lastname)
        {
            var foundUsers = m_facade.FindUsersByLastname(lastname);
            if ( foundUsers.Count > 0 )
                foreach (var user in foundUsers)
                    Console.WriteLine(user);
            else
                Console.WriteLine("User with lastname \"{0}\" does not exist", lastname);
        }

        
                   
    }
}
