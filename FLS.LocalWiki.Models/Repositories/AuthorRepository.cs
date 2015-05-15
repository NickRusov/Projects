using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
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
