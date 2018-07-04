using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class WorkPublicationDetailService : IWorkPublicationDetailService
    {
        private readonly ISellbookDbContext context;

        public WorkPublicationDetailService(ISellbookDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public Guid Add(string bussyness, bool forInvalids, bool isContracting, string kind, int salaryFrom, int salaryTo) 
        {
            Guid id = Guid.NewGuid();
            this.context.WorkPublicationDetail.Add(new WorkPublicationDetail()
            {
                Bussyness = bussyness,
                ForInvalids = forInvalids,
                Id = id,
                IsContracting = isContracting,
                Kind = kind,
                SalaryFrom = salaryFrom,
                SalaryTo = salaryTo
            });

            this.context.SaveChanges();

            return id;
        }
    }
}
