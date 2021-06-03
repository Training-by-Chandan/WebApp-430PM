namespace Broadway.WebApp.Migrations
{
    using Broadway.WebApp.Common;
    using Broadway.WebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Broadway.WebApp.Data.DefaultContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Broadway.WebApp.Data.DefaultContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Admin
            var admin = new User()
            {
                Id = Guid.Parse("f000991c-12bc-44ea-9fef-0f62a938c1d8"),
                Email = "admin@admin.com",
                HashedPassword = Md5Hash.Create("Admin@123"),
                Username = "admin",
                UserType = Common.UserType.Admin

            };

            var existingAdmin = db.Users.Find(admin.Id);
            if (existingAdmin == null)
            {
                db.Users.Add(admin);
                db.SaveChanges();
            }
            else
            {
                existingAdmin.Email = admin.Email;
                existingAdmin.HashedPassword = admin.HashedPassword;
                db.Entry(existingAdmin).State = EntityState.Modified;
                db.SaveChanges();
            }
            #endregion

            #region Student
            var student = new User()
            {
                Id = Guid.Parse("f000991c-12bc-44ea-9fef-0f62a938c1d9"),
                Email = "student@student.com",
                HashedPassword = Md5Hash.Create("Student@123"),
                Username = "student",
                UserType = Common.UserType.Student

            };

            var exitingStudent = db.Users.Find(student.Id);
            if (exitingStudent == null)
            {
                db.Users.Add(student);
                db.SaveChanges();
            }
            else
            {
                exitingStudent.Email = student.Email;
                exitingStudent.HashedPassword = student.HashedPassword;
                db.Entry(exitingStudent).State = EntityState.Modified;
                db.SaveChanges();
            }
            #endregion

            #region Teacher

            var teacher = new User()
            {
                Id = Guid.Parse("f000991c-12bc-44ea-9fef-0f62a938c1d0"),
                Email = "teacher@teacher.com",
                HashedPassword = Md5Hash.Create("Teacher@123"),
                Username = "teacher",
                UserType = Common.UserType.Teacher

            };
            var exitingTeacher = db.Users.Find(teacher.Id);
            if (exitingTeacher == null)
            {
                db.Users.Add(teacher);
                db.SaveChanges();
            }
            else
            {
                exitingTeacher.Email = teacher.Email;
                exitingTeacher.HashedPassword = teacher.HashedPassword;
                db.Entry(exitingTeacher).State = EntityState.Modified;
                db.SaveChanges();
            }
            #endregion

        }
    }
}
