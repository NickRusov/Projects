﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Rating : Comment
    {
        public byte Mark
        {
            get;
            private set;
        }

        public Rating(string text, User reviewer, byte mark)
            : base(text, reviewer)
        {
            this.Mark = mark;
        }

        public Rating(Comment comment, byte mark) 
            : base(comment)
        { 
            this.Mark = mark;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("mark: "+ Mark);
            return sb.ToString();
        }
    }
}