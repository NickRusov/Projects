using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace LocalWiki
{
    public class FakeAuthorRepoistory : FLS.LocalWiki.Models.Interfaces.IAuthorRepository
    {
        public List<Author> AllAuthors
        {
            get
            {
                const string mail = "e-mail@example.com";
                var listToReturn = new List<Author>
                {
                    new Author("a", "Rusov", 20, 1, mail),
                    new Author("b", "Rusov", 21, 2, mail),
                    new Author("c", "Rusov", 22, 3, mail)
                };
                return listToReturn;
            }
        }

        public void AddAuthor(Author author)
        {
        }

        public int Count()
        {
            return 3;
        }
    }
}