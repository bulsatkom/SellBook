using SellBook.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Home
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            this.PublicationPartial = new List<PublicationViewModel>();
            this.SearchModel = new SearchPartialViewModel() { GetCategory = false };
        }

        public SearchPartialViewModel SearchModel { get; set; }
        public ICollection<PublicationViewModel> PublicationPartial { get; set; }
    }
}