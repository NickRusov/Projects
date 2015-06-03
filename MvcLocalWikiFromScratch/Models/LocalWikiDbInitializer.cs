using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.WebApplication.Models
{
    public class LocalWikiDbInitializer : DropCreateDatabaseAlways<EntityContext>
    {
        protected override void Seed(EntityContext db)
        {
            db.Users.Add(new User("A", "Rusov", 20, 1));
            db.Users.Add(new User("B", "Rusov", 21, 2));
            db.Users.Add(new User("C", "Rusov", 22, 3));

            base.Seed(db);
        }
    }
}
