using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellBook.Models.Shared
{
    public class ExcursionsAndHolidaysPublicationPartialViewModel
    {
        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsContacting { get; set; }
    }
}