using System;
using System.Collections.Generic;


namespace LocalWiki
{
    public interface IUserRepository
    {
        List<User> AllUsers { get; }

        void AddUser(User user);

        int Count();
    }
}
