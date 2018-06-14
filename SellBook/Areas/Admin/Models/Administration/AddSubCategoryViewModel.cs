using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Areas.Admin.Models.Administration
{
    public class AddSubCategoryViewModel
    {
        public AddSubCategoryViewModel()
        {
            this.Categories = new List<SelectListItem>();
        }

        public ICollection<SelectListItem> Categories { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public Guid SelectedCategory { get; set; }

        [Required]
        [Display(Name = "Под Категория")]
        public string Name { get; set; }
    }
}