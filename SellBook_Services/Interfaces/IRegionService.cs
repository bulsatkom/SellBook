﻿using SellBook_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface IRegionService
    {
        bool IsContains(string name);

        void Add(string name);

        ICollection<Region> GetAll();

        string GetNameById(Guid id);
    }
}
