using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class Category
    {
        private ICollection<SubCategory> subcategories;

        public Category()
        {
            this.subcategories = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

       public virtual ICollection<SubCategory> Subcategories
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
