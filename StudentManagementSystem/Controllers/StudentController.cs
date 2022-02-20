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
    public class StudentController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        public StudentController()
        {
            ViewBag.title = "Student";
        }

        private SelectList AllDeparment()
        {
            SelectList allDepartment = new SelectList(db.Department, "Id", "DeptName");

            return allDepartment;
        }

        // GET: Student
        public ActionResult StudentList()
        {
            return View(db.Student.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.Student.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.departments = AllDeparment();
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DateOfBirth,DeptId")] StudentModel student)
        {
            ViewBag.departments = AllDeparment();
            if (ModelState.IsValid)
            {
                DepartmentModels department = db.Department.Find(student.DeptId);
                if (department != null)
                {
                    db.Student.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("StudentList");
                }
                ModelState.AddModelError(nameof(StudentModel.DeptId), "Please select department");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.departments = AllDeparment();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View("Create", student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateOfBirth,DeptId")] StudentModel student)
        {
            ViewBag.departments = AllDeparment();
            if (ModelState.IsValid)
            {
                DepartmentModels department = db.Department.Find(student.DeptId);
                if (student != null)
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("StudentList");
                }
                ModelState.AddModelError(nameof(StudentModel.DeptId), "Please selsect department");
            }
            return View("Create", student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.Student.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View("Details", studentModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentModel studentModel = db.Student.Find(id);
            db.Student.Remove(studentModel);
            db.SaveChanges();
            return RedirectToAction("StudentList");
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
