using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SellBook_Data
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Chat> chats;

        private ICollection<Publication> publications;

        public ApplicationUser()
        {
            this.chats = new HashSet<Chat>();
            this.publications = new HashSet<Publication>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Guid RegionId { get; set; }

        public Guid CityId { get; set; }

        //[Index(IsUnique = true)]
        //public override string PhoneNumber
        //{
        //    get
        //    {
        //        return base.PhoneNumber;
        //    }

        //    set
        //    {
        //        base.PhoneNumber = value;
        //    }
        //}

        public virtual ICollection<Chat> Chats
        {
            get
            {
                return this.chats;
            }
            set
            {
                this.chats = value;
            }
        }

        public virtual ICollection<Publication> Publications
        {
            get
            {
                return this.publications;
            }
            set
            {
                this.publications = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
