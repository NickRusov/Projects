using System;
using System.Collections.Generic;


namespace LocalWiki
{
    public class FakeAdminRepoistory : IAdminRepository
    {

        public List<Admin> AllAdmins
        {
            get
            {
                string[] privilegies = { "delete", "edit" };
                var listToReturn = new List<Admin>
                {
                    new Admin("a", "Rusov", 1, 20, privilegies),
                    new Admin("b", "Rusov", 2, 20, privilegies),
                    new Admin("c", "Rusov", 3, 20, privilegies)
                };
                return listToReturn;
            }
        }

        public void AddAdmin(Admin admin)
        {
        }

        public int Count()
        {
            return 3;
        }
    }
}