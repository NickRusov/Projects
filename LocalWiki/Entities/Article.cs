using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Article
    {
        private static uint s_articleCounter = 0;

        public uint Id
        {
            get; 
            private set;
        }

        public Author Author
        {
            get;
            private set;
        }

        public string Title
        {
            get;
            private set;
        }

        public string Text
        {
            get;
            private set;
        }

        public Article(Author author, string title, string text)
        {
            Id = ++s_articleCounter;
            this.Author = author;
            this.Title = title;
            this.Text = text;
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }

        public List<Comment> Comments
        {
            get; 
            private set;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public List<Rating> Ratings
        {
            get;
            private set;
        }

        public void AddRating(Rating rating)
        {
            Ratings.Add(rating);
        }

        public int CountRatings
        { get { return Ratings.Count; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Article # " + Id);
            //Ratings.Average(x => x.Mark);
            sb.AppendLine();
            sb.Append(Author.ToString());
            sb.AppendLine("title: " + Title);
            return sb.ToString();
        }
    }
}
