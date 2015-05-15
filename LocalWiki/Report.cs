using System;
using FLS.LocalWiki.Models.Interfaces;

namespace LocalWiki
{
    public class Report
    {
        private readonly IFacade m_facade;

        public Report(IFacade facade)
        {
            this.m_facade = facade;
        }

        public void DisplayInfoAboutArticleById(uint id)
        {
            Console.WriteLine(m_facade.FindArticleById(id));
        }

        public void DisplayInfoAboutArticleByTitle(string title)
        {
            Console.WriteLine(m_facade.FindArticleByTitle(title));
        }

        public void DisplayAuthorById(uint authorId)
        {
            Console.WriteLine(m_facade.FindAuthorById(authorId).ToString());
        }

        public void DisplayAuthorByLastname(string lastname)
        {
            Console.WriteLine(m_facade.FindAuthorByLastname(lastname).ToString());
        }

        public void DisplayAdminById(uint adminId)
        {
            Console.WriteLine(m_facade.FindAdminById(adminId).ToString());
        }

        public void DisplayAdminByLastname(string lastname)
        {
            Console.WriteLine(m_facade.FindAdminByLastname(lastname).ToString());
        }

        public void DisplayUserById(uint userId)
        {
            Console.WriteLine(m_facade.FindUserById(userId));
        }
        public void DisplayUserByLastname(string lastname)
        {
            Console.WriteLine(m_facade.FindUserByLastname(lastname));
        }

        public void GetArticleAverageRating(uint articleId)
        {
            Console.WriteLine(m_facade.GetArticleAverageRatingById(articleId));
        }
        public void GetArticleAverageRating(string title)
        {
            Console.WriteLine(m_facade.GetArticleAverageRatingByTitle(title));
        }

        public void DisplayCommentsById(uint articleId)
        {
            foreach (var comment in m_facade.ReadCommentsById(articleId))
            {
                Console.WriteLine(comment);
            }
            
        }
        public void DisplayCommentsByTitle(string title)
        {
            foreach (var comment in m_facade.ReadCommentsByTitle(title))
            {
                Console.WriteLine(comment);
            }
            
        }

        public void ReadArticleById(uint id)
        {
            Console.WriteLine(m_facade.ReadArticleById(id));
        }

        public void ReadArticleByTitle(string title)
        {
            Console.WriteLine(m_facade.ReadArticleByTitle(title));
        }
    }
}
