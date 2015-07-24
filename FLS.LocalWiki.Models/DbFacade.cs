using System;
using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;

namespace FLS.LocalWiki.Models
{
    public class DbFacade : IFacade
    {
        public ushort currentPage = 1;
        //private int totalPages;
        private readonly IArticleRepository m_articleRepository;
        private readonly IAuthorRepository m_authorRepository;
        private readonly IAdminRepository m_adminRepository;
        private readonly IUserRepository m_userRepository;

        public DbFacade(
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

        public int CurrentPage
        {
            get;
            set;
        }

        public int PageBy
        {
            get;
            set;
        }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(DbHelper.GetTotalInTable(Table.articles) / Convert.ToDouble(PageBy));
            }
        }

        public IEnumerable<Article> AllArticles
        {
            get
            {
                return m_articleRepository.GetAllArticles();
            }
        }

        public void FillPage()
        {
            m_articleRepository.LoadPage(CurrentPage, PageBy);
            return;
        }

        public Article FindArticleById(int articleId)
        {

            return m_articleRepository.GetArticle(articleId);
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
