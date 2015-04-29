using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class UserRepository
    {
        private List<User> m_users;

        public List<User> AllUsers 
        { get { return m_users; } }

        public void AddUser(User user)
        {
            m_users.Add(user);
        }

        public UserRepository()
        {
            m_users=new List<User>();
        }

        public int Count()
        {
            return m_users.Count;
        }
    }
}
