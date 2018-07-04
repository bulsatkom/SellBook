using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class CityService : ICityService
    {
        private readonly ISellbookDbContext context;

        public CityService(ISellbookDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public void Add(Guid regionId, string cityName, bool IsVillage)
        {
            this.context.City.Add(new City()
            {
                Id = Guid.NewGuid(),
                IsCity = !IsVillage,
                Name = cityName,
                RegionId = regionId
            });

            this.context.SaveChanges();
        }

        public ICollection<City> GetByRegionId(Guid Id)
        {
            var cities = this.context.City.Where(x => x.RegionId == Id).ToList();

            return cities;
        }

        public City GetCityById(Guid id)
        {
            return this.context.City.FirstOrDefault(x => x.Id == id);
        }

        public string GetNameById(Guid Id)
        {
            return this.context.City
                .Where(x => x.Id == Id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        public bool IsContains(Guid RegionId, string cityName, bool IsVillage)
        {
            var isContains = this.context.City.Where
                (x => x.RegionId == RegionId &&
                x.Name.ToLower() == cityName.ToLower() &&
                x.IsCity == !IsVillage)
                .FirstOrDefault();

            if(isContains != null)
            {
                return true;
            }

            return false;
        }
    }
}
