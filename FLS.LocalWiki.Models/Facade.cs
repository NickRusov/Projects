using System.Collections.Generic;
using System.Linq;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS
{
    namespace FLS.LocalWiki
    {
        namespace FLS.LocalWiki.Models
        {
            namespace FLS.LocalWiki.Models.Entities
            {
            }

            namespace FLS.LocalWiki.Models.Interfaces
            {
            }

            namespace FLS.LocalWiki.Models.Repositories
            {
            }
        }
    }
}


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
                        return m_IArticleRepository.AllArticles;
                    }
                }

                public Article FindArticleById(uint articleId)
                {
                    return m_IArticleRepository.AllArticles.Find(article => article.Id == articleId);
                }

                public Article FindArticleByTitle(string title)
                {
                    return m_IArticleRepository.AllArticles.Find(article => article.Title == title);
                }


                public Author FindAuthorById(uint authorId)
                {
                    return m_IAuthorRepository.AllAuthors.Find(author => author.Id == authorId);
                }

                public Author FindAuthorByLastname(string lastname)
                {
                    return m_IAuthorRepository.AllAuthors.Find(author => author.LastName == lastname);
                }


                public Admin FindAdminById(uint adminId)
                {
                    return m_IAdminRepository.AllAdmins.Find(admin => admin.Id == adminId);
                }

                public Admin FindAdminByLastname(string lastname)
                {
                    return m_IAdminRepository.AllAdmins.Find(admin => admin.LastName == lastname);
                }


                public User FindUserById(uint userId)
                {
                    return m_IUserRepository.AllUsers.Find(user => user.Id == userId);
                }

                public User FindUserByLastname(string lastname)
                {
                    return m_IUserRepository.AllUsers.Find(user => user.LastName == lastname);
                }

                public Facade(IArticleRepository iArticle, IAuthorRepository iAuthor,
                    IAdminRepository iAdmin, IUserRepository iUser)
                {
                    this.m_IArticleRepository = iArticle;
                    this.m_IAuthorRepository = iAuthor;
                    this.m_IAdminRepository = iAdmin;
                    this.m_IUserRepository = iUser;
                }

                public double? GetArticleAverageRatingById(uint articleId)
                {
                    var foundArticle = FindArticleById(articleId);
                    if (foundArticle != null)
                        return foundArticle.Ratings.Average(article => article.Mark);
                    return null;
                }

                public double? GetArticleAverageRatingByTitle(string title)
                {
                    var foundArticle = FindArticleByTitle(title);
                    if (foundArticle != null)
                        return foundArticle.Ratings.Average(article => article.Mark);
                    return null;
                }


                public string ReadArticleById(uint articleId)
                {
                    var foundArticle = FindArticleById(articleId);
                    if (foundArticle != null)
                        return foundArticle.Text;
                    return null;
                }

                public string ReadArticleByTitle(string title)
                {
                    var foundArticle = FindArticleByTitle(title);
                    if (foundArticle != null)
                        return foundArticle.Text;
                    return null;
                }

                public string[] ReadCommentsById(uint articleId)
                {
                    var foundArticle = m_IArticleRepository.AllArticles.Find(article => article.Id == articleId);
                    if (foundArticle == null)
                        return null;
                    string[] comments = new string[foundArticle.Comments.Count];

                    for (int i = 0; i < foundArticle.Comments.Count; i++)
                    {
                        comments[i] = foundArticle.Comments[i].ToString();
                    }
                    return comments;
                }

                public string[] ReadCommentsByTitle(string title)
                {
                    var foundArticle = m_IArticleRepository.AllArticles.Find(article => article.Title == title);
                    if (foundArticle == null)
                        return null;
                    string[] comments = new string[foundArticle.Comments.Count];

                    for (int i = 0; i < foundArticle.Comments.Count; i++)
                    {
                        comments[i] = foundArticle.Comments[i].ToString();
                    }
                    return comments;

                }
            }

        }
   
