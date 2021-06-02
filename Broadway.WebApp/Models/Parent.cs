using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.Models
{
    [Table("Parent_Info")]
    public class ParentS
    {
        [Key]
        public int Id { get; set; }
        public string ParentName { get; set; }
        public ParentType Type { get; set; }
        public int? StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }

    public enum ParentType
    {
        Father, 
        Mother, 
        Other
    }
}