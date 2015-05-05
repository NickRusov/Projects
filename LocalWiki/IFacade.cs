using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
     public interface IFacade
    {
            Article FindArticle(uint id);
            Article FindArticle(string title);

            Author FindAuthor(uint authorId);
            Author FindAuthor(string lastname);
       
            Admin FindAdmin(uint adminId);
            Admin FindAdmin(string lastname);
       
            User FindUser(uint userId);
            User FindUser(string lastname);

            double GetArticleAverageRating(uint articleId);
            double GetArticleAverageRating(string title);

            string ReadArticle(uint articleId);
            string ReadArticle(string title);

            string[] ReadComments(uint articleId);
            string[] ReadComments(string title);

    }
}
