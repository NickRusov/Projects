using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class DbAuthorRepository : IAuthorRepository
    {
        private List<Author> m_allAuthors;

        public DbAuthorRepository()
        {
            m_allAuthors = new List<Author>();
        }

        public List<Author> GetAllAuthors()
        {
            return m_allAuthors; 
        }

        public void AddAuthor(Author author)
        {
            m_allAuthors.Add(author);
        }        

        public int Count()
        {
            return m_allAuthors.Count;
        }
    }
}
