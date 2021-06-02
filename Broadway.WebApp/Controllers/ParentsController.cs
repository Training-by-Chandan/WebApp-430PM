using Broadway.WebApp.Data;
using Broadway.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Broadway.WebApp.Controllers
{
    public class ParentsController : Controller
    {
        private DefaultContext db = new DefaultContext();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.ParentS.ToList()) ;
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewData["StudentId"] = db.Students.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });
            return View();
        }

        public ActionResult Add(ParentS model)
        {
            if (ModelState.IsValid)
            {
                db.ParentS.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}