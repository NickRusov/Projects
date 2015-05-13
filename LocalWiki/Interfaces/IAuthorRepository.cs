
using System.Collections.Generic;


namespace LocalWiki
{
    public interface IAuthorRepository
    {
        List<Author> AllAuthors { get; }

        void AddAuthor(Author author);

        int Count();
    }
}
