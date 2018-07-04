using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Publication
{
    public class PublicationsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int? Price { get; set; }

        public string Image { get; set; }

        public DateTime AddedOn { get; set; }

        public string BreadCrumb { get; set; }

        public string City { get; set; }
    }
}