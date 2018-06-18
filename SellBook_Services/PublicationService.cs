using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellBook_Data;
using System.Data.Entity;

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
            return this.context.Publication.OrderByDescending(x => x.AddedOn).Take(20).Include(x => x.Images).ToList();
        }

        public Guid Add(Guid userId, Guid categoryID, Guid subCategory, string title, string description, bool isContracting, string phoneNumber,
            double price)
        {
            var id = Guid.NewGuid();

            this.context.Publication.Add(new Publication()
            {
                Id = id,
                AddAssFavourite = 0,
                AddedOn = DateTime.Now,
                ApplicationUserId = userId.ToString(),
                CategoryId = categoryID,
                Description = description,
                IsContracting = isContracting,
                PhoneNumber = phoneNumber,
                Price = price,
                SubCategoryId = subCategory,
                Title = title,
                ViewPhone = 0,
                Views = 0
            });

            this.context.SaveChanges();

            return id;
        }
    }
}
