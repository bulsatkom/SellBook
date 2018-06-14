using Microsoft.AspNet.Identity;
using SellBook.Models.Publication;
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

        public PublicationController(ICategoryService categoryService, ISubCategoryService subCategoryService,
            IPublicationService publicationService, IImageService imageService)
        {
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
            this.publicationService = publicationService;
            this.imageService = imageService;
        }

        [HttpGet]
        public ActionResult AddPublication()
        {
            var model = new AddPublicationViewModel();

            this.categoryService.GetAll().ToList().ForEach(x =>
            {
                model.Categories.Add(new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
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

                Guid publicationId = this.publicationService.Add(Guid.Parse(this.User.Identity.GetUserId()), model.CategoryId,
                    model.SubCategoryId, model.Title, model.Description, model.IsContactable, model.PhoneNumber, model.Price);

                Directory.CreateDirectory(Server.MapPath("/") + "/Images/" + User.Identity.Name + "/" + publicationId);

                foreach (var file in model.files)
                {
                    file.SaveAs(Server.MapPath("/") + "/Images/" + User.Identity.Name + "/" + publicationId + "/" + file.FileName);
                    this.imageService.Add(file.FileName, publicationId, false);
                }

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
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
    }
}