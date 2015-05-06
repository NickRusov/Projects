using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
     public interface IFacade
    {
            Article FindArticleById (uint id);
            Article FindArticleByTitle(string title);

            Author FindAuthorById (uint authorId);
            Author FindAuthorByLastname (string lastname);
       
            Admin FindAdminById (uint adminId);
            Admin FindAdminByLastname (string lastname);
       
            User FindUserById (uint userId);
            User FindUserByLastname (string lastname);

            double GetArticleAverageRatingById(uint articleId);
            double GetArticleAverageRatingByTitle(string title);

            string ReadArticleById(uint articleId);
            string ReadArticleByTitle(string title);

            string[] ReadCommentsById(uint articleId);
            string[] ReadCommentsByTitle(string title);

    }
}
