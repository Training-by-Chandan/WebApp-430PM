using Broadway.WebApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.ViewModel.Admin
{
    public class StudentUserViewModel
    {
        public Guid StudentId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Full Address")]
        public string Address { get; set; }
        [Required]
        
        public Gender Gender { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Confirm Password doesnot match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class StudentUserResponseViewModel : ResponseViewModel
    {
        public Guid UserId { get; set; }
        public Guid StudentId { get; set; }
    }
}