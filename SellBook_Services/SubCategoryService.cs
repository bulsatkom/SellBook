using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISellbookDbContext context;

        public SubCategoryService(ISellbookDbContext context)
        {
            this.context = context;
        }

        public void Add(string Name, Guid CategoryId)
        {
            this.context.SubCategory.Add(new SubCategory()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                CategoryId = CategoryId
            });

            this.context.SaveChanges();
        }

        public ICollection<SubCategory> GetAllByCategoryId(Guid CategoryId)
        {
            return this.context.SubCategory.Where(x => x.CategoryId == CategoryId).ToList();
        }

        public bool IsContains(string Name, Guid CategoryId)
        {
            var subcategoies = this.context.SubCategory.ToList();

            foreach (var subcategory in subcategoies)
            {
                if(subcategory.Name.ToLower() == Name.ToLower() && subcategory.CategoryId == CategoryId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
