﻿using HTUproject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTUproject.Controllers
{
    public class TeacherMatchController : Controller
    {
        // GET: TeacherMatch
        public ActionResult Index()
        {
            List<ApplicationUser> AllStudents = new List<ApplicationUser>();
            var user = User.Identity.GetUserId();
            using (var db = new ApplicationDbContext())
            {
                var studentRole = db.Roles.FirstOrDefault(x => x.Name == "Students").Id;
                var teacher = db.Users.Include(x=>x.InterestedSkills).SingleOrDefault(x => x.Id == user);
                foreach (var skill in teacher.InterestedSkills)
                {
                    AllStudents.AddRange(skill.Users.Where(x => x.Roles.Where(z => z.RoleId == studentRole).Any()).ToList());
                }
            }
            return View(AllStudents.Distinct());
        }

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/UploadedCV/" + ImageName;
            return File(FileVirtualPath, "~/UploadedCV/", Path.GetFileName(FileVirtualPath));
        }
    }
}