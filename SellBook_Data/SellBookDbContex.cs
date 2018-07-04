using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class SellBookDbContex : IdentityDbContext<ApplicationUser>, ISellbookDbContext
    {
        public SellBookDbContex()
            :base ("DefaultConnection")
        {

        }

        public IDbSet<AnimalsPublicationDetail> AnimalsPublicationDetail { get; set; }

        public IDbSet<Category> Category { get; set; }

        public IDbSet<Chat> Chat { get; set; }

        public IDbSet<ChildrensPublicationDetail> ChildrenPublicationDetail { get; set; }

        public IDbSet<City> City { get; set; }

        public IDbSet<ClothesPublicationDetail> ClothesPublicationDetail { get; set; }

        public IDbSet<electronicsPublicationDetail> ElectronicsPublicationDetail { get; set; }

        public IDbSet<ExcursionsAndHolidaysPublicationDetail> ExcursionsAndHolidaysPublicationDetail { get; set; }

        public IDbSet<FavouritePublication> FavouritePublication { get; set; }

        public IDbSet<Image> Image { get; set; }

        public IDbSet<InitialPublicationDetail> InitialPublicationDetail { get; set; }

        public IDbSet<Message> Message { get; set; }

        public IDbSet<Publication> Publication { get; set; }

        public IDbSet<Region> Region { get; set; }

        public IDbSet<ServicePublicationDetail> Service { get; set; }

        public IDbSet<ShoesPublicationDetail> ShoesPublicationDetail { get; set; }

        public IDbSet<SubCategory> SubCategory { get; set; }

        public IDbSet<SubSubCategory> SubSubCategory { get; set; }

        public IDbSet<WorkPublicationDetail> WorkPublicationDetail { get; set; }

        public static SellBookDbContex Create()
        {
            return new SellBookDbContex();
        }
    }
}
