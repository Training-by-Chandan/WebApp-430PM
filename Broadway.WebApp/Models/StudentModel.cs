using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.Models
{
    public class StudentModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Parent Parent { get; set; }
    }

    public class Parent
    {
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}