using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBook.Models.Publication
{
    public class PublicationDetailViewModel
    {
        public PublicationDetailViewModel()
        {
            this.ImagesUrls = new List<string>();
            this.OtherUserPublications = new List<PublicationViewModel>();
            this.Details = new DetailsModel();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PublicationAuthorName { get; set; }

        public Guid PublicationId { get; set; }

        public string City { get; set; }

        public int Price { get; set; }

        public int Views { get; set; }

        public string PhoneNumber { get; set; }

        public DetailsModel Details { get; set; }

        public string MainImageSrc { get; set; }

        public ICollection<PublicationViewModel> OtherUserPublications { get; set; }

        public ICollection<string> ImagesUrls { get; set; }
    }
}