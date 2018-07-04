using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class FavouritePublicationService : IFavouritePublicationService
    {
        private readonly ISellbookDbContext context;
        private readonly IUserService userService;
        private readonly IPublicationService publicationService;

        public FavouritePublicationService(ISellbookDbContext context, IUserService userService,
            IPublicationService publicationService)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            if (userService == null)
            {
                throw new ArgumentException("userService cannot be null or empty");
            }

            if (publicationService == null)
            {
                throw new ArgumentException("publicationService cannot be null or empty");
            }

            this.context = context;
            this.userService = userService;
            this.publicationService = publicationService;
        }

        public bool isLiked(Guid UserId, Guid PublicationId)
        {
            var publication = this.context.FavouritePublication.Where(x => x.UserId == UserId && PublicationId == x.PublicationId).FirstOrDefault();

            if(publication != null)
            {
                return true;
            }

            return false;
        }

        public bool Add(Guid UserId, Guid PublicationId)
        {
            if (this.userService.ContainsUser(UserId.ToString()))
            {
                if(this.publicationService.IsContains(PublicationId))
                {
                    var favouritePublications = this.context.FavouritePublication.ToList();
                    bool canAdd = true;

                    foreach (var favouritePublication in favouritePublications)
                    {
                        if(favouritePublication.UserId == UserId && favouritePublication.PublicationId == PublicationId)
                        {
                            canAdd = false;
                        }
                    }

                    if(canAdd)
                    {
                        this.context.FavouritePublication.Add(new FavouritePublication()
                        {
                            Id = Guid.NewGuid(),
                            PublicationId = PublicationId,
                            UserId = UserId
                        });

                        this.context.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        public void Remove(Guid UserId, Guid PublicationId)
        {
            var element = this.context.FavouritePublication
                .FirstOrDefault(x => x.UserId == UserId && x.PublicationId == PublicationId);

            if(element != null)
            {
                this.context.FavouritePublication.Remove(element);

                this.context.SaveChanges();
            }
        }
    }
}
