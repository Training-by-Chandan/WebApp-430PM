using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School.Web.Filters;
using School.Web.Models;

namespace School.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [AuthFilter]
    public class AcademicYearsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [OverrideAuthorization]
        [Authorize]
        // GET: AcademicYears
        public ActionResult Index()
        {
            return View(db.AcademicYear.ToList());
        }

        [OverrideAuthorization]
        [Authorize]
        // GET: AcademicYears/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYear.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // GET: AcademicYears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YearName,StartDate,EndDate,Description")] AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                academicYear.Id = Guid.NewGuid();
                db.AcademicYear.Add(academicYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicYear);
        }

        // GET: AcademicYears/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYear.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YearName,StartDate,EndDate,Description")] AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicYear);
        }

        // GET: AcademicYears/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYear.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AcademicYear academicYear = db.AcademicYear.Find(id);
            db.AcademicYear.Remove(academicYear);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}