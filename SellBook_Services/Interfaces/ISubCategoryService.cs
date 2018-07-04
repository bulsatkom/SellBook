using SellBook_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface ISubCategoryService
    {
        bool IsContains(string Name, Guid CategoryId);

        void Add(string Name, Guid CategoryId);

        ICollection<SubCategory> GetAllByCategoryId(Guid CategoryId);

        string GetSubCategoryNameById(Guid id);
    }
}
