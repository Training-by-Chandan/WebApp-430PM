using Broadway.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.ViewModel
{
    public class ResponseViewModel
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
    }
    public class LoginResponseViewModel : ResponseViewModel
    {
        public UserType UserType { get; set; }
        public Guid UserId { get; set; }
    }
    public class LoginRequestViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HashedPassword
        {
            get
            {
                return Md5Hash.Create(Password);
            }
        }
    }
}