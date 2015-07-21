using System.Text;

namespace FLS.LocalWiki.Models.Entities
{
    public class User : ProEntity
    {
        public User(string firstname, string lastname, short age, int id)
        {
            Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
        }

        protected User(User user) : this(user.FirstName, user.LastName, user.Age, user.Id)
        {
        }

        public string FirstName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public short Age
        {
            get;
            private set;
        }

         public override string ToString()
         {
             StringBuilder sb = new StringBuilder("User # " + Id);
             sb.AppendLine();
             sb.AppendLine("first name: " + FirstName);
             sb.AppendLine("last name: " + LastName);
             sb.AppendLine("age: " + Age);
             return sb.ToString();
         }
    }
}
