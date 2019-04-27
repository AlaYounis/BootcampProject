using HTUproject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HTUproject.Startup))]
namespace HTUproject
{
    public partial class Startup
    {
        ApplicationDbContext db = new  ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRouls();
            CreateUsers();
        }
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "alayounis@gmail.com";
            user.UserName = "ala";
            var check = userManager.Create(user,"ala123");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
               
            }
        }
        public void CreateRouls()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Teacher"))
            {
                role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Students"))
            {
                role = new IdentityRole();
                role.Name = "Students";
                roleManager.Create(role);
            }
        }
    }
}
