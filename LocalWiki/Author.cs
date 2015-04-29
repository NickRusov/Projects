using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Author : User
    {
        /*public uint Id
        { get { return id; } }*/

        private readonly string m_email;

        public string Email
        {
            get { return m_email; }
        }
        public Author(string firstname, string lastname, byte age, string email)
            : base (firstname,lastname,age)
        {
            this.m_email = email;
        }
        public Author(User user, string email)
            : base(user)
        {
            this.m_email = email;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("e-mail: "+this.m_email);
            return sb.ToString();
        }
    }
}
