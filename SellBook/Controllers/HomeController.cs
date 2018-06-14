using SellBook.Models;
using SellBook.Models.Home;
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

        [HttpGet]
        public ActionResult Test()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Test(HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in files)
                {
                    if(item.ContentType != "image/jpg" && item.ContentType != "image/png" &&
                        item.ContentType != "image/bmp" && item.ContentType != "image/gif" &&
                        item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("wrong type", "един или няколко файла са с непозволено разширение");
                        return this.View();
                    }
                }

                foreach (var file in files)
                {
                    file.SaveAs(Server.MapPath("/") + "/Images/" + User.Identity.Name + "/" + file.FileName);
                }

                return this.RedirectToAction("Index");
            }

            return this.View();
        }
    }
}