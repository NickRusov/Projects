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

        /*public static uint ObjectCounter
        { get { return objectCounter; } }*/

        protected readonly uint id;

        public uint Id
        { get { return id; } }

        private readonly string m_text;     // text is always the same. If a reviewer has something to add, he must create a new comment.

        public string Text
        { get { return m_text; } }

        private readonly User m_reviewer;   // reviewer is always the same

        public User Reviewer
        { get { return m_reviewer; } }

        public Comment(string text, User reviewer)
        {
            this.id = ++s_commentCounter;
            this.m_text = text;
            this.m_reviewer = reviewer;
        }

        /*protected Comment(string text, User reviewer, bool newCommentFlag)
        {
            this.m_text= text;
            this.m_reviewer = reviewer;
            if (newCommentFlag)
                m_id = ++s_commentCounter;
        }*/

        protected Comment(Comment comment)      // if user want to mark an existing comment
        {
            this.id = comment.id;
            this.m_text = comment.m_text;
            this.m_reviewer = comment.m_reviewer;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Comment # " + id);
            sb.AppendLine();
            sb.Append(m_reviewer);
            sb.AppendLine(m_text);
            return sb.ToString();
        }
    }
}
