using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class AuthorRepository
    {
        private List<Author> m_authors;

        public List<Author> AllAuthors 
        { get { return m_authors; } }

        public void AddAuthor(Author author)
        {
            m_authors.Add(author);
        }

        public AuthorRepository()
        {
            m_authors=new List<Author>();
        }

        public int Count()
        {
            return m_authors.Count;
        }
    }
}
