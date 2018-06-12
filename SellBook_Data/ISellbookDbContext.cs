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

        int SaveChanges();
    }
}
