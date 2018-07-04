using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class WorkPublicationDetail
    {
        public Guid Id { get; set; }

        public Guid PublicationId { get; set; }

        [Required]
        public int SalaryFrom { get; set; }

        [Required]
        public int SalaryTo { get; set; }

        [Required]
        public bool IsContracting { get; set; }

        [Required]
        public string Bussyness { get; set; }

        [Required]
        public string Kind { get; set; }

        [Required]
        public bool ForInvalids { get; set; }
    }
}
