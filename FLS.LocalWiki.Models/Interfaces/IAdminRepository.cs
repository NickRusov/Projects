using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IAdminRepository
    {
        string ConnectionString { get; }

        List<Admin> GetAllAdmins();

        void AddAdmin(Admin admin);

        int Count();
    }
}
