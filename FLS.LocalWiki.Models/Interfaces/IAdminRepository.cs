using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmins();

        void AddAdmin(Admin admin);

        int Count();
    }
}
