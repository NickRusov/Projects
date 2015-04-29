using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{

    public interface IArticles
    {
        Article Find(uint articleid);
        Article Find(string title);
    }

    public interface IAuthors
    {
        Author Find(uint id);
        Author Find(string lastname);
    }

    public interface IAdmins
    {
        Admin Find(uint id);
        Admin Find(string lastname);
    }

    public interface IUsers
    {
        User Find(uint id);
        User Find(string lastname);
    }



    public class Facade : IArticles, IAuthors, IAdmins, IUsers
    {
        /*public IArticles IArticles;
        public IAuthors IAuthors;
        public IAdmins IAdmins;
        public IUsers IUsers;*/

        private ArticleRepository m_articleRepository;
        private AuthorRepository m_authorRepository;
        private AdminRepository m_adminRepository;
        private UserRepository m_userRepository;


        Article IArticles.Find(uint articleId)
        {
            return m_articleRepository.AllArticles.Find(article => article.Id == articleId);
        }

        Article IArticles.Find(string title)
        {
            //StringBuilder result = new StringBuilder(repo.AllArticles.Find(delegate(Article article){ article.Id == id;}).Title);
            foreach (var article in m_articleRepository.AllArticles)
            {
                if (article.Title == title)
                    return article;
            }
            return null;
        }


        Author IAuthors.Find(uint authorId)
        {
            //StringBuilder result = new StringBuilder(repo.AllAuthors.Find(delegate(Author article){ article.Id == id;}).Title);
            foreach (var author in m_authorRepository.AllAuthors)
            {
                if (author.Id == authorId)
                    return author;
            }
            return null;
        }

        Author IAuthors.Find(string lastname)
        {
            //StringBuilder result = new StringBuilder(repo.AllAuthors.Find(delegate(Author article){ article.Id == id;}).Title);
            foreach (var author in m_authorRepository.AllAuthors)
            {
                if (author.LastName == lastname)
                    return author;
            }
            return null;
        }


        Admin IAdmins.Find(uint adminId)
        {
            //StringBuilder result = new StringBuilder(repo.AllAdmins.Find(delegate(Admin article){ article.Id == id;}).Title);
            foreach (var admin in m_adminRepository.AllAdmins)
            {
                if (admin.Id == adminId)
                    return admin;
            }
            return null;
        }

        Admin IAdmins.Find(string lastname)
        {
            //StringBuilder result = new StringBuilder(repo.AllAdmins.Find(delegate(Admin article){ article.Id == id;}).Title);
            foreach (var admin in m_adminRepository.AllAdmins)
            {
                if (admin.LastName == lastname)
                    return admin;
            }
            return null;
        }


        User IUsers.Find(uint userId)
        {
            //StringBuilder result = new StringBuilder(repo.AllUsers.Find(delegate(User article){ article.Id == id;}).Title);
            foreach (var user in m_userRepository.AllUsers)
            {
                if (user.Id == userId)
                    return user;
            }
            return null;
        }

        User IUsers.Find(string lastname)
        {
            //StringBuilder result = new StringBuilder(repo.AllUsers.Find(delegate(User article){ article.Id == id;}).Title);
            foreach (var user in m_userRepository.AllUsers)
            {
                if (user.LastName == lastname)
                    return user;
            }
            return null;
        }


        public Facade(ArticleRepository articleRepository, AuthorRepository authorRepository,
            AdminRepository adminRepository, UserRepository userRepository)
        {
            m_articleRepository = articleRepository;
            m_authorRepository = authorRepository;
            m_adminRepository = adminRepository;
            m_userRepository = userRepository;
        }

        /*public Facade(IArticles iArticle)/*, IAuthors iAuthor,
            IAdmins iAdmin, IUsers iUser)#1#
        {
            this.IArticles = iArticle;
            /*this.IAuthors = iAuthor;
            this.IAdmins = iAdmin;
            this.IUsers = iUser;#1#
        }*/

        /*public Article FindArticleById(uint articleId)
        {
            
            //StringBuilder result = new StringBuilder(repo.AllArticles.Find(delegate(Article article){ article.Id == id;}).Title);
            foreach (var article in m_articleRepository.AllArticles)
            {
                if (article.Id == articleId)
                    return article;
            }
            return null; 
        }

        public Article FindArticleByTitle(string title)
        {
            //StringBuilder result = new StringBuilder(repo.AllArticles.Find(delegate(Article article){ article.Id == id;}).Title);
            foreach (var article in m_articleRepository.AllArticles)
            {
                if (article.Title == title)
                    return article;
            }
            return null;
        }*/

        public double GetArticleAverageRating(uint articleId)
        {

            return m_articleRepository.AllArticles.Find(article => article.Id == articleId).Ratings.Average(x=>x.Mark);
            
            /*foreach (var article in m_articleRepository.AllArticles)
            {
                if (article.Id == articleId && article.CountRatings > 0)
                {
                    uint sum=0;
                    foreach (var rating in article.Ratings)             // ReSharper advices to use LINQ-expression instead of loop
                    {
                        sum += rating.Mark;
                    }
                    return sum/article.CountRatings;
                }
                
            }*/
            //return 0;

        }
    }

}
