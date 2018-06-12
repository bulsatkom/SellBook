using SellBook.Areas.Admin.Models.Administration;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Areas.Admin.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IRegionService regionService;
        private readonly ICityService cityService;

        public AdministrationController(IRegionService regionService, ICityService cityService)
        {
            this.regionService = regionService;
            this.cityService = cityService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult AddRegion()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRegion(AddRegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!regionService.IsContains(model.name))
                {
                    regionService.Add(model.name);

                    return this.RedirectToAction("Index");
                }

                ModelState.AddModelError("dublicate", "Този Регион вече съществува!");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult AddCity()
        {
            var model = new AddCityViewModel();

            this.regionService.GetAll().ToList().ForEach(x =>
            {
                model.Regions.Add(new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name 
                });
            });

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCity(AddCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isContains = this.cityService.IsContains(model.selectedRegion, model.Name, model.iSVillage);

                if (!isContains)
                {
                    this.cityService.Add(model.selectedRegion, model.Name, model.iSVillage);

                    return this.RedirectToAction("Index");
                }

                ModelState.AddModelError("Dublicate", "Този Град/Село вече Съществува в този район!!!"); 
            }

            return this.View(model);
        }
    }
}