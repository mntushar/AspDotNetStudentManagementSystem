using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ModelContext;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        public CourseController()
        {
            ViewBag.title = "Student Course";
        }

        // GET: Course
        public ActionResult CourseList()
        {
            return View(db.Course.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModels courseModels = db.Course.Find(id);
            if (courseModels == null)
            {
                return HttpNotFound();
            }
            return View(courseModels);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,SeatCount,Fee")] CourseModels courseModels)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(courseModels);
                db.SaveChanges();
                return RedirectToAction("CourseList");
            }

            return View(courseModels);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModels courseModels = db.Course.Find(id);
            if (courseModels == null)
            {
                return HttpNotFound();
            }
            return View("Create", courseModels);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,SeatCount,Fee")] CourseModels courseModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CourseList");
            }
            return View("Create", courseModels);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModels courseModels = db.Course.Find(id);
            if (courseModels == null)
            {
                return HttpNotFound();
            }
            return View("Details",courseModels);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseModels courseModels = db.Course.Find(id);
            db.Course.Remove(courseModels);
            db.SaveChanges();
            return RedirectToAction("CourseList");
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
