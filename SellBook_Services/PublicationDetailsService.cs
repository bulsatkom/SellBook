using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services
{
    public class PublicationDetailsService : IPublicationDetailsService
    {
        private readonly ISellbookDbContext context;

        public PublicationDetailsService(ISellbookDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context cannot be null or empty");
            }

            this.context = context;
        }

        public Guid AddAnimalsDetails(string delivery, bool isContracting, int price)
        {
            Guid id = Guid.NewGuid();
            AnimalsPublicationDetail model = new AnimalsPublicationDetail()
            {
                Id = id,
                delivery = delivery,
                IsContracting = isContracting,
                Price = price,
            };

            this.context.AnimalsPublicationDetail.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public Guid AddClothesDetails(string condition, string delivery, bool isContracting, int price)
        {
            Guid id = Guid.NewGuid();
            ClothesPublicationDetail model = new ClothesPublicationDetail()
            {
                Id = id,
                Condition = condition,
                Delivery = delivery,
                IsContacting = isContracting,
                Price = price
            };

            this.context.ClothesPublicationDetail.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public Guid AddShoesDetails(string condition, string delivery, bool isContracting, int price, int number)
        {
            Guid id = Guid.NewGuid();
            ShoesPublicationDetail model = new ShoesPublicationDetail()
            {
                Id = id,
                Condition = condition,
                Delivery = delivery,
                IsContacting = isContracting,
                Price = price,
                Number = number
            };

            this.context.ShoesPublicationDetail.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public Guid AddInitialDetails(string condition, string delivery, bool isContracting, int price)
        {
            Guid id = Guid.NewGuid();
            InitialPublicationDetail model = new InitialPublicationDetail()
            {
                Id = id,
                Condition = condition,
                Delivery = delivery,
                IsContacting = isContracting,
                Price = price
            };

            this.context.InitialPublicationDetail.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public Guid AddChildDetails(string condition, string delivery, bool isContracting, int? number, int price,
            string suitableFor)
        {
            Guid id = Guid.NewGuid();

            ChildrensPublicationDetail model = new ChildrensPublicationDetail()
            {
                Id = id,
                Condition = condition,
                Delivery = delivery,
                IsContacting = isContracting,
                Price = price,
                SuitableFor = suitableFor
            };

            if(number != 0)
            {
                model.Number = number;
            }

            this.context.ChildrenPublicationDetail.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public Guid AddElectronicDetails(string condition, string delivery, bool isConracting, int price)
        {
            Guid id = Guid.NewGuid();

            electronicsPublicationDetail model = new electronicsPublicationDetail()
            {
                Id = id,
                Condition = condition,
                Delivery = delivery,
                IsContacting = isConracting,
                Price = price
            };

            this.context.ElectronicsPublicationDetail.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public Guid AddHolidayDetails(bool isContracting, int price)
        {
            Guid id = Guid.NewGuid();

            ExcursionsAndHolidaysPublicationDetail model = new ExcursionsAndHolidaysPublicationDetail()
            {
                Id = id,
                IsContacting = isContracting,
                Price = price
            };

            this.context.ExcursionsAndHolidaysPublicationDetail.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public Guid AddServiceDetails(bool isPrivate)
        {
            Guid id = Guid.NewGuid();

            ServicePublicationDetail model = new ServicePublicationDetail()
            {
                Id = id,
                IsPrivate = isPrivate
            };

            this.context.Service.Add(model);

            this.context.SaveChanges();

            return id;
        }

        public int GetPriceByIdAnimals(Guid Id)
        {
            return this.context.AnimalsPublicationDetail
                .Where(x => x.Id == Id)
                .Select(x => x.Price)
                .FirstOrDefault();
        }

        public int GetPriceByIdChildrens(Guid Id)
        {
            return this.context.ChildrenPublicationDetail
                .Where(x => x.Id == Id)
                .Select(x => x.Price)
                .FirstOrDefault();
        }

        public int GetPriceByIdClothes(Guid Id)
        {
            return this.context.ClothesPublicationDetail.Where(x => x.Id == Id).Select(x => x.Price).FirstOrDefault();
        }

        public int GetPriceByIdElectronic(Guid Id)
        {
            return this.context.ElectronicsPublicationDetail
                .Where(x => x.Id == Id)
                .Select(x => x.Price)
                .FirstOrDefault();
        }

        public int GetPriceByIdHolidays(Guid Id)
        {
            return this.context.ExcursionsAndHolidaysPublicationDetail
                .Where(x => x.Id == Id)
                .Select(x => x.Price)
                .FirstOrDefault();
        }

        public int GetPriceByIdInitial(Guid Id)
        {
            return this.context.InitialPublicationDetail
                .Where(x => x.Id == Id)
                .Select(x => x.Price)
                .FirstOrDefault();
        }

        public int GetPriceByIdShoes(Guid Id)
        {
            return this.context.ShoesPublicationDetail
                .Where(x => x.Id == Id)
                .Select(x => x.Price)
                .FirstOrDefault();
        }

        public void UpdatePublicationIdInAnimals(Guid publicationId, Guid AnimalId)
        {
            var element = this.context.AnimalsPublicationDetail.FirstOrDefault(x => x.Id == AnimalId);

            if (element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public void UpdatePublicationIdInElectronics(Guid publicationId, Guid electronicsId)
        {
            var element = this.context.ElectronicsPublicationDetail.FirstOrDefault(x => x.Id == electronicsId);

            if(element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public void UpdatePublicationInChild(Guid publicationId, Guid childId)
        {
            var element = this.context.ChildrenPublicationDetail.FirstOrDefault(x => x.Id == childId);

            if (element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public void UpdatePublicationInClothes(Guid publicationId, Guid clothesId)
        {
            var element = this.context.ClothesPublicationDetail.FirstOrDefault(x => x.Id == clothesId);

            if (element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public void UpdatePublicationInHoliday(Guid publicationId, Guid holidayId)
        {
            var element = this.context.ExcursionsAndHolidaysPublicationDetail.FirstOrDefault(x => x.Id == holidayId);

            if (element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public void UpdatePublicationInInitial(Guid publicationId, Guid initialId)
        {
            var element = this.context.InitialPublicationDetail.FirstOrDefault(x => x.Id == initialId);

            if (element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public void UpdatePublicationInService(Guid publicationId, Guid serviceId)
        {
            var element = this.context.Service.FirstOrDefault(x => x.Id == serviceId);

            if (element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public void UpdatePublicationInShoes(Guid publicationId, Guid shoesId)
        {
            var element = this.context.ShoesPublicationDetail.FirstOrDefault(x => x.Id == shoesId);

            if (element != null)
            {
                element.PublicationId = publicationId;

                this.context.SaveChanges();
            }
        }

        public WorkPublicationDetail GetWorkDetailsById(Guid id)
        {
            return this.context.WorkPublicationDetail.FirstOrDefault(x => x.Id == id);
        }

        public ShoesPublicationDetail GetShoesDetailsById(Guid id)
        {
            return this.context.ShoesPublicationDetail.FirstOrDefault(x => x.Id == id);

        }

        public ServicePublicationDetail GetServiceDetailsById(Guid id)
        {
            return this.context.Service.FirstOrDefault(x => x.Id == id);

        }

        public InitialPublicationDetail GetInitialDetailsById(Guid id)
        {
            return this.context.InitialPublicationDetail.FirstOrDefault(x => x.Id == id);

        }

        public ExcursionsAndHolidaysPublicationDetail GetHolidayDetailsById(Guid id)
        {
            return this.context.ExcursionsAndHolidaysPublicationDetail.FirstOrDefault(x => x.Id == id);

        }

        public electronicsPublicationDetail GetElectronicDetailsById(Guid id)
        {
            return this.context.ElectronicsPublicationDetail.FirstOrDefault(x => x.Id == id);

        }

        public ClothesPublicationDetail GetClothesDetailsById(Guid id)
        {
            return this.context.ClothesPublicationDetail.FirstOrDefault(x => x.Id == id);

        }

        public ChildrensPublicationDetail GetChildrenDetailsById(Guid id)
        {
            return this.context.ChildrenPublicationDetail.FirstOrDefault(x => x.Id == id);

        }

        public AnimalsPublicationDetail GetAnimalDetailsById(Guid id)
        {
            return this.context.AnimalsPublicationDetail.FirstOrDefault(x => x.Id == id);

        }
    }
}
