using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class ServicePublicationPartialViewModel
    {
        public ServicePublicationPartialViewModel()
        {
            this.IsPrivateCollection = new List<SelectListItem>();

            this.Initial();
        }

        [Required]
        public bool IsPrivate { get; set; }

        public ICollection<SelectListItem> IsPrivateCollection { get; set; }

        private void Initial()
        {
            if(this.IsPrivateCollection.Count == 0)
            {
                this.IsPrivateCollection.Add(new SelectListItem()
                {
                    Text = "Частна",
                    Value = "true"
                });

                this.IsPrivateCollection.Add(new SelectListItem()
                {
                    Text = "Бизнес",
                    Value = "false"
                });
            }
        }
    }
}