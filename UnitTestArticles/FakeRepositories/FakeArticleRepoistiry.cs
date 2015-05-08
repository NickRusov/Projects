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
                var listToReturn = new List<Article>
                {
                    new Article(new Author("a", "Rusov", 20, "mail adress"),
                        "C# classes",
                        "Some text about classes"),
                    new Article(new Author("b","Rusov",21,"mail adress"),
                        "C# interfaces",
                        "Some text about interfaces"),
                    new Article(new Author("c","Rusov",22,"mail adress"),
                        "C# structures",
                        "Some text about structures")
                };
                listToReturn[0].AddComment(new Comment("Not bad.", listToReturn[2].Author));
                listToReturn[0].AddComment(new Comment("Cool!", listToReturn[1].Author));
                
                listToReturn[0].AddRating(new Rating("firstComment", listToReturn[2].Author, 8));
                listToReturn[0].AddRating(new Rating("secondComment", listToReturn[1].Author, 9));
                return listToReturn;
            }
        }

        public void AddArticle(Article article)
        {}

        public int Count()
        {
            return 3;
        }
    }
}
