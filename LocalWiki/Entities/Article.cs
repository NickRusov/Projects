using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public class Article : ProEntity
    {

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

        public Article(Author author, string title, string text, uint id)
        {
            Id = id;
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
            sb.AppendLine();
            sb.Append(Author.ToString());
            sb.AppendLine("title: " + Title);
            return sb.ToString();
        }
    }
}
