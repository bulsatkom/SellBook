using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class Image
    {
        public Guid Id { get; set; }

        public Guid PublicationId { get; set; }

        public string Name { get; set; }

        public bool IsMain { get; set; }
    }
}
