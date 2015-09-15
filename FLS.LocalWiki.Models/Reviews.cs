using System.Collections.Generic;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.Models
{
    public class Reviews
    {
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }

        public Reviews()
        {
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }
    }
}