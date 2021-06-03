using Broadway.WebApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.Models
{
    public class Teacher
    {
        public Teacher()
        {
            //this.ClassSubjectTeachers = new HashSet<ClassSubjectTeacher>();
            //this.Attendances = new HashSet<Attendance>();
            //this.Classes = new HashSet<Classes>();
        }

        public Guid Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public Gender Gender { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Attendance> Attendances { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Classes> Classes { get; set; }
    }
}