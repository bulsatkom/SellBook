using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class AnimalsPublicationPartialViewModel
    {
        public AnimalsPublicationPartialViewModel()
        {
            this.DeliveryCollection = new List<SelectListItem>();

            this.Init();
        }

        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "По Договаряне")]
        public bool IsContracting { get; set; }

        [Required]
        [Display(Name = "Доставката се поема от")]
        public string delivery { get; set; }

        public ICollection<SelectListItem> DeliveryCollection { get; set; }

        private void Init()
        {
            if(this.DeliveryCollection.Count == 0)
            {
                this.DeliveryCollection.Add(new SelectListItem()
                {
                    Text = "Избери",
                    Value = "",
                    Selected = true
                });

                this.DeliveryCollection.Add(new SelectListItem()
                {
                    Text = "Купувача",
                    Value = "Купувача"
                });

                this.DeliveryCollection.Add(new SelectListItem()
                {
                    Text = "Продавача",
                    Value = "Продавача"
                });

                this.DeliveryCollection.Add(new SelectListItem()
                {
                    Text = "Лично Предаване",
                    Value = "Лично Предаване"
                });
            }
        }
    }
}