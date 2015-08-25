using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IUserRepository
    {
        string ConnectionString { get; }

        List<User> GetAllUsers();

        void AddUser(User user);

        int Count();
    }
}
