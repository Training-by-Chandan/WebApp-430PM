using Broadway.WebApp.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Broadway.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private Services.UserService users = new Services.UserService();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult StudentDetails()
        {
            var data = users.GetAllStudents();
            return View(data);
        }

        public ActionResult TeacherDetails()
        {
            return View();
        }

        public ActionResult StudentCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentCreate(StudentUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //we have to do something here
                var result = users.CreateStudentUser(model);
                if (result.Status)
                {
                    return RedirectToAction(nameof(StudentDetails));
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("FirstName", "Something wrong happened");
                ModelState.AddModelError(string.Empty, "Something wrong happened");
                ModelState.AddModelError(string.Empty, "Something wrong happened twice");
                ModelState.AddModelError(string.Empty, "Something wrong happened thrice");
                ModelState.AddModelError(string.Empty, "Something wrong happened quadrice");
                return View(model);
            }
        }
    }
}