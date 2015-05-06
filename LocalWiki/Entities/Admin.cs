using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Admin : User
    {

        public List<string> Privilege
        {
            get ; 
            private set ; 
        }
        public Admin(string firstname, string lastname, byte age, string[] privilegies)
            : base (firstname ,lastname, age)
        {
            this.Privilege = new List<string> ( privilegies );
        }
        public Admin(User user, string[] privilegies)
            : base ( user )
        {
            this.Privilege = new List<string> ( privilegies );
        }

        public override string ToString()
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
