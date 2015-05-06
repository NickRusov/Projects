using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Comment
    {
        protected static uint s_commentCounter = 0;

        protected readonly uint id;

        public uint Id
        {
            get;
            private set;
        }

       public string Text
        {
            get;
            private set;
        }

        public User Reviewer
        {
            get;
            private set;
        }

        public Comment(string text, User reviewer)
        {
            this.Id = ++s_commentCounter;
            this.Text = text;
            this.Reviewer = reviewer;
        }

        protected Comment(Comment comment)      // if user want to mark an existing comment
        {
            this.Id = comment.Id;
            this.Text = comment.Text;
            this.Reviewer = comment.Reviewer;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Comment # " + Id);
            sb.AppendLine();
            sb.Append(Reviewer);
            sb.AppendLine(Text);
            return sb.ToString();
        }
    }
}
