using HTUproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTUproject.Controllers
{
    [Authorize(Roles = "Admins")]
    public class GetAllUsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: GetAllUsers
        public ActionResult AllUsers()
        {
            
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            var Duser = db.Users.Find(id);
            if (Duser == null)
            {
                return HttpNotFound();
            }
            return View(Duser);
        }

       // GET: user/Create
       // public ActionResult Create()
       // {
       //     return View();
       // }

       // POST: user/Create
       //[HttpPost]
       // public ActionResult Create(ApplicationUser applicationUser)
       // {
       //     try
       //     {
       //     TODO: Add insert logic here
       //         if (ModelState.IsValid)
       //         {
       //             db.Users.Add(applicationUser);
       //             db.SaveChanges();
       //             return RedirectToAction("Index");
       //         }
       //         return View(applicationUser);
       //     }
       //     catch
       //     {
       //         return View();
       //     }
       // }



        public ActionResult Edit(string id)
        {
            var users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);

        }

        
        [HttpPost]
        public ActionResult Edit(ApplicationUser applicationUser)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var user= db.Users.FirstOrDefault(x => x.Id == applicationUser.Id);

                    user.FirstName = applicationUser.FirstName;
                    user.Age = applicationUser.Age;
                    user.City = applicationUser.City;
                    user.Company = applicationUser.Company;
                    user.Country = applicationUser.Country;
                    user.LastName = applicationUser.LastName;
                    user.Major = applicationUser.Major;
                    user.Details = applicationUser.Details;
                    user.Email = applicationUser.Email;
                    user.UserName = applicationUser.UserName; 
                    db.SaveChanges();
                    return RedirectToAction("/AllUsers/");
                }
                return View(applicationUser);
            }
            catch
            {
                return View(applicationUser);
            }
        }

      
        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(string Id)
        { 
            // TODO: Add delete logic here
            ApplicationUser applica = db.Users.Find(Id);
            db.Users.Remove(applica);
            db.SaveChanges();
            return View();
        }

    }
}
