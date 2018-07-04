using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public interface ISellbookDbContext
    {
        IDbSet<Message> Message { get; set; }

        IDbSet<Category> Category { get; set; }

        IDbSet<SubCategory> SubCategory { get; set; }

        IDbSet<Publication> Publication { get; set; }

        IDbSet<Region> Region { get; set; }

        IDbSet<Chat> Chat { get; set; }

        IDbSet<City> City { get; set; }

        IDbSet<Image> Image { get; set; }

        IDbSet<FavouritePublication> FavouritePublication { get; set; }

        IDbSet<ServicePublicationDetail> Service { get; set; }

        IDbSet<WorkPublicationDetail> WorkPublicationDetail { get; set; }

        IDbSet<SubSubCategory> SubSubCategory { get; set; }

        IDbSet<AnimalsPublicationDetail> AnimalsPublicationDetail { get; set; }

        IDbSet<ChildrensPublicationDetail> ChildrenPublicationDetail { get; set; }

        IDbSet<ClothesPublicationDetail> ClothesPublicationDetail { get; set; }

        IDbSet<electronicsPublicationDetail> ElectronicsPublicationDetail { get; set; }

        IDbSet<ExcursionsAndHolidaysPublicationDetail> ExcursionsAndHolidaysPublicationDetail { get; set; }

        IDbSet<InitialPublicationDetail> InitialPublicationDetail { get; set; }

        IDbSet<ShoesPublicationDetail> ShoesPublicationDetail { get; set; }

        int SaveChanges();
    }
}
