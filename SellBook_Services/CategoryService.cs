using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ISellbookDbContext context;

        public CategoryService(ISellbookDbContext context)
        {
            this.context = context;
        }

        public void Add(string name)
        {
            this.context.Category.Add(new Category()
            {
                Id = Guid.NewGuid(),
                Name = name,
            });

            this.context.SaveChanges();
        }

        public ICollection<Category> GetAll()
        {
            return this.context.Category.ToList();
        }

        public bool IsContains(string name)
        {
            var categoies = this.context.Category.ToList();

            foreach (var category in categoies)
            {
                if(category.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
