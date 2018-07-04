using SellBook_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface ISubSubCategoryService
    {
        ICollection<SubSubCategory> GetAllBySubCategoryId(Guid id);

        string GetNameById(Guid id);
    }
}
