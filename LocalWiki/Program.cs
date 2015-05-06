using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    class Program
    {
        static void Main()
        {
            Facade facade = Initializer.GetIniatializedFacade();
            var report = new Report(facade);
            report.DisplayInfoAboutArticleById(2);
            //report.DisplayUserByLastname("Rusov");
            //report.GetArticleAverageRating("C# classes");
            report.DisplayAuthorById(2);
            Console.WriteLine("Next is Admin");
            report.DisplayAdminById(3);
            Console.WriteLine("Here comments");
            report.DisplayCommentsById(1);
            report.ReadArticleByTitle("C# interfaces");
            /*string[] priv = {"delete","edit"};
            var ad = new Admin("a","b", 30, priv);
            Console.WriteLine(ad.ToString());*/
            
            //report.DisplayArticleByTitle("C# structures");
            //report.ReadArticle("C# structure");
        }
    }
}
