using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class City
    {
        public Guid Id { get; set; }

        public Guid RegionId { get; set; }

        [Required]
        public bool IsCity { get; set; }


        [Required]
        [StringLength(50, MinimumLength =4)]
        public string Name { get; set; }
    }
}
