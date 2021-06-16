using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using School.Web.Models;
using School.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Roles

        public ActionResult Roles()
        {
            var roles = db.Roles.Select(p => new AdminRolesViewModel { Id = p.Id, RoleName = p.Name, UserCount = p.Users.Count });

            return View(roles);
        }

        public ActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RoleCreate(RoleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                if (!(db.Roles.Any(p => p.Name == model.RoleName)))
                {
                    roleManager.Create(new IdentityRole() { Name = model.RoleName });
                    return RedirectToAction("Roles");
                }
            }
            return View(model);
        }

        #endregion Roles

        #region Users

        public ActionResult Users()
        {
            var users = db.Users.Select(p => new UserListViewModel { Id = p.Id, Username = p.UserName, RoleCount = p.Roles.Count });

            return View(users);
        }

        public ActionResult UsersParial()
        {
            var users = db.Users.Select(p => new UserListViewModel { Id = p.Id, Username = p.UserName, RoleCount = p.Roles.Count });

            return PartialView("users", users);
        }

        public ActionResult UserCreate()
        {
            var rolesData = db.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name });
            ViewBag.RolesDropDown = rolesData;
            return View();
        }

        [HttpPost]
        public ActionResult UserCreate(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(db.Users.Any(u => u.UserName == model.UserName)))
                {
                    var userStore = new UserStore<ApplicationUser>(db);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    var userToInsert = new ApplicationUser
                    {
                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        Email = model.Email
                    };
                    userManager.Create(userToInsert, model.Password);

                    userManager.AddToRole(userToInsert.Id, model.Role);
                    return RedirectToAction("Users");
                }
            }

            var rolesData = db.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name });
            ViewBag.RolesDropDown = rolesData;
            return View(model);
        }

        #endregion Users
    }
}