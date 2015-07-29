using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.WebApplication.Models;

namespace FLS.LocalWiki.WebApplication.Controllers
{
    public class ArticleController : Controller
    {
        //[HttpGet]
        //public ActionResult AddComment()
        //{
        //    //cm.Article.AddComment(new Comment(cm.Comment, null, cm.Article.Comments.Count + 1));
        //    return View();
        //}

        [HttpPost]
        public ActionResult AddComment(PartialComment comment)
        {
            //cm.Article.AddComment(new Comment(cm.Comment, null, cm.Article.Comments.Count + 1));
            return View("PartialComment", comment);
        }
    }
}