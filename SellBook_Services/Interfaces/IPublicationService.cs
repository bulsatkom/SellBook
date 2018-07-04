using SellBook_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface IPublicationService
    {
        ICollection<Publication> GetLatest();

        Guid Add(Guid userId, Guid categoryID, Guid subCategory, string title, string description, string phoneNumber, Guid DetailsId, Guid CityId, Guid RegionId);

        Publication GetPublicationById(Guid Id);

        void UpdateDetailPublicationId(Guid PublicationId, Guid DetailsId);

        bool IsContains(Guid id);

        int AllPublication();

        ICollection<Publication> GetOtherPublicationForUser(string userId, Guid PublicationId);

        ICollection<Publication> GetByQuery(string Query, Guid? RegionId, Guid? CategoryId);

        ICollection<Publication> GetPublicatrionsForUser(string UserId);

        ICollection<Publication> GetArchivedPublications(string UserId);

        void ActivatePublication(Guid id);
    }
}
