using System.Collections.Generic;
using System.Text;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models.Entities
    {
        public class Admin : User
        {               
            public Admin(string firstname, string lastname, byte age, int id, string[] privilegies)
                : base(firstname, lastname, age, id)
            {
                this.Privileges = new List<string>(privilegies);
            }

            public Admin(User user, string[] privilegies)
                : base(user)
            {
                this.Privileges = new List<string>(privilegies);
            }

            public List<string> Privileges
            {   
                get;
                private set;
            }

            public new string ToString()
            {
                StringBuilder sb = new StringBuilder(base.ToString());
                sb.AppendLine("privilegies:");
                foreach (var privilege in this.Privileges)
                {
                    sb.AppendLine(privilege);
                }

                return sb.ToString();
            }
        }
    }