using SellBook.Models.Publication;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Controllers
{
    public class PublicationController : Controller
    {
        private readonly IRegionService regionService;
        private readonly ICityService cityService;

        public PublicationController(IRegionService regionService, ICityService cityService)
        {
            this.regionService = regionService;
            this.cityService = cityService;
        }

        [HttpGet]
        public ActionResult AddPublication()
        {
            var model = new AddPublicationViewModel();

            this.regionService.GetAll().ToList().ForEach(x =>
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

            }

            return this.View();
        }

        public ActionResult GetRegions(string iso3)
        {
            var list = new List<SelectListItem>();

            var cities = this.cityService.GetByRegionId(Guid.Parse(iso3)).ToList();

            foreach (var city in cities)
            {
                list.Add(new SelectListItem()
                {
                    Value = city.Id.ToString(),
                    Text = city.Name,
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}