using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class AnimalsPublicationDetail
    {
        public Guid Id { get; set; }

        public Guid PublicationId { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsContracting { get; set; }

        [Required]
        public string delivery { get; set; }
    }
}
