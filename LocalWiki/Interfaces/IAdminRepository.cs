using System;
using System.Collections.Generic;


namespace LocalWiki
{
    public interface IAdminRepository
    {
        List<Admin> AllAdmins { get; }

        void AddAdmin(Admin admin);

        int Count();
    }
}
