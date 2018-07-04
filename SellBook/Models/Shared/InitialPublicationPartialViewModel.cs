using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class InitialPublicationPartialViewModel
    {
        public InitialPublicationPartialViewModel()
        {
            this.ConditionCollection = new List<SelectListItem>();
            this.DeliveryCollection = new List<SelectListItem>();

            this.Init();
        }

        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "По Договаряне")]
        public bool IsContacting { get; set; }

        [Required]
        [Display(Name = "Състояние")]
        public string Condition { get; set; }

        [Required]
        [Display(Name = "Доставката се Поема от")]
        public string Delivery { get; set; }

        public ICollection<SelectListItem> ConditionCollection { get; set; }

        public ICollection<SelectListItem> DeliveryCollection { get; set; }

        private void Init()
        {
            if (this.ConditionCollection.Count == 0 && this.DeliveryCollection.Count == 0)
            {
                this.ConditionCollection.Add(new SelectListItem()
                {
                    Text = "Ново",
                    Value = "Ново",
                });

                this.ConditionCollection.Add(new SelectListItem()
                {
                    Text = "Използвано",
                    Value = "Използвано",
                });

                this.ConditionCollection.Add(new SelectListItem()
                {
                    Text = "Избери",
                    Value = "",
                    Selected = true
                });

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