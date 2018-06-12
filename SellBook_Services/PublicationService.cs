using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellBook_Data;

namespace SellBook_Services
{
    public class PublicationService : IPublicationService
    {
        private readonly ISellbookDbContext context;

        public PublicationService(ISellbookDbContext context)
        {
            this.context = context;
        }

        public ICollection<Publication> GetLatest()
        {
            return this.context.Publication.OrderByDescending(x => x.AddedOn).Take(20).ToList();
        }
    }
}
