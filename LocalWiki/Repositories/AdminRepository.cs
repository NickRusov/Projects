using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
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
