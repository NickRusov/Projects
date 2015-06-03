using FLS.LocalWiki.Models.Entities;
using System.Collections.Generic;


namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmins();

        void AddAdmin(Admin admin);

        int Count();
    }
}
