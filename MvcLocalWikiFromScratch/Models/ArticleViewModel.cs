using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models;
using System.Web;

namespace FLS.LocalWiki.WebApplication.Models
{
    public class ArticleViewModel
    {
        public Article Article
        {
            get; 
            set;
        }

        public NewComment NewComment
        {
            get; 
            set;
        }

        public List<Comment> Comments
        {
            get;
            set;
        }

        public List<Rating> Ratings
        {
            get;
            set;
        }

        public ArticleViewModel()
        {
            NewComment = new NewComment();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }
    }
}