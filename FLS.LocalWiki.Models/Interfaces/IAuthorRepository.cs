using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IAuthorRepository
    {
        string ConnectionString { get; }

        List<Author> GetAllAuthors();

        void AddAuthor(Author author);

        int Count();
    }
}
