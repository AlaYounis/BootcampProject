using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HTUproject.Models;
using Microsoft.AspNet.Identity;

namespace HTUproject.Controllers
{
    public class SkillsAndCVController : Controller
    {
        ApplicationDbContext context;
        public SkillsAndCVController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: SkillsAndCV
        [HttpGet]
        public ActionResult SkillsAndCv()
        {
            using (var db = new ApplicationDbContext())
            {
                ViewData["Skills"] = db.skills.ToList();
               
                return View();
            }
            
        }


        // POST: SkillsAndCV
        [HttpPost]
        public ActionResult SkillsAndCv(SkillSelection Skills)
        {
            
            using (var db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                var user = db.Users.SingleOrDefault(x => x.Id == userId);
                var data = Request.Form["Skills"].Split(',');
               if( user.InterestedSkills == null)
                {
                    user.InterestedSkills = new List<Skill>();
                }
               
                
                    foreach (var skill in data)
                    {
                        var id = int.Parse(skill);
                        var dbSkill = db.skills.SingleOrDefault(x => x.Id == id);

                        user.InterestedSkills.Add(dbSkill);

                        db.SaveChanges();

                    }

                return RedirectToAction("Index", "Home");

            }
           
           
        }
    }
}