
using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public List<Admin> AllAdmins
        {
            get ; private set;
        }

        public void AddAdmin(Admin admin)
        {
            AllAdmins.Add(admin);
        }

        public AdminRepository()
        {
            AllAdmins=new List<Admin>();
        }

        public int Count()
        {
            return AllAdmins.Count;
        }
    }
}
