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
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public void Add(string name, string Color, string ImageSrc)
        {
            this.context.Category.Add(new Category()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Color = Color,
                ImageSrc = ImageSrc
            });

            this.context.SaveChanges();
        }

        public ICollection<Category> GetAll()
        {
            return this.context.Category.ToList();
        }

        public string GetCategoryNameById(Guid id)
        {
            return this.context.Category.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
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
