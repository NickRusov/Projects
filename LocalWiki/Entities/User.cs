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

        public uint Id
        { 
            get ; 
            private set ; 
        }


        public  string FirstName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public uint Age
        {
            get;
            private set;
        }

        public User(string firstname, string lastname, uint age)
        {
            Id = ++s_uniquePersonCounter;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
        }

         protected User(User user)  
        {
            this.Id = user.Id;         
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Age = user.Age;
        }

         public override string ToString()
         {
             StringBuilder sb= new StringBuilder("User # " + Id);
             sb.AppendLine();
             sb.AppendLine("first name: " + FirstName);
             sb.AppendLine("last name: " + LastName);
             sb.AppendLine("age: " + Age);
             return sb.ToString();
         }
    }
}
