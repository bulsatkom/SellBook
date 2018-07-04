using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class SubCategory
    {
        private ICollection<SubSubCategory> subcategories;

        public SubCategory()
        {
            this.subcategories = new HashSet<SubSubCategory>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public virtual ICollection<SubSubCategory> Subcategories
        {
            get
            {
                return this.subcategories;
            }
            set
            {
                this.subcategories = value;
            }
        }
    }
}
