using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class Publication
    {
        private ICollection<Image> images;

        public Publication()
        {
            this.images = new HashSet<Image>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 6)]
        public string Title { get; set; }

        [StringLength(5000, MinimumLength = 20)]
        public string Description { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public Guid SubCategoryId { get; set; }

        public Guid? SubSubCategoryId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public Guid PublicationDetailsId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AddedOn { get; set; }

        public int Views { get; set; }

        //TODOs: fix this sh**....
        public int ViewPhone { get; set; }

        //TODOs: fix this sh**....
        public int AddAssFavourite { get; set; }

        public bool IsActive { get; set; }

        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public Guid RegionId { get; set; }

        public Guid CityId { get; set; }

        public ICollection<Image> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }
    }
}
