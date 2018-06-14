using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface IImageService
    {
        void Add(string src, Guid publicationId, bool isMain);
    }
}
