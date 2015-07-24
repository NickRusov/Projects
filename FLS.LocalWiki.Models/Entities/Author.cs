using System.Text;

namespace FLS.LocalWiki.Models.Entities
{
    public class Author : User
    {
        public Author(string firstname, string lastname, short age, int id, string email)
            : base(firstname, lastname, age, id)
        {
            this.Email = email;
        }

        public Author(User user, string email)
            : base(user)
        {
            this.Email = email;
        }

        public string Email
        {
            get;
            private set;
        }

        public new string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("e-mail: " + this.Email);
            return sb.ToString();
        }
    }
}
