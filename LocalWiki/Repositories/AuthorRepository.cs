using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class AuthorRepository : IAuthorRepository
    {

        public List<Author> AllAuthors 
        { 
            get ; 
            private set; 
        }

        public void AddAuthor(Author author)
        {
            AllAuthors.Add(author);
        }

        public AuthorRepository()
        {
            AllAuthors=new List<Author>();
        }

        public int Count()
        {
            return AllAuthors.Count;
        }
    }
}
