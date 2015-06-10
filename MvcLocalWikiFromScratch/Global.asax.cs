using System;
using System.IO;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace FLS.LocalWiki.WebApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var baseProjectPath = AppDomain.CurrentDomain.BaseDirectory;
            var appDataPath = Path.Combine(baseProjectPath, ".\\App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(appDataPath));
            //Database.SetInitializer(new LocalWikiDbInitializer());
        }
    }
}