using FLS.LocalWiki.Models.Entities;
using System.Collections.Generic;


namespace  FLS.LocalWiki.Models.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        void AddUser(User user);

        int Count();
    }
}
