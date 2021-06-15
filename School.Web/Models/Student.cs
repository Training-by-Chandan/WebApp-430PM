using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Web.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Display(Name = "Student Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser StudentUser { get; set; }
    }

    public class Teacher
    {
        public Guid Id { get; set; }

        [Display(Name = "Teacher Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser TeacherUser { get; set; }
    }

    public class Subjects
    {
        public Guid Id { get; set; }

        [Display(Name = "Subject Name")]
        public string Name { get; set; }

        public string SubjectCode { get; set; }

        public Guid? ClassId { get; set; } //1
        public Guid? TeacherId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Classes Classes { get; set; }//1

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
    }

    public class Classes
    {
        public Guid Id { get; set; }

        [Display(Name = "Class Name")]
        public string Name { get; set; }

        public string RoomNo { get; set; }
        public Guid? TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Subjects> Subjects { get; set; }
    }
}