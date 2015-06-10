using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Initializing;
using System.Web.Configuration;

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

        [HttpGet]
        public ActionResult ReadArticle(int id)
        {
            return View(m_facade.FindArticleById(id));
        }
    }
}
