using SellBook.Services.Interfaces;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SellBook.Models.Publication;

namespace SellBook.Services
{
    public class PublicationModelService : IPublicationModelService
    {
        private readonly IPublicationDetailsService publicationDetailsService;

        public PublicationModelService(IPublicationDetailsService publicationDetailsService)
        {
            this.publicationDetailsService = publicationDetailsService;
        }

        public DetailsModel GetDetails(string categoryName, string subCategoryName, Guid PublicationDetailsId)
        {
            var model = new DetailsModel();

            if (categoryName == "Електроника")
            {
                var electronic = this.publicationDetailsService.GetElectronicDetailsById(PublicationDetailsId);

                model.Condition = electronic.Condition;
                model.Delivery = electronic.Delivery;
                model.IsContracting = electronic.IsContacting;
            }
            else if (categoryName == "Животни")
            {
                var animal  = this.publicationDetailsService.GetAnimalDetailsById(PublicationDetailsId);

                model.Delivery = animal.delivery;
                model.IsContracting = animal.IsContracting;
            }
            else if (categoryName == "за бебето и детето" && (subCategoryName == "Обувки" || subCategoryName == "Дрехи"))
            {
                var child = this.publicationDetailsService.GetChildrenDetailsById(PublicationDetailsId);

                model.Condition = child.Condition;
                model.Delivery = child.Delivery;
                model.IsContracting = child.IsContacting;
                model.Number = child.Number.HasValue ? child.Number.Value : 0;
                model.SuitableFor = child.SuitableFor;
            }
            else if (categoryName == "Екскурзии и почивки")
            {
                var holiday = this.publicationDetailsService.GetHolidayDetailsById(PublicationDetailsId);

                model.IsContracting = holiday.IsContacting;
            }
            else if (categoryName == "Мода" && (subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи" || subCategoryName == "Мъжки Обувки" || subCategoryName == "Женски Обувки"))
            {

                if ((subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи"))
                {
                    var clothes = this.publicationDetailsService.GetClothesDetailsById(PublicationDetailsId);

                    model.Condition = clothes.Condition;
                    model.Delivery = clothes.Delivery;
                    model.IsContracting = clothes.IsContacting;
                }
                else
                {
                    var shoes = this.publicationDetailsService.GetShoesDetailsById(PublicationDetailsId);

                    model.Condition = shoes.Condition;
                    model.Delivery = shoes.Delivery;
                    model.IsContracting = shoes.IsContacting;
                    model.Number = shoes.Number;
                }
            }
            else
            {
                var init = this.publicationDetailsService.GetInitialDetailsById(PublicationDetailsId);

                model.Condition = init.Condition;
                model.Delivery = init.Delivery;
                model.IsContracting = init.IsContacting;
            }

            return model;
        }

        public int GetPrice(string categoryName, string subCategoryName, Guid PublicationDetailsId)
        {
            if (categoryName == "Електроника")
            {
                return this.publicationDetailsService.GetPriceByIdElectronic(PublicationDetailsId);
            }
            else if (categoryName == "Животни")
            {
                return this.publicationDetailsService.GetPriceByIdAnimals(PublicationDetailsId);
            }
            else if (categoryName == "за бебето и детето")
            {
                if (subCategoryName == "Обувки" || subCategoryName == "Дрехи")
                {
                    return this.publicationDetailsService.GetPriceByIdChildrens(PublicationDetailsId);
                }
                else
                {
                    return this.publicationDetailsService.GetPriceByIdInitial(PublicationDetailsId);
                }
            }
            else if (categoryName == "Екскурзии и почивки")
            {
                return this.publicationDetailsService.GetPriceByIdHolidays(PublicationDetailsId);

            }
            else if (categoryName == "Мода" && (subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи" || subCategoryName == "Мъжки Обувки" || subCategoryName == "Женски Обувки"))
            {

                if ((subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи"))
                {
                    return this.publicationDetailsService.GetPriceByIdClothes(PublicationDetailsId);
                }
                else 
                {
                    return this.publicationDetailsService.GetPriceByIdShoes(PublicationDetailsId);
                }
            }
            else
            {
                return this.publicationDetailsService.GetPriceByIdInitial(PublicationDetailsId);
            }
        }
    }
}