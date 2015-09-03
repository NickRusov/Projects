using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace FLS.LocalWiki.WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "pageBy",
                url: "by{pageBy}p{currentPage}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { pageBy = @"\d+", currentPage = @"\d+" }
                );
            
            routes.MapRoute(null,
                "{pageBy}",
                new { controller = "Home", action = "Index" },
                new { pageBy = @"\d+" }
                );


            routes.MapRoute(
                name: "Read",
                url: "{controller}/{action}/{id}", //  /{pageBy} , pageBy = UrlParameter.Optional
                defaults: new { controller = "Home", action = "ReadArticle", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" }
                );

            routes.MapRoute(
                name: "Initial",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
                );
            //routes.MapRoute(
            //    name: "PageBy",
            //    url: "{controller}/{action}/pageBy={pageBy}",
            //    defaults: new { controller = "Home", action = "Index" });
            //routes.MapRoute(
            //  name: "NewComment",
            //  url: "{controller}/{action}/{articleId}/{comment}", //  /{pageBy} , pageBy = UrlParameter.Optional
            //  defaults: new { controller = "Home", action = "AddComment", articleId = UrlParameter.Optional, comment = UrlParameter.Optional }
            //  );

        }
    }
}