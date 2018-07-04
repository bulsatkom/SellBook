using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Shared
{
    public class WorkPublicationPartialViewModel
    {
        public WorkPublicationPartialViewModel()
        {
            this.BussynessCollection = new List<SelectListItem>();
            this.KindCollection = new List<SelectListItem>();

            this.Initial();
        }

        [Required]
        [Display(Name = "Заплата от")]
        public int SalaryFrom { get; set; }

        [Required]
        [Display(Name = "Заплата до")]
        public int SalaryTo { get; set; }

        [Required]
        [Display(Name = "По Договаряне")]
        public bool IsContracting { get; set; }

        [Required]
        [Display(Name = "Заетост")]
        public string Bussyness { get; set; }

        public ICollection<SelectListItem> BussynessCollection {get;set;}

        [Required]
        [Display(Name = "Вид")]
        public string Kind { get; set; }

        public ICollection<SelectListItem> KindCollection { get; set; }

        [Required]
        [Display(Name = "Подходяща за инвалиди")]
        public bool ForInvalids { get; set; }

        private void Initial()
        {
            if(this.BussynessCollection.Count == 0 && this.KindCollection.Count == 0)
            {
                this.BussynessCollection.Add(new SelectListItem()
                {
                    Text = "Пълно Работно Време",
                    Value = "true",
                });

                this.BussynessCollection.Add(new SelectListItem()
                {
                    Text = "Непълно Работно Време",
                    Value = "false",
                });

                this.BussynessCollection.Add(new SelectListItem()
                {
                    Text = "Избери",
                    Value = "",
                    Selected = true
                });

                this.KindCollection.Add(new SelectListItem()
                {
                    Text = "Избери",
                    Value = "",
                    Selected = true
                });

                this.KindCollection.Add(new SelectListItem()
                {
                    Text = "Постоянна",
                    Value = "0"
                });

                this.KindCollection.Add(new SelectListItem()
                {
                    Text = "Временна/ Сезонна",
                    Value = "1"
                });

                this.KindCollection.Add(new SelectListItem()
                {
                    Text = "Стаж",
                    Value = "2"
                });
            }
        }
    }
}