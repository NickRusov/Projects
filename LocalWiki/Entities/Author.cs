using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Author : User
    {

        public string Email
        {
            get;
            private set;
        }

        public Author(string firstname, string lastname, byte age, uint id, string email)
            : base ( firstname, lastname, age, id)
        {
            this.Email = email;
        }
        public Author(User user, string email)
            : base(user)
        {
            this.Email = email;
        }
        public new string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("e-mail: " + this.Email);
            return sb.ToString();
        }
    }
}
