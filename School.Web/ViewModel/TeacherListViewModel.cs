using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Web.ViewModel
{
    public class TeacherListViewModel
    {
        public Guid TeaherId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
    }
}