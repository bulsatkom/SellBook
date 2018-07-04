using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class SearchPartialViewModel
    {
        public SearchPartialViewModel()
        {
            this.CategoriesCollection = new List<SelectListItem>();
            this.RegionsCollection = new List<SelectListItem>();
        }

        public string Query { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? Region { get; set; }

        public ICollection<SelectListItem> CategoriesCollection { get; set; }

        public ICollection<SelectListItem> RegionsCollection { get; set; }

        public bool GetCategory { get; set; }

        public int PublicationCount { get; set; }
    }
}