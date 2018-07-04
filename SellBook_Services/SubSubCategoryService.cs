using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class SubSubCategoryService : ISubSubCategoryService
    {
        private readonly ISellbookDbContext context;

        public SubSubCategoryService(ISellbookDbContext context)
        {
            if(context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public ICollection<SubSubCategory> GetAllBySubCategoryId(Guid id)
        {
            return this.context.SubSubCategory.Where(x => x.Id == id).ToList();
        }

        public string GetNameById(Guid id)
        {
            return this.context.SubSubCategory.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }
    }
}
