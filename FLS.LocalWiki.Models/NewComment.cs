using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FLS.LocalWiki.Models
{
    public class NewComment
    {
        [Required]
        public int UserId
        {
            get;
            set;
        }

        [Required]
        [HiddenInput]
        public int ArticleId
        {
            get;
            set;
        }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Your comment:")]
        public string Comment
        {
            get;
            set;
        }

        public NewComment()
        {
        }


        public NewComment(int userId, int articleId, string comment)
        {
            this.UserId = userId;
            this.ArticleId = articleId;
            this.Comment = comment;
        }
    }
}
