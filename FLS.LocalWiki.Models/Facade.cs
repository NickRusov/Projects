using System;
using System.Collections.Generic;
using System.Linq;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;

namespace FLS.LocalWiki.Models
{
    public class Facade : IFacade
    {
        private readonly IArticleRepository m_articleRepository;
        private readonly IAuthorRepository m_authorRepository;
        private readonly IAdminRepository m_adminRepository;
        private readonly IUserRepository m_userRepository;

        public Facade(
            IArticleRepository articleRepository,
            IAuthorRepository authorRepository,
            IAdminRepository adminRepository,
            IUserRepository userRepository)
        {
            this.m_articleRepository = articleRepository;
            this.m_authorRepository = authorRepository;
            this.m_adminRepository = adminRepository;
            this.m_userRepository = userRepository;
        }
       
        public IEnumerable<Article> AllArticles
        {
            get
            {
                return m_articleRepository.GetAllArticles();
            }
        }

        public string AdminConnectionString
        {
            get { return m_adminRepository.ConnectionString; }
        }

        public string ArticleConnectionString
        {
            get { return m_articleRepository.ConnectionString; }
        }

        public string AuthorConnectionString
        {
            get { return m_authorRepository.ConnectionString; }
        }

        public string UserConnectionString
        {
            get { return m_userRepository.ConnectionString; }
        }

        public int FillPage(int currentPage, int pageBy)
        {
            return m_articleRepository.LoadPage(currentPage, pageBy);
        }

        public Article FindArticleById(int articleId)
        {
            return m_articleRepository.GetArticle(articleId);
        }

        public bool AddComment(NewComment newComment)
        {
            return m_articleRepository.AddComment(newComment);

        }

        public Reviews GetReviews(int articleId)
        {
            return m_articleRepository.GetReviews(articleId);
        }





        public List<Article> FindArticlesByTitle(string title)
        {
            return m_articleRepository.GetAllArticles().ToList().FindAll(article => article.Title == title);
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
