using System;

namespace FLS.LocalWiki.Models
{
    public class PagingInfo
    {
        public int PageBy { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}