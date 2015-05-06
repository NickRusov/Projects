﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{

    public class Facade : IFacade //, IAuthors, IAdmins, IUsers
    {
        private IArticleRepository IArticleRepository;
        private IAuthorRepository IAuthorRepository;
        private IAdminRepository IAdminRepository;
        private IUserRepository IUserRepository;

        public Article FindArticleById(uint articleId)
        {
            return IArticleRepository.AllArticles.Find(article => article.Id == articleId);
        }

        public Article FindArticleByTitle(string title)
        {
            return IArticleRepository.AllArticles.Find(article => article.Title == title);
        }


        public Author FindAuthorById(uint authorId)
        {
            return IAuthorRepository.AllAuthors.Find(author => author.Id == authorId);
        }

        public Author FindAuthorByLastname(string lastname)
        {
            return IAuthorRepository.AllAuthors.Find(author => author.LastName == lastname);
        }


        public Admin FindAdminById(uint adminId)
        {
            return IAdminRepository.AllAdmins.Find(admin => admin.Id == adminId);
        }

        public Admin FindAdminByLastname(string lastname)
        {
            return IAdminRepository.AllAdmins.Find(admin => admin.LastName == lastname);
        }


        public User FindUserById(uint userId)
        {
            return IUserRepository.AllUsers.Find(user => user.Id == userId);
        }

        public User FindUserByLastname(string lastname)
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

        public double GetArticleAverageRatingById(uint articleId)
        {
            return IArticleRepository.AllArticles.Find(article => article.Id == articleId).Ratings.Average(article => article.Mark);
        }

        public double GetArticleAverageRatingByTitle(string title)
        {
            return IArticleRepository.AllArticles.Find(article => article.Title == title).Ratings.Average(article => article.Mark);
        }


        public string ReadArticleById(uint articleId)
        {
            return IArticleRepository.AllArticles.Find(article => article.Id == articleId).Text;
        }

        public string ReadArticleByTitle(string title)
        {
            return IArticleRepository.AllArticles.Find(article => article.Title == title).Text;
        }

        public string[] ReadCommentsById(uint articleId)
        {
            var foundArticle = IArticleRepository.AllArticles.Find(article => article.Id == articleId);
            string[] comments = new string[foundArticle.Comments.Count];

            for (int i = 0; i < foundArticle.Comments.Count; i++)
            {
                comments[i] = foundArticle.Comments[i].ToString();
            }
            return comments;
        }

        public string[] ReadCommentsByTitle(string title)
        {
            var foundArticle = IArticleRepository.AllArticles.Find(article => article.Title == title);
            string[] comments = new string[foundArticle.Comments.Count];

            for (int i = 0; i < foundArticle.Comments.Count; i++)
            {
                comments[i] = foundArticle.Comments[i].ToString();
            }
            return comments;
            
        }
    }

}
