using System;
using System.Configuration;
using System.IO;
using FLS.LocalWiki.Initializing;
using FLS.LocalWiki.Models.Interfaces;
using StructureMap;
namespace FLS.LocalWiki.ConsoleApplicaion
{
    class Program
    {
        static void Main()
        {
            var facade = SingleContainer.Instance.GetInitializedFacade();
            var report = new Report(facade);
            report.DisplayInfoAboutArticle(1);
            report.DisplayAuthor(52);
            Console.WriteLine("Next is Admin");
            report.DisplayAdmin(3);
            Console.WriteLine("Here text");
            report.ReadArticle(3);
            report.FindArticles("C# classes");
            report.FindUsers("");
        }
    }
}
