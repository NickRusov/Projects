using FLS.LocalWiki.Models.Entities;
using System.Collections.Generic;


namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IAuthorRepository
    {
        List<Author> AllAuthors { get; }

        void AddAuthor(Author author);

        int Count();
    }
}
