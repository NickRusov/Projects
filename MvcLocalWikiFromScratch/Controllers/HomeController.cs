using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;
using FLS.LocalWiki.WebApplication.Models;

namespace FLS.LocalWiki.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        private IFacade m_facade = SingleContainer.Instance.GetFacade();

        public ActionResult Index()
        {
            DbHelper.SetConnectionString(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            m_facade.CurrentPage = 1;
            m_facade.PageBy = 2;
            m_facade.TotalPages = m_facade.FillPage();
            return View(m_facade);
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

        // GET: /Home/Next/
        [HttpGet]
        public ActionResult Next(int cur, int by)
        {
            DbHelper.SetConnectionString(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            if (cur < m_facade.TotalPages)
            {
                m_facade.CurrentPage = cur + 1;
            }
            else
            {
                m_facade.CurrentPage = cur;
            }
            m_facade.PageBy = by;
            m_facade.TotalPages = m_facade.FillPage();
            return View("Index", m_facade);
        }

        // GET: /Home/Previous/
        [HttpGet]
        public ActionResult Previous(int cur, int by)
        {
            m_facade.PageBy = by;
            DbHelper.SetConnectionString(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            if (cur > 2)
            {
                m_facade.CurrentPage = cur - 1;                
            }
            else
            {
                m_facade.CurrentPage = 1;
            }
            m_facade.FillPage();
            return View("Index", m_facade);
        }


        [HttpPost]
        public ActionResult AddComment(NewCommentModel cm)
        {
            cm.Article.AddComment(new Comment(cm.Comment, new User("", "", 1, 45), cm.Article.Comments.Count + 1));
            return View(cm);
        }
    }
}
