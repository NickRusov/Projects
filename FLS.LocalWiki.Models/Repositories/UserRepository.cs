using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> m_allUsers;
        public List<User> GetAllUsers()
        {
            return m_allUsers;
        }

        public void AddUser(User user)
        {
            m_allUsers.Add(user);
        }

        public UserRepository()
        {
            m_allUsers = new List<User>();
        }

        public int Count()
        {
            return m_allUsers.Count;
        }
    }
}
