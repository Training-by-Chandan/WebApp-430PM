using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.ViewModel.Admin
{
    public class StudentDashboardViewModel
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
    }
}