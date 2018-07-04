using SellBook_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface ICategoryService
    {
        bool IsContains(string name);

        void Add(string name, string Color, string ImageSrc);

        ICollection<Category> GetAll();

        string GetCategoryNameById(Guid id);
    }
}
