using SellBook.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBook.Models.Publication
{
    public class AddPublicationViewModel
    {
        public AddPublicationViewModel()
        {
            this.Categories = new List<SelectListItem>();
            this.SubCategories = new List<SelectListItem>();
            this.SubSubCategories = new List<SelectListItem>();
        }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Заглавие на Обявата")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

        [Required]
        [Display(Name = "Под Категория")]
        public Guid SubCategoryId { get; set; }

        [Required]
        public Guid SubSubCategoryId { get; set; }

        [Required]
        [Display(Name = "Описание на обявата")]
        [StringLength(1500, MinimumLength = 30)]
        public string Description { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Телефоннен номер за обявата")]
        public string PhoneNumber { get; set; }

        public ServicePublicationPartialViewModel Service { get; set; }

        public WorkPublicationPartialViewModel Work { get; set; }

        public ElectronicsPublicationPartialViewModel Electronic { get; set; }

        public AnimalsPublicationPartialViewModel Animal { get; set; }

        public ChildrensPublicationPartialViewModel children { get; set; }

        public ClothesPublicationPartialViewModel clothes { get; set; }

        public InitialPublicationPartialViewModel Initial { get; set; }

        public ShoesPublicationPartialViewModel shoe { get; set; }

        public ExcursionsAndHolidaysPublicationPartialViewModel holiday { get; set; }

        public bool IsWork { get; set; }

        public bool IsService { get; set; }

        public ICollection<SelectListItem> Categories { get; set; }

        public ICollection<SelectListItem> SubCategories { get; set; }

        public ICollection<SelectListItem> SubSubCategories { get; set; }
    }
}