using Broadway.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Broadway.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(int? param)
        {

            //Request Object

            //response object 
            if (param==0)
            {
                Response.SetCookie(new HttpCookie("CompanyName", "Broadway"));
            }
            

            return View();
        }

        [HttpGet]
        public ActionResult IndexGet(int? id)
        {
            var student = new StudentModel();
            if (id==1)
            {
                //load some dummy data
                student.Name = "Anchal";
                student.Address = "Bardibas";
            }
            else if (id==2)
            {
                //load some data
                student.Name = "Guddi";
                student.Address = "Janakpur";
            }
            else
            {
                //not found
                student = null;
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult IndexPost(StudentModel model)
        {
            return View("Index");
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            var val=Request.Cookies.Get("CompanyName");
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}