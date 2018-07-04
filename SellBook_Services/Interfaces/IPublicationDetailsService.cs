using SellBook_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Services.Interfaces
{
    public interface IPublicationDetailsService
    {
        int GetPriceByIdElectronic(Guid Id);

        int GetPriceByIdAnimals(Guid Id);

        int GetPriceByIdChildrens(Guid Id);

        int GetPriceByIdInitial(Guid Id);

        int GetPriceByIdHolidays(Guid Id);

        int GetPriceByIdClothes(Guid Id);

        int GetPriceByIdShoes(Guid Id);

        Guid AddElectronicDetails(string condition, string delivery, bool isConracting, int price);

        Guid AddAnimalsDetails(string delivery, bool isContracting, int price);

        Guid AddChildDetails(string condition, string delivery, bool isContracting, int? number, int price,
            string suitableFor);

        Guid AddServiceDetails(bool isPrivate);

        Guid AddHolidayDetails(bool isContracting, int price);

        Guid AddInitialDetails(string condition, string delivery, bool isContracting, int price);

        Guid AddShoesDetails(string condition, string delivery, bool isContracting, int price, int number);

        Guid AddClothesDetails(string condition, string delivery, bool isContracting, int price);

        void UpdatePublicationIdInElectronics(Guid publicationId, Guid electronicsId);

        void UpdatePublicationIdInAnimals(Guid publicationId, Guid AnimalId);

        void UpdatePublicationInChild(Guid publicationId, Guid childId);

        void UpdatePublicationInService(Guid publicationId, Guid serviceId);

        void UpdatePublicationInHoliday(Guid publicationId, Guid holidayId);

        void UpdatePublicationInClothes(Guid publicationId, Guid clothesId);

        void UpdatePublicationInShoes(Guid publicationId, Guid shoesId);

        void UpdatePublicationInInitial(Guid publicationId, Guid initialId);

        WorkPublicationDetail GetWorkDetailsById(Guid id);

        ShoesPublicationDetail GetShoesDetailsById(Guid id);

        ServicePublicationDetail GetServiceDetailsById(Guid id);

        InitialPublicationDetail GetInitialDetailsById(Guid id);

        ExcursionsAndHolidaysPublicationDetail GetHolidayDetailsById(Guid id);

        electronicsPublicationDetail GetElectronicDetailsById(Guid id);

        ClothesPublicationDetail GetClothesDetailsById(Guid id);

        ChildrensPublicationDetail GetChildrenDetailsById(Guid id);

        AnimalsPublicationDetail GetAnimalDetailsById(Guid id);
    }
}
