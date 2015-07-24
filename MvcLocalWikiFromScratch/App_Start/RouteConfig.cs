using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //routes.MapRoute(
            //    name: "Paging",
            //    url: "{controller}/{action}/{currentPage}/{pageBy}/{next}",
            //    defaults: new { controller = "Home", action = "Index", currentPage = UrlParameter.Optional, pageBy = UrlParameter.Optional, next = UrlParameter.Optional });

            //routes.MapRoute(
            //  name: "Paging",
            //  url: "{controller}/{action}/{currentPage}&{pageBy}", //  /{pageBy} , pageBy = UrlParameter.Optional
            //  defaults: new { controller = "Home", action = "Next", currentPage = UrlParameter.Optional }
            //  );
        
        }
    }
}