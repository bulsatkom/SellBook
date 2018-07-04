using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Account
{
    public class MyPublicationsViewModel
    {
        public Guid PublicationID { get; set; }

        public DateTime AddedOn { get; set; }

        public string ImageName { get; set; }

        public string Title { get; set; }

        public int? Price { get; set; }

        public int MessagesNumbers { get; set; }

        public bool isActive { get; set; }

        public int Views { get; set; }

        public int AddedAsFavourite { get; set; }

        public int ViewPhone { get; set; }
    }
}