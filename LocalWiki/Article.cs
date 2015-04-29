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

        private readonly uint m_id;

        public uint Id
        { get { return m_id; } }

        private readonly Author m_author;       // author is always the same

        public Author Author
        { get { return m_author; } }

        private readonly string m_title;        // title is always the same too

        public string Title
        { get { return m_title; } }

        private string m_text;                  // author and administrators can change the content
        public Article(Author author, string title, string text)
        {
            m_id = ++s_articleCounter;
            this.m_author = author;
            this.m_title = title;
            this.m_text = text;
            m_comments = new List<Comment>();
            m_ratings = new List<Rating>();
        }
        private List<Comment> m_comments;

        public List<Comment> Comments
        { get { return m_comments; } }

        public void AddComment(Comment comment)
        {
            m_comments.Add(comment);
        }

        private List<Rating> m_ratings;

        public void AddRating(Rating rating)
        {
            m_ratings.Add(rating);
        }

        public List<Rating> Ratings
        { get { return m_ratings; } }

        public int CountRatings
        { get { return m_ratings.Count; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Article # " + m_id);
            /*foreach (var rating in this.ratings)
            {
                ratings.
            }*/
            //ratings.Average()
            sb.AppendLine();
            sb.Append(m_author.ToString());
            sb.AppendLine("title: " + m_title);
            return sb.ToString();
        }
    }
}
