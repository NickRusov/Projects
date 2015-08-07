using System;
using FLS.LocalWiki.WebApplication.Models;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;

namespace FLS.LocalWiki.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        private IFacade m_facade = SingleContainer.Instance.GetFacade();

        public ActionResult Index(int pageBy = 2)
        {
            DbHelper.SetConnectionString(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            m_facade.CurrentPage = 1;
            m_facade.PageBy = pageBy;
            m_facade.TotalPages = m_facade.FillPage();
            return View(m_facade);
        }

        // GET: /Home/ReadArticle/@article.Id

        [HttpGet]
        public ActionResult ReadArticle(int id)
        {
            var articleViewModel = new ArticleViewModel();
            articleViewModel.Article = m_facade.FindArticleById(id);
            return View("~/Views/Article/ReadArticle.cshtml", articleViewModel);
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
        public ActionResult AddComment(/*int userId,*/ int articleId, string comment) //NewComment newComment)
        {
            m_facade.AddComment(new NewComment(1, articleId, comment));
            return ReadArticle(articleId);
            //m_facade.AddComment(new NewComment(1, newComment.ArticleId, newComment.Comment));
            //return ReadArticle(newComment.ArticleId);
        }
    }
}
