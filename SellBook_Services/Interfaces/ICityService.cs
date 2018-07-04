using SellBook_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface ICityService
    {
        bool IsContains(Guid RegionId, string cityName, bool IsVillage);

        void Add(Guid regionId, string cityName, bool IsVillage);

        ICollection<City> GetByRegionId(Guid Id);

        string GetNameById(Guid Id);

        City GetCityById(Guid id);
    }
}
