using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.IO;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models.Interfaces;
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

            var facade = SingleContainer.Instance.GetFacade();
            DbHelper.SetConnectionString(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var r = DbHelper.GetArticlesFromDb(1, 2);
            foreach (DataRow row in r.Rows)
                Console.WriteLine((string)(row["title"]));
            Console.WriteLine(DbHelper.GetTotalInTable(Table.articles));
            //var facade = SingleContainer.Instance.GetInitializedFacade(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //var report = new Report(facade);
            //foreach (var article in facade.AllArticles)
            //{
            //    Console.WriteLine(article);
            //}
            //report.DisplayInfoAboutArticle(1);
            //report.DisplayAuthor(52);
            //Console.WriteLine("Next is Admin");
            //report.DisplayAdmin(3);
            //Console.WriteLine("Here text");
            //report.ReadArticle(3);
            //report.FindArticles("C# classes");
            //report.FindUsers("");
        }
    }
}
