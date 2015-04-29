using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class AdminRepository
    {
        private List<Admin> m_admins;

        public List<Admin> AllAdmins 
        { get { return m_admins; } }

        public void AddAdmin(Admin admin)
        {
            m_admins.Add(admin);
        }

        public AdminRepository()
        {
            m_admins=new List<Admin>();
        }

        public int Count()
        {
            return m_admins.Count;
        }
    }
}
