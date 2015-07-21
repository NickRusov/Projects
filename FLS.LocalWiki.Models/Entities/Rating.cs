using System.Text;

namespace FLS.LocalWiki.Models.Entities
{
    public class Rating : Comment
    {
        public Rating(string text, User reviewer, byte mark, int id)
            : base(text, reviewer, id)
        {
            this.Mark = mark;
        }

        public Rating(Comment comment, byte mark) 
            : base(comment)
        { 
            this.Mark = mark;
        }

        public byte Mark
        {
            get;
            private set;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("mark: " + Mark);
            return sb.ToString();
        }
    }
}
