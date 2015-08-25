using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.Models.Repositories
{
    public class DbAdminRepository : IAdminRepository
    {
        private const string m_adminsTableName = "admins";
        private List<Admin> m_allAdmins;

        private readonly string m_connectionString;

        public string ConnectionString {
            get { return m_connectionString; }
        }

        public DbAdminRepository(string connectionString)
        {
            m_connectionString = connectionString;
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
