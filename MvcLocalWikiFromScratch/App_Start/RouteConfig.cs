using System.Web.Mvc;
using System.Web.Routing;

namespace FLS.LocalWiki.WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Paging",
            //    url: "{controller}/{action}/pageBy_{pageBy}#{currentPage}",
            //    defaults: new { controller = "Home", action = "Index" });
            //routes.MapRoute(
            //    name: "PageBy",
            //    url: "{controller}/{action}/pageBy={pageBy}",
            //    defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute(
              name: "NewComment",
              url: "{controller}/{action}/{articleId}/{comment}", //  /{pageBy} , pageBy = UrlParameter.Optional
              defaults: new { controller = "Home", action = "AddComment", articleId = UrlParameter.Optional, comment = UrlParameter.Optional }
              );
        }
    }
}