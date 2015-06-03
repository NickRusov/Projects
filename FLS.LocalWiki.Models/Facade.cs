using System.Collections.Generic;
using System.Linq;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

    namespace FLS.LocalWiki.Models
        {

            public class Facade : IFacade
            {
                private readonly IArticleRepository m_IArticleRepository;
                private readonly IAuthorRepository m_IAuthorRepository;
                private readonly IAdminRepository m_IAdminRepository;
                private readonly IUserRepository m_IUserRepository;

                public IEnumerable<Article> AllArticles {
                    get
                    {
                        return m_IArticleRepository.GetAllArticles();
                    }
                }

                public Article FindArticleById(uint articleId)
                {
                    return m_IArticleRepository.GetAllArticles().Find(article => article.Id == articleId);
                }

                public List<Article> FindArticlesByTitle(string title)
                {
                    return m_IArticleRepository.GetAllArticles().FindAll(article => article.Title == title);
                }


                public Author FindAuthorById(uint authorId)
                {
                    return m_IAuthorRepository.GetAllAuthors().Find(author => author.Id == authorId);
                }

                public List<Author> FindAuthorsByLastname(string lastname)
                {
                    return m_IAuthorRepository.GetAllAuthors().FindAll(author => author.LastName == lastname);
                }


                public Admin FindAdminById(uint adminId)
                {
                    return m_IAdminRepository.GetAllAdmins().Find(admin => admin.Id == adminId);
                }

                public List<Admin> FindAdminsByLastname(string lastname)
                {
                    return m_IAdminRepository.GetAllAdmins().FindAll(admin => admin.LastName == lastname);
                }
                

                public User FindUserById(uint userId)
                {
                    return m_IUserRepository.GetAllUsers().Find(user => user.Id == userId);
                }

                public List<User> FindUsersByLastname(string lastname)
                {
                    return m_IUserRepository.GetAllUsers().FindAll(user => user.LastName == lastname);
                }

                public Facade(IArticleRepository iArticle, IAuthorRepository iAuthor,
                    IAdminRepository iAdmin, IUserRepository iUser)
                {
                    this.m_IArticleRepository = iArticle;
                    this.m_IAuthorRepository = iAuthor;
                    this.m_IAdminRepository = iAdmin;
                    this.m_IUserRepository = iUser;
                }
                
            }

        }
   
