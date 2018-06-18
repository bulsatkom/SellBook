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
            this.context = context;
        }

        public string GetUserNameById(string Id)
        {
            return this.context.Users.Where(x => x.Id == Id)
                .Select(x => x.UserName)
                .FirstOrDefault();
        }
    }
}
