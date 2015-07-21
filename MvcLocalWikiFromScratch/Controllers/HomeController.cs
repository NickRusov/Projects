using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.WebApplication.Models;

namespace FLS.LocalWiki.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        //EntityContext db = new EntityContext();
        private readonly IFacade m_facade = SingleContainer.Instance.GetInitializedFacade(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public ActionResult Index()
        {
            return View(m_facade.AllArticles);
        }

        // GET: /Home/ReadArticle/@article.Id

        [HttpGet]
        public ActionResult ReadArticle(int id)
        {
            var model = new NewCommentModel();
            model.Article = m_facade.FindArticleById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult AddComment()
        {
            //cm.Article.AddComment(new Comment(cm.Comment, null, cm.Article.Comments.Count + 1));
            return View();
        }
    
        [HttpPost]
        public ActionResult AddComment(NewCommentModel cm)
        {
            cm.Article.AddComment(new Comment(cm.Comment, new User("", "", 1, 45), cm.Article.Comments.Count + 1));
            return View(cm);
        }
    }
}
