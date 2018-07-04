using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class ChildrensPublicationPartialViewModel
    {
        public ChildrensPublicationPartialViewModel()
        {
            this.ConditionCollection = new List<SelectListItem>();
            this.DeliveryCollection = new List<SelectListItem>();
            this.SuitableForCollection = new List<SelectListItem>();
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
        [Display(Name = "Доставката се поема от")]
        public string Delivery { get; set; }

        [Display(Name = "Бебешка и Детска Номерация")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Подходящи за")]
        public string SuitableFor { get; set; }

        public bool ForShoes { get; set; }

        public ICollection<SelectListItem> ConditionCollection { get; set; }

        public ICollection<SelectListItem> DeliveryCollection { get; set; }

        public ICollection<SelectListItem> SuitableForCollection { get; set; }

        public ICollection<SelectListItem> NumberCollection { get; set; }

        private void Init()
        {
            if (this.ConditionCollection.Count == 0 && this.DeliveryCollection.Count == 0)
            {
                this.NumberCollection.Add(new SelectListItem()
                {
                    Text = "Избери",
                    Value = "",
                    Selected = true
                });

                for (int i = 16; i <= 39; i++)
                {
                    this.NumberCollection.Add(new SelectListItem()
                    {
                        Text = i.ToString(),
                        Value = i.ToString()
                    });
                }

                this.SuitableForCollection.Add(new SelectListItem()
                {
                    Text = "Избери",
                    Value = "",
                    Selected = true
                });

                this.SuitableForCollection.Add(new SelectListItem()
                {
                    Text = "Момче",
                    Value = "Момче"
                });

                this.SuitableForCollection.Add(new SelectListItem()
                {
                    Text = "Момиче",
                    Value = "Момиче"
                });

                this.SuitableForCollection.Add(new SelectListItem()
                {
                    Text = "Унисекс",
                    Value = "Унисекс"
                });

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