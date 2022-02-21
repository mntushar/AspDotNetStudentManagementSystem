using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ModelContext;

namespace StudentManagementSystem.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        public StudentRegistrationController()
        {
            ViewBag.title = "Student Registration";
        }

        // GET: StudentRegistration
        public ActionResult RegList()
        {
            var studentRegistration = db.StudentRegistration.Include(s => s.Course).Include(s => s.Student);
            return View(studentRegistration.ToList());
        }

        // GET: StudentRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistrationModels studentRegistrationModels = db.StudentRegistration.Find(id);
            if (studentRegistrationModels == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistrationModels);
        }

        // GET: StudentRegistration/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Title");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            return View();
        }

        // POST: StudentRegistration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,CourseId,EnrollDate,IsPaymentComplete")] StudentRegistrationModels studentRegistrationModels)
        {
            if (ModelState.IsValid)
            {
                db.StudentRegistration.Add(studentRegistrationModels);
                db.SaveChanges();
                return RedirectToAction("RegList");
            }

            ViewBag.CourseId = new SelectList(db.Course, "Id", "Title", studentRegistrationModels.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", studentRegistrationModels.StudentId);
            return View(studentRegistrationModels);
        }

        // GET: StudentRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistrationModels studentRegistrationModels = db.StudentRegistration.Find(id);
            if (studentRegistrationModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Title", studentRegistrationModels.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", studentRegistrationModels.StudentId);
            return View(studentRegistrationModels);
        }

        // POST: StudentRegistration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,CourseId,EnrollDate,IsPaymentComplete")] StudentRegistrationModels studentRegistrationModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentRegistrationModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RegList");
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Title", studentRegistrationModels.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", studentRegistrationModels.StudentId);
            return View("Create", studentRegistrationModels);
        }

        // GET: StudentRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistrationModels studentRegistrationModels = db.StudentRegistration.Find(id);
            if (studentRegistrationModels == null)
            {
                return HttpNotFound();
            }
            return View("Details", studentRegistrationModels);
        }

        // POST: StudentRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentRegistrationModels studentRegistrationModels = db.StudentRegistration.Find(id);
            db.StudentRegistration.Remove(studentRegistrationModels);
            db.SaveChanges();
            return RedirectToAction("RegList");
        }

        public ActionResult GetStudent(int? id)
        {
            if(id != null)
            {
                StudentModel student = db.Student.Find(id);
                if (student != null)
                {
                    var data = new {dept=student.Department.DeptName, id=student.DeptId };
                    string json = JsonConvert.SerializeObject(student, Formatting.Indented);
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(HttpStatusCode.BadRequest);
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
