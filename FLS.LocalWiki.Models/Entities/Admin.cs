using System.Collections.Generic;
using System.Text;
using FLS.LocalWiki.Models.Entities;


    namespace FLS.LocalWiki.Models.Entities
    {
        public class Admin : User
        {

            public List<string> Privilege { get; private set; }

            public Admin(string firstname, string lastname, byte age, uint id, string[] privilegies)
                : base(firstname, lastname, age, id)
            {
                this.Privilege = new List<string>(privilegies);
            }

            public Admin(User user, string[] privilegies)
                : base(user)
            {
                this.Privilege = new List<string>(privilegies);
            }

            public new string ToString()
            {
                StringBuilder sb = new StringBuilder(base.ToString());
                sb.AppendLine("privilegies:");
                foreach (var privilege in this.Privilege)
                {
                    sb.AppendLine(privilege);
                }
                return sb.ToString();
            }

        }
    }