using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FLS.LocalWiki.Models.Entities
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

        public Article(Author author, string title, string text, int id)
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

        public double? AverageRating
        { 
            get 
            {
                if (Ratings.Count > 0)
                    return Ratings.Average(rating => rating.Mark);
                return null;
            } 
        }

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
