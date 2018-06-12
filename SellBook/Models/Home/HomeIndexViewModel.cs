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
        }

        public ICollection<PublicationViewModel> PublicationPartial { get; set; }
    }
}