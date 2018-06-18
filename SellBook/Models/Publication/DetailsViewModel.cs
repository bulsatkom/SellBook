using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Publication
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            this.ImagesUrls = new List<string>();
            this.OtherUserPublications = new List<PublicationViewModel>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PublicationAuthorName { get; set; }

        public Guid PublicationId { get; set; }

        public int Views { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<PublicationViewModel> OtherUserPublications { get; set; }

        public ICollection<string> ImagesUrls { get; set; }
    }
}