using Microsoft.AspNet.Identity;
using SellBook.Models;
using SellBook.Models.Account;
using SellBook.Models.Publication;
using SellBook.Models.Shared;
using SellBook.Services.Interfaces;
using SellBook_Data;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Controllers
{
    public class PublicationController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISubCategoryService subCategoryService;
        private readonly IPublicationService publicationService;
        private readonly IImageService imageService;
        private readonly IWorkPublicationDetailService workPublicationDetailService;
        private readonly ISubSubCategoryService subSubCategoryService;
        private readonly IFavouritePublicationService favouritePublicationService;
        private readonly ICityService cityService;
        private readonly IPublicationDetailsService publicationDetailsService;
        private readonly IUserService userService;
        private readonly IChatService chatService;
        private readonly IRegionService regionService;
        private readonly IPublicationModelService publicationModelService;

        public PublicationController(ICategoryService categoryService, ISubCategoryService subCategoryService,
            IPublicationService publicationService, IImageService imageService,
            IWorkPublicationDetailService workPublicationDetailService, ISubSubCategoryService subSubCategoryService,
            IFavouritePublicationService favouritePublicationService, ICityService cityService,
            IPublicationDetailsService publicationDetailsService, IUserService userService,
            IChatService chatService, IRegionService regionService, IPublicationModelService publicationModelService)
        {
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
            this.publicationService = publicationService;
            this.imageService = imageService;
            this.workPublicationDetailService = workPublicationDetailService;
            this.subSubCategoryService = subSubCategoryService;
            this.favouritePublicationService = favouritePublicationService;
            this.cityService = cityService;
            this.publicationDetailsService = publicationDetailsService;
            this.userService = userService;
            this.chatService = chatService;
            this.regionService = regionService;
            this.publicationModelService = publicationModelService;
        }

        //public ActionResult Index(string query = "")
        //{
        //    var result = new List<PublicationsViewModel>();

        //    return this.View();
        //}

        //0898438684
        //0878972300
        [HttpGet]
        public ActionResult AddPublication()
        {
            var model = new AddPublicationViewModel();

            this.categoryService.GetAll().ToList().ForEach(x =>
            {
                model.Categories.Add(new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });
            });

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublication(AddPublicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.files)
                {
                    if (item.ContentType != "image/jpg" && item.ContentType != "image/png" &&
                        item.ContentType != "image/bmp" && item.ContentType != "image/gif" &&
                        item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("wrong type", "един или няколко файла са с непозволено разширение");
                        return this.View(model);
                    }
                }

                string categoryName = this.categoryService.GetCategoryNameById(model.CategoryId);
                string subCategoryName = this.subCategoryService.GetSubCategoryNameById(model.SubCategoryId);

                Guid DetailsId = Guid.NewGuid();
                Guid publicationId = Guid.NewGuid();
                Guid cityId = this.userService.GetCityIdByUserId(User.Identity.GetUserId());
                Guid RegionId = this.userService.GetRegionIdByUserId(User.Identity.GetUserId());

                if (categoryName == "Електроника")
                {
                    DetailsId = this.publicationDetailsService.AddElectronicDetails(model.Electronic.Condition,
                        model.Electronic.Delivery, model.Electronic.IsContacting, model.Electronic.Price);

                    publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                    model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                    this.publicationDetailsService.UpdatePublicationIdInElectronics(publicationId, DetailsId);
                }
                else if (categoryName == "Животни")
                {
                    DetailsId = this.publicationDetailsService.AddAnimalsDetails(model.Animal.delivery,
                        model.Animal.IsContracting, model.Animal.Price);

                    publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                    model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                    this.publicationDetailsService.UpdatePublicationIdInAnimals(publicationId, DetailsId);
                }
                else if (categoryName == "за бебето и детето" && (subCategoryName == "Обувки" || subCategoryName == "Дрехи"))
                {
                    DetailsId = this.publicationDetailsService.AddChildDetails(model.children.Condition,
                         model.children.Delivery, model.children.IsContacting, model.children.Number != null ? int.Parse(model.children.Number) : 0, model.children.Price, model.children.SuitableFor);

                    publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                    this.publicationDetailsService.UpdatePublicationInChild(publicationId, DetailsId);
                }
                else if (categoryName == "Услуги")
                {
                    DetailsId = this.publicationDetailsService.AddServiceDetails(model.Service.IsPrivate);

                    publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                    this.publicationDetailsService.UpdatePublicationInService(publicationId, DetailsId);
                }
                else if (categoryName == "Екскурзии и почивки")
                {
                    DetailsId = this.publicationDetailsService.AddHolidayDetails(
                        model.holiday.IsContacting, model.holiday.Price);

                    publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                    this.publicationDetailsService.UpdatePublicationInHoliday(publicationId, DetailsId);
                }
                else if (categoryName == "Мода" &&
                    (subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи" || subCategoryName == "Мъжки Обувки" || subCategoryName == "Женски Обувки"))
                {
                    if((subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи"))
                    {
                        DetailsId = this.publicationDetailsService.AddClothesDetails(model.clothes.Condition,
                            model.clothes.Delivery, model.clothes.IsContacting, model.clothes.Price);

                        publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                        this.publicationDetailsService.UpdatePublicationInClothes(publicationId, DetailsId);
                    }
                    else
                    {
                        DetailsId = this.publicationDetailsService.AddShoesDetails(model.shoe.Condition,
                            model.shoe.Delivery, model.shoe.IsContacting, model.shoe.Price, model.shoe.Number);

                        publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                        this.publicationDetailsService.UpdatePublicationInShoes(publicationId, DetailsId);
                    }
                }
                else
                {
                    DetailsId = this.publicationDetailsService.AddInitialDetails(model.Initial.Condition,
                        model.Initial.Delivery, model.Initial.IsContacting, model.Initial.Price);

                    publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                model.SubCategoryId, model.Title, model.Description, model.PhoneNumber, DetailsId, cityId, RegionId);

                    this.publicationDetailsService.UpdatePublicationInInitial(publicationId, DetailsId);
                }

                Directory.CreateDirectory(Server.MapPath("/") + "/Content" + "/Images/" + User.Identity.Name + "/" + publicationId);

                var isMain = true;
                foreach (var file in model.files)
                {
                    file.SaveAs(Server.MapPath("/") + "/Content" + "/Images/" + User.Identity.Name + "/" + publicationId + "/" + file.FileName);
                    this.imageService.Add(file.FileName, publicationId, isMain);

                    isMain = false;
                }

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Search(SearchPartialViewModel model)
        {
            List<Publication> result = this.publicationService.GetByQuery(model.Query, model.Region, model.CategoryId).ToList();

            var ViewModel = new PublicationsDetailsViewModel();
            var PublicationsModel = new List<PublicationsViewModel>();

            for (int i = 0; i < result.Count; i++)
            {

                //Guid SubSubCategory = result[i].SubSubCategoryId.Value;
                string categoryName = this.categoryService.GetCategoryNameById(result[i].CategoryId);
                string subCategoryName = this.subCategoryService.GetSubCategoryNameById(result[i].SubCategoryId);
                string SubSubCategoryName = result[i].SubSubCategoryId.HasValue ? this.subSubCategoryService.GetNameById(result[i].SubSubCategoryId.Value) : null;
                string breadcrumb = "";
                string imageName = result[i].Images.Select(y => y.Name).FirstOrDefault();

                if (categoryName != null)
                {
                    breadcrumb += categoryName;
                    if (subCategoryName != null)
                    {
                        breadcrumb += " >> " + subCategoryName;

                        if (SubSubCategoryName != null)
                        {
                            breadcrumb += " >> " + SubSubCategoryName;
                        }
                    }

                }

                PublicationsModel.Add(new PublicationsViewModel()
                {
                    Id = result[i].Id,
                    AddedOn = result[i].AddedOn,
                    BreadCrumb = breadcrumb,
                    City = this.cityService.GetNameById(result[i].CityId),
                    Title = result[i].Title,
                    Image = "~/Content/Images/" + this.userService.GetUserNameById(result[i].ApplicationUserId) + "/" + result[i].Id + "/" + imageName
                });

                if (categoryName == "Електроника")
                {
                    PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdElectronic(result[i].PublicationDetailsId);
                }
                else if (categoryName == "Животни")
                {
                    PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdAnimals(result[i].PublicationDetailsId);
                }
                else if (categoryName == "за бебето и детето")
                {
                    if (subCategoryName == "Обувки" || subCategoryName == "Дрехи")
                    {
                        PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdChildrens(result[i].PublicationDetailsId);
                    }
                    else
                    {
                        PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdInitial(result[i].PublicationDetailsId);
                    }
                }
                else if (categoryName == "Екскурзии и почивки")
                {
                    PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdHolidays(result[i].PublicationDetailsId);

                }
                else if (categoryName == "Мода")
                {

                    if ((subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи"))
                    {
                        PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdClothes(result[i].PublicationDetailsId);
                    }
                    else if (subCategoryName == "Мъжки Обувки" || subCategoryName == "Женски Обувки")
                    {
                        PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdShoes(result[i].PublicationDetailsId);
                    }
                    else
                    {
                        PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdInitial(result[i].PublicationDetailsId);
                    }
                }
                else
                {
                    PublicationsModel[i].Price = this.publicationDetailsService.GetPriceByIdInitial(result[i].PublicationDetailsId);
                }
            }

            ViewModel.Publications = PublicationsModel;
            ViewModel.Search = model;

            return this.View("Publications", ViewModel);
        }

        public ActionResult ÄctivePublication(Guid id)
        {
            var model = new List<MyPublicationsViewModel>();

            this.publicationService.ActivatePublication(id);

            List<Publication> publications = this.publicationService.GetArchivedPublications(User.Identity.GetUserId()).ToList();

            for (int i = 0; i < publications.Count; i++)
            {
                string imageName = publications[i].Images.Select(x => x.Name).FirstOrDefault();
                string categoryName = this.categoryService.GetCategoryNameById(publications[i].CategoryId);
                string subCategoryName = this.subCategoryService.GetSubCategoryNameById(publications[i].SubCategoryId);
                string SubSubCategoryName = publications[i].SubSubCategoryId.HasValue ? this.subSubCategoryService.GetNameById(publications[i].SubSubCategoryId.Value) : null;

                var currentPublication = new MyPublicationsViewModel()
                {
                    AddedOn = publications[i].AddedOn,
                    AddedAsFavourite = publications[i].AddAssFavourite,
                    ImageName = "~/Content/Images/" + this.userService.GetUserNameById(publications[i].ApplicationUserId) + "/" + publications[i].Id + "/" + imageName,
                    isActive = publications[i].IsActive,
                    PublicationID = publications[i].Id,
                    Title = publications[i].Title,
                    ViewPhone = publications[i].ViewPhone,
                    Views = publications[i].Views,
                    MessagesNumbers = this.chatService.GetChatCountForPublication(publications[i].Id),
                };

                currentPublication.Price = this.publicationModelService.GetPrice(categoryName, subCategoryName, publications[i].PublicationDetailsId);

                model.Add(currentPublication);
            }

            return this.PartialView("MyAccountArchivedPartial", model);
        }

        [HttpPost]
        public ActionResult Details(DetailsViewModel model)
        {
            string categoryName = this.categoryService.GetCategoryNameById(Guid.Parse(model.categoryId));
            string subCategoryName = this.subCategoryService.GetSubCategoryNameById(Guid.Parse(model.subCategoryId));

            if (categoryName == "Електроника")
            {
                return this.PartialView("ElectronicsPublicationPartial", new AddPublicationViewModel()
                {
                    Electronic = new ElectronicsPublicationPartialViewModel()
                });
            }
            else if (categoryName == "Животни")
            {
                return this.PartialView("AnimalsPublicationPartial", new AddPublicationViewModel()
                {
                    Animal = new AnimalsPublicationPartialViewModel()
                });
            }
            else if (categoryName == "за бебето и детето")
            {
                if (subCategoryName == "Обувки" || subCategoryName == "Дрехи")
                {
                    if (subCategoryName == "Обувки")
                    {
                        return this.PartialView("ChildrensPublicationPartial", new AddPublicationViewModel()
                        {
                            children = new ChildrensPublicationPartialViewModel()
                            {
                                ForShoes = true,
                            }
                        });
                    }
                    else
                    {
                        return this.PartialView("ChildrensPublicationPartial", new AddPublicationViewModel()
                        {
                            children = new ChildrensPublicationPartialViewModel()
                            {
                                ForShoes = false,
                            }
                        });
                    }
                }
                else
                {
                    // TODOs : Make Initial Partial 
                    return this.PartialView("InitialPublicationPartial", new AddPublicationViewModel()
                    {
                        Initial = new InitialPublicationPartialViewModel()
                    });
                }
            }
            else if (categoryName == "Услуги")
            {
                return this.PartialView("ServicePublicationPartial", new AddPublicationViewModel()
                {
                    Service = new ServicePublicationPartialViewModel()
                });
            }
            else if (categoryName == "Екскурзии и почивки")
            {
                return this.PartialView("ExcursionsAndHolidaysPublicationPartial", new AddPublicationViewModel()
                {
                    holiday = new ExcursionsAndHolidaysPublicationPartialViewModel()
                });
            }
            else if (categoryName == "Мода")
            {

                if ((subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи"))
                {
                    return this.PartialView("ClothesPublicationPartial", new AddPublicationViewModel()
                    {
                        clothes = new ClothesPublicationPartialViewModel()
                    });
                }
                else if (subCategoryName == "Мъжки Обувки" || subCategoryName == "Женски Обувки")
                {
                    return this.PartialView("ShoesPublicationPartial", new AddPublicationViewModel()
                    {
                        shoe = new ShoesPublicationPartialViewModel()
                    });
                }
                else
                {
                    return this.PartialView("InitialPublicationPartial", new AddPublicationViewModel()
                    {
                        Initial = new InitialPublicationPartialViewModel()
                    });
                }
            }
            else
            {
                return this.PartialView("InitialPublicationPartial", new AddPublicationViewModel()
                {
                    Initial = new InitialPublicationPartialViewModel()
                });
            }
        }

        public ActionResult GetRegions(string iso3)
        {
            var list = new List<SelectListItem>();

            var subCategories = this.subCategoryService.GetAllByCategoryId(Guid.Parse(iso3)).ToList();

            foreach (var subCategory in subCategories)
            {
                list.Add(new SelectListItem()
                {
                    Value = subCategory.Id.ToString(),
                    Text = subCategory.Name,
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PublicationDetails(Guid id)
        {
            Publication currentPublication = this.publicationService.GetPublicationById(id);
            City CurrentCity = this.cityService.GetCityById(currentPublication.CityId);

            string subCategoryName = this.categoryService.GetCategoryNameById(currentPublication.SubCategoryId);
            string RegionName = this.regionService.GetNameById(CurrentCity.RegionId);
            string cityForModel = RegionName + 
                (CurrentCity.IsCity == true ?
                ", гр." + CurrentCity.Name :
                ", село " + CurrentCity.Name);
            List<string> imageUrls = new List<string>();
            List<PublicationViewModel> otherUserPublications = new List<PublicationViewModel>();

            this.publicationService.GetOtherPublicationForUser(currentPublication.ApplicationUserId, id).ToList().ForEach(x =>
            {
                string CurrentCategory = this.categoryService.GetCategoryNameById(x.CategoryId);
                string SubCategoryName = this.subCategoryService.GetSubCategoryNameById(x.SubCategoryId);

                var pub = new PublicationViewModel()
                {
                    Id = x.Id,
                    Image = ("~/Content/Images/" + this.userService.GetUserNameById(x.ApplicationUserId) + "/" + x.Id + "/" + x.Images.Where(y => y.IsMain == true).Select(y => y.Name).FirstOrDefault()),
                    Price = this.publicationModelService.GetPrice(CurrentCategory, SubCategoryName, x.PublicationDetailsId),
                    Title = x.Title 
                };

                otherUserPublications.Add(pub);
            });

            string MainImage = "";

            currentPublication.Images.ToList().ForEach(x =>
            {
                if (!x.IsMain)
                {
                    imageUrls.Add("~/Content/Images/" + this.userService.GetUserNameById(currentPublication.ApplicationUserId) + "/" + currentPublication.Id + "/" + x.Name);
                }
                else
                {
                    MainImage = ("~/Content/Images/" + this.userService.GetUserNameById(currentPublication.ApplicationUserId) + "/" + currentPublication.Id + "/" + x.Name);
                }
            });

            var model = new PublicationDetailViewModel()
            {
                City = cityForModel,
                Description = currentPublication.Description,
                ImagesUrls = imageUrls,
                PhoneNumber = currentPublication.PhoneNumber,
                PublicationAuthorName = this.userService.GetFirstNameById(currentPublication.ApplicationUserId),
                PublicationId = currentPublication.Id,
                Title = currentPublication.Title,
                Views = currentPublication.Views,
                Price = this.publicationModelService.GetPrice(currentPublication.Category.Name, subCategoryName, currentPublication.PublicationDetailsId),
                OtherUserPublications = otherUserPublications,
                MainImageSrc = MainImage,
                Details = this.publicationModelService.GetDetails(currentPublication.Category.Name, subCategoryName , currentPublication.PublicationDetailsId)
            };

            return this.View(model);
        }

        public ActionResult GetSubSubCategories(string iso3)
        {
            var List = new List<SelectListItem>();

            this.subSubCategoryService.GetAllBySubCategoryId(Guid.Parse(iso3)).ToList().ForEach(x =>
            {
                List.Add(new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            });

            return Json(List, JsonRequestBehavior.AllowGet);
        }
    }
}