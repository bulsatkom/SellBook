using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Areas.Admin.Models.Administration
{
    public class AddCityViewModel
    {
        public AddCityViewModel()
        {
            this.Regions = new List<SelectListItem>();
        }

        public ICollection<SelectListItem> Regions { get; set; }

        [Required]
        [Display(Name = "Район")]
        public Guid selectedRegion { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Село")]
        public bool iSVillage { get; set; }
    }
}