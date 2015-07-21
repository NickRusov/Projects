using System.Collections.Generic;
using System.Linq;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models
    {
        public class Facade : IFacade
        {
            private readonly IArticleRepository m_articleRepository;
            private readonly IAuthorRepository m_authorRepository;
            private readonly IAdminRepository m_adminRepository;
            private readonly IUserRepository m_userRepository;

            public Facade(
                IArticleRepository iArticle, 
                IAuthorRepository iAuthor,
                IAdminRepository iAdmin, 
                IUserRepository iUser)
            {
                this.m_articleRepository = iArticle;
                this.m_authorRepository = iAuthor;
                this.m_adminRepository = iAdmin;
                this.m_userRepository = iUser;
            }

            public IEnumerable<Article> AllArticles
            {
                get
                {
                    return m_articleRepository.GetAllArticles();
                }
            }

            public Article FindArticleById(int articleId)
            {
                return m_articleRepository.GetAllArticles().Find(article => article.Id == articleId);
            }

            public List<Article> FindArticlesByTitle(string title)
            {
                return m_articleRepository.GetAllArticles().FindAll(article => article.Title == title);
            }

            public Author FindAuthorById(int authorId)
            {
                return m_authorRepository.GetAllAuthors().Find(author => author.Id == authorId);
            }

            public List<Author> FindAuthorsByLastname(string lastname)
            {
                return m_authorRepository.GetAllAuthors().FindAll(author => author.LastName == lastname);
            }

            public Admin FindAdminById(int adminId)
            {
                return m_adminRepository.GetAllAdmins().Find(admin => admin.Id == adminId);
            }

            public List<Admin> FindAdminsByLastname(string lastname)
            {
                return m_adminRepository.GetAllAdmins().FindAll(admin => admin.LastName == lastname);
            }

            public User FindUserById(int userId)
            {
                return m_userRepository.GetAllUsers().Find(user => user.Id == userId);
            }

            public List<User> FindUsersByLastname(string lastname)
            {
                return m_userRepository.GetAllUsers().FindAll(user => user.LastName == lastname);
            }
        }
    }  
