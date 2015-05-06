using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
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
