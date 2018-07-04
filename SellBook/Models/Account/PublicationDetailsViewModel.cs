using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Account
{
    public class PublicationDetailsViewModel
    {
        public PublicationDetailsViewModel()
        {
            this.ActivePublication = new List<MyPublicationsViewModel>();
            this.ArchivedPublication = new List<MyPublicationsViewModel>();
        }

        public ICollection<MyPublicationsViewModel> ActivePublication { get; set; }

        public ICollection<MyPublicationsViewModel> ArchivedPublication { get; set; }
    }
}