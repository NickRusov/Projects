using System;
using System.Data;
using System.Configuration;
using System.IO;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models.Repositories;

namespace FLS.LocalWiki.ConsoleApplicaion
{
    class Program
    {
        static void Main()
        {
            var assemlyPath = AppDomain.CurrentDomain.BaseDirectory;
            var appDataPath = Path.Combine(assemlyPath.Substring(0, assemlyPath.LastIndexOf('L')), ".\\MvcLocalWikiFromScratch\\App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", (Path.GetFullPath(appDataPath)));//

            var facade = SingleContainer.Instance.GetFacade(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //var r = DbHelper.GetArticlesFromDb(1, 2, facade.ArticleConnectionString);
            //foreach (DataRow row in r.Rows)
            //    Console.WriteLine((string)(row["title"]));
            Console.WriteLine(DbHelper.GetTotalInTable("articles", facade.ArticleConnectionString));
        }
    }
}
