using System;
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
            //report.DisplayUserByLastname("Rusov");
            //report.GetArticleAverageRating("C# classes");
            report.DisplayAuthor(52);
            Console.WriteLine("Next is Admin");
            report.DisplayAdmin(3);
            Console.WriteLine("Here text");
            report.ReadArticle(3);
            report.FindArticles("C# classes");
            report.FindUsers("");
            //report.DisplayCommentsById(1);
            //report.ReadArticleByTitle("C# interfaces");
            //report.DisplayCommentsByTitle("C#"); // C# classes
            /*string[] priv = {"delete","edit"};
            var ad = new Admin("a","b", 30, priv);
            Console.WriteLine(ad.ToString());*/
            
            //report.DisplayInfoAboutArticleByTitle("");
            //report.ReadArticle("C# structure");
        }
    }
}
