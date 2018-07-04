using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class RegionService : IRegionService
    {
        private readonly ISellbookDbContext context;

        public RegionService(ISellbookDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public void Add(string name)
        {
            this.context.Region.Add(new Region()
            {
                Name = name,
                Id = Guid.NewGuid()
            });

            this.context.SaveChanges();
        }

        public ICollection<Region> GetAll()
        {
            return this.context.Region.ToList();
        }

        public string GetNameById(Guid id)
        {
            return this.context.Region
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        public bool IsContains(string name)
        {
            bool isContains = false;

            this.context.Region.ToList().ForEach(x =>
            {
                if(x.Name.ToLower() == name.ToLower())
                {
                    isContains =  true;
                }
            });

            return isContains;
        }
    }
}
