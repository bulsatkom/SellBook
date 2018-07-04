using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class ChildrensPublicationDetail
    {
        public Guid Id { get; set; }

        public Guid PublicationId { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsContacting { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        public string Delivery { get; set; }

        public int? Number { get; set; }

        [Required]
        public string SuitableFor { get; set; }
    }
}
