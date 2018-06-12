using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models
{
    public class PublicationViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }
    }
}