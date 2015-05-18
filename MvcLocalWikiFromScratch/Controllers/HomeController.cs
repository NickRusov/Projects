using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using MvcLocalWikiFromScratch.Models;

namespace MvcLocalWikiFromScratch.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //EntityContext db = new EntityContext();
        private readonly Facade m_facade = (Facade)Initializer.GetInitializedFacade();
        public ActionResult Index()
        {
            ViewBag.Articles = m_facade.AllArticles;//users;
            return View();
        }

        [HttpGet]
        public ActionResult ReadArticle(uint id)
        {
            var article = m_facade.FindArticleById(id);
            ViewBag.Title = article.Title;
            ViewBag.Author = article.Author;
            ViewBag.Text = article.Text;
            ViewBag.Comments = m_facade.ReadCommentsById(id);
            var rating = m_facade.GetArticleAverageRatingById(id);
            if (rating != null)
            {
                ViewBag.AverageRating = rating;
            }
            else
            {
                ViewBag.AverageRating = "the article is not rated yet.";
            }
            return View();
        }
    }
}
