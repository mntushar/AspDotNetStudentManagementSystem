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
using StudentManagementSystem.Controllers;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class StudentRegistrationController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();
        private string CustomDataSaveError = new ErrorController().DataSaveCustomError();

        public StudentRegistrationController()
        {
            ViewBag.title = "Student Registration";
        }


        // GET: StudentRegistration list
        public ActionResult RegList()
        {
            var studentRegistration = db.StudentRegistration.Include(s => s.Course).Include(s => s.Student);
            return View(studentRegistration.ToList());
        }

        // GET: StudentRegistration/Details/5
        public ActionResult Details(int? StudentId)
        {
            if (StudentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistrationModels studentRegistrationModels = db.StudentRegistration.Find(StudentId);
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
                    studentRegistration.EnrollDate = DateTime.UtcNow;
                    CourseModels exitCourse = db.Course.Find(studentRegistration.CourseId);
                    //var countTotalStudent = db.StudentRegistration.Where(c => c.CourseId == studentRegistration.CourseId).Count();
                    if (exitCourse != null)
                    {
                        try
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
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("customerror", CustomDataSaveError);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(studentRegistration.CourseId), "Select correct course..");
                    }   
                }
                else
                {
                    ModelState.AddModelError(nameof(studentRegistration.StudentId), "Student alredy registered");
                }
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
        public ActionResult Edit([Bind(Include = "StudentId, CourseId,IsPaymentComplete")] StudentRegistrationModels studentRegistration)
        {
            if (ModelState.IsValid)
            {
                StudentRegistrationModels exitReg = db.StudentRegistration.Find(studentRegistration.StudentId);
                if(exitReg != null)
                {
                    studentRegistration.EnrollDate = exitReg.EnrollDate;
                    CourseModels exitCourse = db.Course.Find(studentRegistration.CourseId);
                    if(exitCourse != null)
                    {
                        try
                        {
                            db.Entry(exitReg).CurrentValues.SetValues(studentRegistration);
                            db.SaveChanges();
                            return RedirectToAction("RegList");
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("customerror", CustomDataSaveError);
                        }
                    }
                    ModelState.AddModelError(nameof(studentRegistration.CourseId), "Select correct course..");
                }
                else
                {
                    ModelState.AddModelError(nameof(studentRegistration.StudentId), "Enter correct student");
                } 
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "Title");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            return View(studentRegistration);
        }

        // GET: StudentRegistration/Delete/5
        public ActionResult Delete(int? StudentId)
        {
            if (StudentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistrationModels studentRegistrationModels = db.StudentRegistration.Find(StudentId);
            if (studentRegistrationModels == null)
            {
                return HttpNotFound();
            }
            return View("Details", studentRegistrationModels);
        }

        // POST: StudentRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? StudentId)
        {
            if(StudentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistrationModels studentRegistration = db.StudentRegistration.Find(StudentId);
            if(studentRegistration != null)
            {
                try 
                {
                    db.StudentRegistration.Remove(studentRegistration);
                    db.SaveChanges();
                    return RedirectToAction("RegList");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("customerror", CustomDataSaveError);
                }
            }
            return View("Details");
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
