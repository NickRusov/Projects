using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Report
    {
        private IFacade Ifacade;

        public Report(IFacade Ifacade)
        {
            this.Ifacade = Ifacade;
        }

        public void FindArticle(uint id)
        {
            Console.WriteLine(Ifacade.FindArticle(id));
        }

        public void FindArticle(string title)
        {
            Console.WriteLine(Ifacade.FindArticle(title));
        }

        public void FindAuthor(uint authorId)
        {
            Console.WriteLine(Ifacade.FindAuthor(authorId));
        }
        public void FindAuthor(string lastname)
        {
            Console.WriteLine(Ifacade.FindAuthor(lastname));
        }

        public void FindAdmin(uint adminId)
        {
            Console.WriteLine(Ifacade.FindAdmin(adminId));
        }
        public void FindAdmin(string lastname)
        {
            Console.WriteLine(Ifacade.FindAdmin(lastname));
        }

        public void FindUser(uint userId)
        {
            Console.WriteLine(Ifacade.FindUser(userId));
        }
        public void FindUser(string lastname)
        {
            Console.WriteLine(Ifacade.FindUser(lastname));
        }

        public void GetArticleAverageRating(uint articleId)
        {
            Console.WriteLine(Ifacade.GetArticleAverageRating(articleId));
        }
        public void GetArticleAverageRating(string title)
        {
            Console.WriteLine(Ifacade.GetArticleAverageRating(title));
        }

        public void ReadComments(uint articleId)
        {
            foreach (var comment in Ifacade.ReadComments(articleId))
            {
                Console.WriteLine(comment);
            }
            
        }

        public void ReadComments(string title)
        {
            foreach (var comment in Ifacade.ReadComments(title))
            {
                Console.WriteLine(comment);
            }
            
        }

        public void ReadArticle(uint id)
        {
            Console.WriteLine(Ifacade.ReadArticle(id));
        }

        public void ReadArticle(string title)
        {
            Console.WriteLine(Ifacade.ReadArticle(title));
        }
    }
}
