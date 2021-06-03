using Broadway.WebApp.Data;
using Broadway.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.Services
{
    public class LoginService
    {
        private DefaultContext db = new DefaultContext();

        public LoginResponseViewModel Login(LoginRequestViewModel model)
        {
            var result = new LoginResponseViewModel();
            try
            {
                var existingUser = db.Users.FirstOrDefault(p => p.Username == model.UserName);
                if (existingUser == null)
                {
                    result.Message = "Username not found";
                    return result;
                }

                if (model.HashedPassword == existingUser.HashedPassword)
                {
                    result.Status = true;
                    result.UserType = existingUser.UserType;
                    result.UserId = existingUser.Id;
                    result.Message = "All Good";
                }
                else
                {
                    result.Message = "Password not matched";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            return result;
        }
    }
}