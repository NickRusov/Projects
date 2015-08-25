using System;
using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;


namespace FLS.LocalWiki.UnitTestsforModels.FakeRepositories
{
    public class FakeUserRepoistory : IUserRepository
    {
        public string ConnectionString
        {
            get { return ""; }
        }

        public List<User> GetAllUsers()
        {
                var listToReturn = new List<User>
                {
                new User("a", "Rusov", 1,20),
                new User("b", "Rusov", 2, 21),
                new User("c", "Rusov", 3, 22)
                };

                return listToReturn;
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