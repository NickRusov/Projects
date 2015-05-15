using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> AllUsers
        {
            get; private set;
        }

        public void AddUser(User user)
        {
            AllUsers.Add(user);
        }

        public UserRepository()
        {
            AllUsers = new List<User>();
        }

        public int Count()
        {
            return AllUsers.Count;
        }
    }
}
