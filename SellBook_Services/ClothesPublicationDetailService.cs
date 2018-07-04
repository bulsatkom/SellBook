using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class ClothesPublicationDetailService : IClothesPublicationDetailService
    {
        private readonly ISellbookDbContext context;

        public ClothesPublicationDetailService(ISellbookDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public bool isDownstairs(Guid SubSubCategoryid, bool forWomen)
        {
            var category = this.context.SubSubCategory.FirstOrDefault(x => x.Id == SubSubCategoryid);

            bool answer = false;

            if(forWomen)
            {

            }
            else
            {

            }

            return answer;
        }
    }
}
