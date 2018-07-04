using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class SubSubCategory
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid SubCategoryId { get; set; }
    }
}
