using System.Collections.Generic;
using System.Security.Policy;
using FLS.LocalWiki.WebApplication.Models;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;

namespace FLS.LocalWiki.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFacade m_facade = SingleContainer.Instance.GetFacade(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private HomeViewModel m_homeViewModel;

        // GET: /by{pageBy}p{currentPage}

        public ActionResult Index(int pageBy = 2, int currentPage = 1) //, string sortBy = null
        {
            m_homeViewModel = new HomeViewModel
            {
                PageInfo = new PagingInfo
                {
                    CurrentPage = currentPage,
                    PageBy = pageBy,
                    TotalPages = m_facade.FillPage(currentPage, pageBy)
                },
                ItemsforPagingBy = new List<SelectListItem>(3)
                {
                    new SelectListItem
                    {
                        Text = "1",
                        Value = "1"
                    },
                    new SelectListItem
                    {
                        Text = "2",
                        Value = "2"
                    },
                    new SelectListItem
                    {
                        Text = "3",
                        Value = "3"
                    }
                },
                Facade = m_facade
            };

            m_homeViewModel.ItemsforPagingBy.Find(item => (item.Value == pageBy.ToString())).Selected = true;
            return View(m_homeViewModel);
        }
        
        // GET: /Home/ReadArticle/@article.Id

        [HttpGet]
        public ActionResult ReadArticle(int id)
        {
            var articleViewModel = new ArticleViewModel
            {
                Article = m_facade.FindArticleById(id)
            };
            return View("~/Views/Article/ReadArticle.cshtml", articleViewModel);
        }
    }
}
