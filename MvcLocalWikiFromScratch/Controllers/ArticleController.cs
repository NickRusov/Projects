using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models;

namespace FLS.LocalWiki.WebApplication.Controllers
{
    public class ArticleController : Controller
    {
        //[HttpGet]
        //public ActionResult AddComment()
        //{
        //    //cm.Article.AddComment(new Comment(cm.Comment, null, cm.Article.Comments.Count + 1));
        //    return PartialView("Comments");
        //}

        [HttpPost]
        public PartialViewResult AddComment(int userId, int articleId, string comment)
        {
            return PartialView("Comments", new NewComment(userId, articleId, comment));
        }
    }
}