﻿using Broadway.WebApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.Models
{
    [Table("Student")]
    public partial class Student
    {
       
        public Student()
        {
            //this.StudentParents = new HashSet<StudentParents>();
            //this.StudentClasses = new HashSet<StudentClass>();
            //this.Attendances = new HashSet<Attendance>();
            //this.ExamsStudents = new HashSet<ExamsStudents>();
        }

        public Guid Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StudentParents> StudentParents { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StudentClass> StudentClasses { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Attendance> Attendances { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ExamsStudents> ExamsStudents { get; set; }
    }
}