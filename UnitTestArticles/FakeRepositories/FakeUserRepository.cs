using System;
using System.Collections.Generic;


namespace LocalWiki
{
    public class FakeUserRepoistory : IUserRepository
    {

        public List<User> AllUsers
        {
            get
            {
                var listToReturn = new List<User>
                {
                new User("a", "Rusov", 20),
                new User("b", "Rusov", 21),
                new User("c", "Rusov", 22)
                };

                return listToReturn;
            }
        }

        public void AddUser(User user)
        {
        }

        public int Count()
        {
            return 3;
        }
    }
}