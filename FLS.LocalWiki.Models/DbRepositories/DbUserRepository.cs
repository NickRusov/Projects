using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class DbUserRepository : IUserRepository
    {
        private List<User> m_allUsers;

        public DbUserRepository()
        {
            m_allUsers = new List<User>();
        }

        public List<User> GetAllUsers()
        {
            return m_allUsers;
        }

        public void AddUser(User user)
        {
            m_allUsers.Add(user);
        }

        public int Count()
        {
            return m_allUsers.Count;
        }
    }
}
