using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class ImageService : IImageService
    {
        private readonly ISellbookDbContext context;

        public ImageService(ISellbookDbContext context)
        {
            this.context = context;
        }

        public void Add(string src, Guid publicationId, bool isMain)
        {
            this.context.Image.Add(new Image()
            {
                Id = Guid.NewGuid(),
                Name = src,
                IsMain = isMain,
                PublicationId = publicationId
            });

            this.context.SaveChanges();
        }
    }
}
