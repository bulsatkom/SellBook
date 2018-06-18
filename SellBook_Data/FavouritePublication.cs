
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class FavouritePublication
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid PublicationId { get; set; }
    }
}
