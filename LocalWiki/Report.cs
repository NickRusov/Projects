using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Report
    {
        private IFacade facade;

        public Report(IFacade facade)
        {
            this.facade = facade;
        }

        public void DisplayInfoAboutArticleById(uint id)
        {
            Console.WriteLine(facade.FindArticleById(id));
        }

        public void DisplayInfoAboutArticleByTitle(string title)
        {
            Console.WriteLine(facade.FindArticleByTitle(title));
        }

        public void DisplayAuthorById(uint authorId)
        {
            Console.WriteLine(facade.FindAuthorById(authorId).ToString());
        }

        public void DisplayAuthorByLastname(string lastname)
        {
            Console.WriteLine(facade.FindAuthorByLastname(lastname).ToString());
        }

        public void DisplayAdminById(uint adminId)
        {
            Console.WriteLine(facade.FindAdminById(adminId).ToString());
        }

        public void DisplayAdminByLastname(string lastname)
        {
            Console.WriteLine(facade.FindAdminByLastname(lastname).ToString());
        }

        public void DisplayUserById(uint userId)
        {
            Console.WriteLine(facade.FindUserById(userId));
        }
        public void DisplayUserByLastname(string lastname)
        {
            Console.WriteLine(facade.FindUserByLastname(lastname));
        }

        public void GetArticleAverageRating(uint articleId)
        {
            Console.WriteLine(facade.GetArticleAverageRatingById(articleId));
        }
        public void GetArticleAverageRating(string title)
        {
            Console.WriteLine(facade.GetArticleAverageRatingByTitle(title));
        }

        public void DisplayCommentsById(uint articleId)
        {
            foreach (var comment in facade.ReadCommentsById(articleId))
            {
                Console.WriteLine(comment);
            }
            
        }
        public void DisplayCommentsByTitle(string title)
        {
            foreach (var comment in facade.ReadCommentsByTitle(title))
            {
                Console.WriteLine(comment);
            }
            
        }

        public void ReadArticleById(uint id)
        {
            Console.WriteLine(facade.ReadArticleById(id));
        }

        public void ReadArticleByTitle(string title)
        {
            Console.WriteLine(facade.ReadArticleByTitle(title));
        }
    }
}
