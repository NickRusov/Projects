using FLS.LocalWiki.Models.Entities;
using System.Collections.Generic;


namespace FLS.LocalWiki.Models.Interfaces
{
    public interface IAdminRepository
    {
        List<Admin> AllAdmins { get; }

        void AddAdmin(Admin admin);

        int Count();
    }
}
