using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Publication
{
    public class AddPublicationViewModel
    {
        public AddPublicationViewModel()
        {
            this.Categories = new List<SelectListItem>();
            this.SubCategories = new List<SelectListItem>();
        }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Заглавие на Обявата")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public Guid CategoryId { get; set; }

        [Required]
        [Display(Name = "Под Категория")]
        public Guid SubCategoryId { get; set; }

        [Required]
        [Display(Name = "Описание на обявата")]
        [StringLength(1500, MinimumLength = 30)]
        public string Description { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Телефоннен номер за обявата")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "По Договаряне")]
        public bool IsContactable { get; set; }

        public ICollection<SelectListItem> Categories { get; set; }

        public ICollection<SelectListItem> SubCategories { get; set; }
    }
}