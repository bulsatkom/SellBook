﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface IUserService
    {
        string GetUserNameById(string Id);

        bool ContainsUser(string id);

        Guid GetCityIdByUserId(string UserId);

        Guid GetRegionIdByUserId(string UserId);

        string GetFirstNameById(string id);
    }
}
