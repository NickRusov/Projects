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
            //report.DisplayArticleById(1);
            report.FindUserByLastname("Rusov");
            report.GetArticleAverageRating("C# classes");
            report.DisplayCommentsById(1);
            report.FindUserById(3);
            //report.DisplayArticleByTitle("C# structures");
            //report.ReadArticle("C# structure");
        }
    }
}
