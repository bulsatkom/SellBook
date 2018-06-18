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

        Guid Add(Guid userId, Guid categoryID, Guid subCategory, string title, string description, bool isContracting, string phoneNumber,
            double price);

        Publication GetPublicationById(Guid Id);
    }
}
