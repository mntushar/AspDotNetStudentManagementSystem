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
        public ActionResult Create([Bind(Include = "StudentId,CourseId,IsPaymentComplete")] StudentRegistrationModels studentRegistration)
        {
            if (ModelState.IsValid)
            {
                StudentRegistrationModels exitReg = db.StudentRegistration.Find(studentRegistration.StudentId);
                if (exitReg == null)
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        db.StudentRegistration.Add(studentRegistration);
                        db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT StudentRegistrationModels ON;");
                        db.SaveChanges();
                        db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT StudentRegistrationModels OFF");
                        transaction.Commit();
                    }
                    return RedirectToAction("RegList");
                }
                ModelState.AddModelError(nameof(studentRegistration.StudentId), "Student alredy registered");
                
            }

            ViewBag.CourseId = new SelectList(db.Course, "Id", "Title");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            return View(studentRegistration);
        }

        // GET: StudentRegistration/Edit/5
        public ActionResult Edit(int? StudentId)
        {
            if (StudentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistrationModels studentRegistration = db.StudentRegistration.Find(StudentId);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Title");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            return View(studentRegistration);
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
                    var data = new { dept=student.Department.DeptName, id=student.DeptId };
                    return Json(data, JsonRequestBehavior.AllowGet);
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
