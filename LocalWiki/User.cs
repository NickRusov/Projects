using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class User
    {
        private static uint s_uniquePersonCounter = 0;

        protected readonly uint id;

        public uint Id
        { get { return id; } }

        private readonly string m_firstname;

        public  string FirstName
        { get { return m_firstname; } }

        private readonly string m_lastname;

        public string LastName
        { get { return m_lastname; } }

        private readonly uint m_age;

        public uint Age
        { get { return m_age; } }

        public User(string firstname, string lastname, uint age)
        {
            id = ++s_uniquePersonCounter;
            this.m_firstname = firstname;
            this.m_lastname = lastname;
            this.m_age = age;
        }

         protected User(User user)       // for Author and Admin
        {
            this.id = user.id;          // the same ID for Admin amd Author. Field uniquePersonCounter is also the same.
            this.m_firstname = user.m_firstname;
            this.m_lastname = user.m_lastname;
            this.m_age = user.m_age;
        }

         public override string ToString()
         {
             StringBuilder sb= new StringBuilder("User # "+id);
             sb.AppendLine();
             sb.AppendLine("first name: " + m_firstname);
             sb.AppendLine("last name: " + m_lastname);
             sb.AppendLine("age: " + m_age);
             return sb.ToString();
         }
    }
}
