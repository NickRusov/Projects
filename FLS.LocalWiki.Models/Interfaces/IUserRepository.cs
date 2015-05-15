using FLS.LocalWiki.Models.Entities;
using System.Collections.Generic;


namespace  FLS.LocalWiki.Models.Interfaces
{
    public interface IUserRepository
    {
        List<User> AllUsers { get; }

        void AddUser(User user);

        int Count();
    }
}
