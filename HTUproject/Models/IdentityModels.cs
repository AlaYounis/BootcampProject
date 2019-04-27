using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HTUproject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

       
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

      
        [Range(18, 60)]
        public string Age { get; set; }

       
        [Display(Name = "Major")]
        public string Major { get; set; }

       
        [Display(Name = "Country")]
        public string Country { get; set; }

      
        [Display(Name = "City")]
        public string City { get; set; }

       
        [Display(Name = "Name Of The Company")]
        public string Company { get; set; }

       
        [Display(Name = "Detalis Of The Company")]
        public string Details { get; set; }

        public string CV { get; set; }


        public virtual ICollection<Skill> InterestedSkills { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
           
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<Skill> skills { get; set; }

        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
       
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}