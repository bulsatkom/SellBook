using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SellBook.Models;
using SellBook.Models.Home;
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
    public class HomeController : Controller
    {
        private readonly IPublicationService publicationService;
        private readonly IUserService userService;
        private readonly IFavouritePublicationService favouritePublicationService;
        private readonly IRegionService RegionService;
        private readonly ICategoryService categoryService;
        private readonly ISubCategoryService subCategoryService;
        private readonly ISubSubCategoryService subSubCategoryService;
        private readonly IPublicationDetailsService publicationDetailsService;

        public HomeController(IPublicationService publicationService, IUserService userService,
            IFavouritePublicationService favouritePublicationService, IRegionService RegionService,
            ICategoryService categoryService, ISubCategoryService subCategoryService, ISubSubCategoryService subSubCategoryService, IPublicationDetailsService publicationDetailsService)
        {
            this.publicationService = publicationService;
            this.userService = userService;
            this.favouritePublicationService = favouritePublicationService;
            this.RegionService = RegionService;
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
            this.subSubCategoryService = subSubCategoryService;
            this.publicationDetailsService = publicationDetailsService;
        }

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();

            //Server.MapPath("/") + "/Images/" + User.Identity.Name + "/" + publicationId

            this.publicationService.GetLatest().ToList().ForEach(x =>
            {
                string imageName = x.Images.Select(y => y.Name).FirstOrDefault();
                string title = "";
                bool isLiked = false;
                int price = 0;
                string categoryName = this.categoryService.GetCategoryNameById(x.CategoryId);
                string subCategoryName = this.subCategoryService.GetSubCategoryNameById(x.SubCategoryId);
                string SubSubCategoryName = x.SubSubCategoryId.HasValue ? this.subSubCategoryService.GetNameById(x.SubSubCategoryId.Value) : null;

                if (categoryName == "Електроника")
                {
                    price = this.publicationDetailsService.GetPriceByIdElectronic(x.PublicationDetailsId);
                }
                else if (categoryName == "Животни")
                {
                    price = this.publicationDetailsService.GetPriceByIdAnimals(x.PublicationDetailsId);
                }
                else if (categoryName == "за бебето и детето")
                {
                    if (subCategoryName == "Обувки" || subCategoryName == "Дрехи")
                    {
                        price = this.publicationDetailsService.GetPriceByIdChildrens(x.PublicationDetailsId);
                    }
                    else
                    {
                       price = this.publicationDetailsService.GetPriceByIdInitial(x.PublicationDetailsId);
                    }
                }
                else if (categoryName == "Екскурзии и почивки")
                {
                    price = this.publicationDetailsService.GetPriceByIdHolidays(x.PublicationDetailsId);

                }
                else if (categoryName == "Мода")
                {

                    if ((subCategoryName == "Мъжки Дрехи" || subCategoryName == "Женски Дрехи"))
                    {
                        price = this.publicationDetailsService.GetPriceByIdClothes(x.PublicationDetailsId);
                    }
                    else if (subCategoryName == "Мъжки Обувки" || subCategoryName == "Женски Обувки")
                    {
                        price = this.publicationDetailsService.GetPriceByIdShoes(x.PublicationDetailsId);
                    }
                    else
                    {
                        price = this.publicationDetailsService.GetPriceByIdInitial(x.PublicationDetailsId);
                    }
                }
                else
                {
                    price = this.publicationDetailsService.GetPriceByIdInitial(x.PublicationDetailsId);
                }


                x.Title.Take(23).ToList().ForEach(y => title += y);

                if (this.User.Identity.IsAuthenticated)
                {
                    isLiked = this.favouritePublicationService.isLiked(Guid.Parse(this.User.Identity.GetUserId()), x.Id);
                }

                model.PublicationPartial.Add(new PublicationViewModel()
                {
                    Id = x.Id,
                    Image = "~/Content/Images/" + this.userService.GetUserNameById(x.ApplicationUserId) + "/" + x.Id + "/" + imageName,
                    //Price = x.Price,
                    Title = title,
                    isLiked = isLiked,
                    FullTitle = x.Title,
                    Price = price
                });
            });

            model.SearchModel.PublicationCount = this.publicationService.AllPublication();
            model.SearchModel.RegionsCollection.Add(new SelectListItem()
            {
                Text = "В Цялата Страна",
                Value = "",
                Selected = true
            });

            this.RegionService.GetAll().ToList().ForEach(x =>
            {
                model.SearchModel.RegionsCollection.Add(new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            });

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RemoveFavourite(Guid id)
        {
            if (ModelState.IsValid)
            {
                this.favouritePublicationService.Remove(Guid.Parse(this.User.Identity.GetUserId()), id);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddFavourite(Guid id)
        {
            if (ModelState.IsValid)
            {
                var result = this.favouritePublicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), id);
                var publication = this.publicationService.GetPublicationById(id);
                if (result)
                {
                    var imageName = publication.Images.FirstOrDefault().Name;

                    return this.RedirectToAction("Index");
                }
            }

            return this.RedirectToAction("Index");
        }
    }
}