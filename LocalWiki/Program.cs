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
            Report report = new Report(facade);
            report.FindArticle(1);
            report.FindUser("Rusov");
            report.GetArticleAverageRating("C# classes");
            report.ReadComments(1);
            report.FindUser(3);
            report.FindArticle("C# structures");
            //report.ReadArticle("C# structure");
        }
    }
}
