using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface IFavouritePublicationService
    {
        bool Add(Guid UserId, Guid PublicationId);

        void Remove(Guid UserId, Guid PublicationId);

        bool isLiked(Guid UserId, Guid PublicationId);
    }
}
