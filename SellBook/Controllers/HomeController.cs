using SellBook.Models;
using SellBook.Models.Home;
using SellBook_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPublicationService publicationService;

        public HomeController(IPublicationService publicationService)
        {
            this.publicationService = publicationService;
        }

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();

            this.publicationService.GetLatest().ToList().ForEach(x =>
            {
                model.PublicationPartial.Add(new PublicationViewModel()
                {
                    Id = x.Id,
                    Image = x.Images.Where(y => y.IsMain == true).Select(y => y.Name).FirstOrDefault(),
                    Price = x.Price,
                    Title = x.Title
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
    }
}