﻿using System.Text;

namespace FLS.LocalWiki.Models.Entities
{
    public class Comment : UniqueEntity
    {
       public Comment(string text, User reviewer, int id)
        {
            this.Id = id;
            this.Text = text;
            this.Reviewer = reviewer;
        }

        protected Comment(Comment comment) : this(comment.Text, comment.Reviewer, comment.Id)
        {
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
