using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface IWorkPublicationDetailService
    {
        Guid Add(string bussyness, bool forInvalids, bool isContracting, string kind, int salaryFrom, int salaryTo);
    }
}
