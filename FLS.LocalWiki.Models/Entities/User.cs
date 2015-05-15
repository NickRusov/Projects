using System.Text;

namespace FLS.LocalWiki.Models.Entities
{
    public class User : ProEntity
    {

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

        public User(string firstname, string lastname, uint age, uint id)
        {
            Id = id;
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
