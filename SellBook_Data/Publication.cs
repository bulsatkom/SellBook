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

        public string ApplicationUserId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SubCategoryId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool IsContracting { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AddedOn { get; set; }

        public int Views { get; set; }

        //TODOs: fix this sh**....
        public int ViewPhone { get; set; }

        //TODOs: fix this sh**....
        public int AddAssFavourite { get; set; }

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
