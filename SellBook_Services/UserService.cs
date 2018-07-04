using Microsoft.AspNet.Identity.EntityFramework;
using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class UserService : IUserService
    {
        private readonly IdentityDbContext<ApplicationUser> context;

        public UserService(IdentityDbContext<ApplicationUser> context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public bool ContainsUser(string id)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == id);

            if(user != null)
            {
                return true;
            }

            return false;
        }

        public Guid GetCityIdByUserId(string UserId)
        {
            return this.context.Users
                .Where(x => x.Id == UserId)
                .Select(x => x.CityId)
                .FirstOrDefault();
        }

        public string GetFirstNameById(string id)
        {
            return this.context.Users.Where(x => x.Id == id).Select(x => x.FirstName).FirstOrDefault();
        }

        public Guid GetRegionIdByUserId(string UserId)
        {
            return this.context.Users
                .Where(x => x.Id == UserId)
                .Select(x => x.RegionId)
                .FirstOrDefault();
        }

        public string GetUserNameById(string Id)
        {
            return this.context.Users.Where(x => x.Id == Id)
                .Select(x => x.UserName)
                .FirstOrDefault();
        }
    }
}
