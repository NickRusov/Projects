using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{

    public class Facade //: IArticles, IAuthors, IAdmins, IUsers
    {
        private IArticleRepository IArticleRepository;
        private IAuthorRepository IAuthorRepository;
        private IAdminRepository IAdminRepository;
        private IUserRepository IUserRepository;

        public Article FindArticle(uint articleId)
        {
            return IArticleRepository.AllArticles.Find(article => article.Id == articleId);
        }

        public Article FindArticle(string title)
        {
            return IArticleRepository.AllArticles.Find(article => article.Title == title);
        }


        public Author FindAuthor(uint authorId)
        {
            return IAuthorRepository.AllAuthors.Find(author => author.Id == authorId);
        }

        public Author FindAuthor(string lastname)
        {
            return IAuthorRepository.AllAuthors.Find(author => author.LastName == lastname);
        }


        public Admin FindAdmin(uint adminId)
        {
            return IAdminRepository.AllAdmins.Find(admin => admin.Id == adminId);
        }

        public Admin FindAdmin(string lastname)
        {
            return IAdminRepository.AllAdmins.Find(admin => admin.LastName == lastname);
        }


        public User FindUser(uint userId)
        {
            return IUserRepository.AllUsers.Find(user => user.Id == userId);
        }

        public User FindUser(string lastname)
        {
            return IUserRepository.AllUsers.Find(user => user.LastName == lastname);
        }

        public Facade(IArticleRepository iArticle, IAuthorRepository iAuthor,
            IAdminRepository iAdmin, IUserRepository iUser)
        {
            this.IArticleRepository = iArticle;
            this.IAuthorRepository = iAuthor;
            this.IAdminRepository = iAdmin;
            this.IUserRepository = iUser;
        }

        public double GetArticleAverageRating(uint articleId)
        {
            return IArticleRepository.AllArticles.Find(article => article.Id == articleId).Ratings.Average(x=>x.Mark);
        }
    }

}
