using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using FLS.LocalWiki.Models.Entities;

namespace FLS.LocalWiki.WebApplication.Models
{
    public class NewCommentModel
    {
        //public NewCommentModel(Article article)
        //{
        //    this.Article = article;
        //}
        [Required]
        public Article Article;
        //{
        //    get;
        //    set;
        //}

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Your comment:")]
        public string Comment { get; set; }
    }
}