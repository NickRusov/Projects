using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Rating : Comment
    {
        

        /*public static uint ObjectCounter
        { get { return objectCounter; } }
        public uint Id
        { get { return id; } }
        private uint id;*/

        private readonly byte m_mark;

        public byte Mark
        { get { return m_mark; } }

        public Rating(string text, User reviewer, byte mark)
            : base(text, reviewer)
        {
            this.m_mark = mark;
        }

        public Rating(Comment comment, byte mark)  // to mark an existing comment
            : base(comment)
        { 
            this.m_mark = mark;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("mark: "+m_mark);
            return sb.ToString();
        }
    }
}
