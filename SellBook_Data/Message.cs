using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public Guid PublicationId { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SendedOn { get; set; }
    }
}
