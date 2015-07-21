using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class DbAdminRepository : IAdminRepository
    {
        private List<Admin> m_allAdmins;

        public DbAdminRepository()
        {
            m_allAdmins = new List<Admin>();
        }
        
        public List<Admin> GetAllAdmins()
        {
            return m_allAdmins;
        }

        public void AddAdmin(Admin admin)
        {
            m_allAdmins.Add(admin);
        }        

        public int Count()
        {
            return m_allAdmins.Count;
        }
    }
}
