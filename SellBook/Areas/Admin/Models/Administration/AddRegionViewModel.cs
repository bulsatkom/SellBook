using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellBook.Areas.Admin.Models.Administration
{
    public class AddRegionViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string name { get; set; }
    }
}