using Broadway.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Broadway.WebApp.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext() : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<ParentS> ParentS { get; set; }
    }
}