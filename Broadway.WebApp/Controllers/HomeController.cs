using Broadway.WebApp.Models;
using Broadway.WebApp.Services;
using Broadway.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Broadway.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private LoginService _login = new LoginService();
        public ActionResult Index(int? param)
        {


            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequestViewModel model)
        {
            var result = _login.Login(model);
            if (result.Status)
            {
                Response.Cookies.Add(new HttpCookie("UserId",result.UserId.ToString()));
                
               
                //logged in 
                switch (result.UserType)
                {
                    
                    case Common.UserType.Student:
                        return RedirectToAction("Index", "Student");
                        break;
                    case Common.UserType.Teacher:
                        return RedirectToAction("Index", "Teacher");
                        break;
                    default:
                        return RedirectToAction("Index", "Admin");
                        break;
                }
            }
            else
            {
                //login error ko code 
                return View("Index");
            }
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

        //private ActionResult CheckLoggedin()
        //{
        //    var cookie = Request.Cookies.Get("UserId");
        //    if (cookie == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }

    
}