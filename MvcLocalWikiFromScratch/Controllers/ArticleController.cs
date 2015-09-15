using System.Web.Configuration;
using System.Web.Mvc;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.WebApplication.Models;

namespace FLS.LocalWiki.WebApplication.Controllers
{
    public class ArticleController : Controller
    {
        private IFacade m_facade = SingleContainer.Instance.GetFacade(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        [HttpPost]
        public ActionResult AddComment(/*int userId,*/ int articleId, string comment)
        {
            m_facade.AddComment(new NewComment(1, articleId, comment));
            var articleViewModel = new ArticleViewModel
            {
                Article = m_facade.FindArticleById(articleId)
            };
            return View("ReadArticle", articleViewModel);
        }

        public ActionResult LoadReviews(int articleId)
        {
            return PartialView("Reviews", m_facade.GetReviews(articleId));
        }
    }
}