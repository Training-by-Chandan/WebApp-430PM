using School.Web.Models;
using School.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School.Web.API
{
    public class DefaultController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<UserListViewModel> getAllUsers()
        {
            var users = db.Users.Select(p => new UserListViewModel { Id = p.Id, Username = p.UserName, RoleCount = p.Roles.Count });
            return users.ToList();
        }
    }
}