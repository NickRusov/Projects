using System;
using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;


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
                new User("a", "Rusov", 1,20),
                new User("b", "Rusov", 2, 21),
                new User("c", "Rusov", 3, 22)
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