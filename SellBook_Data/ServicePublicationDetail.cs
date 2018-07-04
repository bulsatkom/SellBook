using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class ServicePublicationDetail
    {
        public Guid Id { get; set; }

        public Guid PublicationId { get; set; }

        [Required]
        public bool IsPrivate { get; set; }
    }
}
