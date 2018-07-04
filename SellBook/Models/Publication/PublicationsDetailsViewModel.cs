using SellBook.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Publication
{
    public class PublicationsDetailsViewModel
    {
        public PublicationsDetailsViewModel()
        {
            this.Publications = new List<PublicationsViewModel>();
        }

       public ICollection<PublicationsViewModel> Publications { get; set; }

       public SearchPartialViewModel Search { get; set; }
    }
}