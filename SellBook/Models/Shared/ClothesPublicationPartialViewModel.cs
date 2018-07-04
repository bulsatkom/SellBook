using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class ClothesPublicationPartialViewModel
    {
        //private readonly string forWomens;

        public ClothesPublicationPartialViewModel()
        {
            this.ConditionCollection = new List<SelectListItem>();
            this.DeliveryCollection = new List<SelectListItem>();

            this.init();
        }

        //private readonly ICollection<string> WomenUpSizes = new List<string>()
        //{
        //    "34 (XS)",
        //    "36 (S)",
        //    "38 (S)",
        //    "40 (M)",
        //    "42 (L)",
        //    "44 (L)",
        //    "46 (XL)",
        //    "48 (2XL)",
        //    "по-голям от 50",
        //};

        //private readonly ICollection<string> MenUpSizes = new List<string>()
        //{
        //    "46 (S)",
        //    "48 (M)",
        //    "50 (L)",
        //    "52 (L)",
        //    "54 (XL)",
        //    "56 (2XL)",
        //    "58 (3XL)",
        //    "60 (4XL)",
        //    "по-голям",
        //};

        //private readonly ICollection<string> DownSizes = new List<string>()
        //{
        //    "24",
        //    "25",
        //    "26",
        //    "27",
        //    "28",
        //    "29",
        //    "30",
        //    "31",
        //    "32",
        //    "33",
        //    "34",
        //    "35",
        //    "36",
        //    "38",
        //    "40",
        //    "42",
        //};

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

        public ICollection<SelectListItem> ConditionCollection { get; set; }

        public ICollection<SelectListItem> DeliveryCollection { get; set; }

        private void init()
        {
            //if (this.forWomens == "WomenUpSizes")
            //{
            //    foreach (var item in this.WomenUpSizes)
            //    {
            //        this.SizeCollection.Add(new SelectListItem()
            //        {
            //            Text = item,
            //            Value = item
            //        });
            //    }
            //}
            //else if (this.forWomens == "MenUpSizes")
            //{
            //    foreach (var item in this.MenUpSizes)
            //    {
            //        this.SizeCollection.Add(new SelectListItem()
            //        {
            //            Text = item,
            //            Value = item
            //        });
            //    }
            //}
            //else
            //{
            //    foreach (var item in this.DownSizes)
            //    {
            //        this.SizeCollection.Add(new SelectListItem()
            //        {
            //            Text = item,
            //            Value = item
            //        });
            //    }
            //}

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