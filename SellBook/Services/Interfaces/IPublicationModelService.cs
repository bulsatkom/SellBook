using SellBook.Models.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook.Services.Interfaces
{
    public interface IPublicationModelService
    {
        int GetPrice(string categoryName, string subCategoryName, Guid PublicationDetailsId);

        DetailsModel GetDetails(string categoryName, string subCategoryName, Guid PublicationDetailsId);
    }
}
