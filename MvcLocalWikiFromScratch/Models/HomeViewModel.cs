using System.Collections.Generic;
using System.Web.Mvc;
using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;

namespace FLS.LocalWiki.WebApplication.Models
{
    public class HomeViewModel
    {
        public PagingInfo PageInfo { get; set; }

        public List<SelectListItem> ItemsforPagingBy { get; set; }

        public IFacade Facade { get; set; }
    }
}