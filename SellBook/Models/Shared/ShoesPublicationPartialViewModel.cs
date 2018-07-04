using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class ShoesPublicationPartialViewModel
    {
        public ShoesPublicationPartialViewModel()
        {
            this.ConditionCollection = new List<SelectListItem>();
            this.DeliveryCollection = new List<SelectListItem>();
            this.NumberCollection = new List<SelectListItem>();

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

        [Required]
        [Display(Name = "Номер")]
        public int Number { get; set; }

        public ICollection<SelectListItem> ConditionCollection { get; set; }

        public ICollection<SelectListItem> DeliveryCollection { get; set; }
        
        public ICollection<SelectListItem> NumberCollection { get; set; }

        private void Init()
        {
            this.NumberCollection.Add(new SelectListItem()
            {
                Text = "Избери",
                Value = ""
            });

            for (int i = 33; i <= 50; i++)
            {
                this.NumberCollection.Add(new SelectListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

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