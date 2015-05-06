using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class FakeArticleRepoistiry : IArticleRepository
    {

    public List<Article> AllArticles
        {
            get
            {
                var listToReturn= new List<Article>(3);
                listToReturn.Add(new Article(new Author("a", "Rusov", 20, "mail adress"), "C# classes", "Some text about classes"));
                listToReturn.Add(new Article(new Author("b", "Rusov", 20, "mail adress"), "C# interfaces",
                    "Some text about interfaces"));
                listToReturn.Add(new Article(new Author("c", "Rusov", 20, "mail adress"), "C# structures",
                    "Some text about structures"));
                return listToReturn;
            }
        }
    }
}
