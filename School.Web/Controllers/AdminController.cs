using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using School.Web.Models;
using School.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace School.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index(int? id)
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

        public ActionResult Sendemail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string EmailId, string name, string subject, string body)
        {
            try
            {
                sendEmail(EmailId, name, subject, body);
                ViewBag.message = "Your Email Has been sent";
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            return View();
        }

        private void sendEmail(string EmailId, string name, string subject, string body)
        {
            var receiver = new MailAddress(EmailId, name);
            var sender = new MailAddress("gchandaniw@gmail.com", "Chandan Gupta Bhagat");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("gchandaniw@gmail.com", "zbuyhjixnfkltumg")
            };
            var attachment = new Attachment("d:\\list.txt");
            var msg = new MailMessage(sender, receiver)
            {
                Subject = subject,
                Body = body,
            };
            msg.Attachments.Add(attachment);

            smtp.Send(msg);
        }

        [HttpGet]
        public FileResult GetFile(string filename)
        {
            var fullfileName = Server.MapPath("~/Resources/" + filename);
            var filebytes = System.IO.File.ReadAllBytes(fullfileName);

            var filenamewithExt = System.IO.Path.GetFileName(fullfileName);
            return File(filebytes, System.Net.Mime.MediaTypeNames.Application.Octet, filenamewithExt);
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(string filename)
        {
            var file = Request.Files[0];
            if (file.ContentLength <= 0)
            {
                ViewBag.message = "Invalid files";
            }
            else
            {
                filename = file.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                var fileN = Guid.NewGuid().ToString() + "." + ext;
                file.SaveAs(Server.MapPath("~/Resources/" + fileN));

                //save the record in db

                ViewBag.message = $"File {filename} uploaded";
            }
            return View();
        }
    }
}