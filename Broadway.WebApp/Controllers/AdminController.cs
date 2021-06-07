using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Broadway.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult StudentDetails()
        {
            var data = Services.UserService.GetAllStudents();
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
    }
}