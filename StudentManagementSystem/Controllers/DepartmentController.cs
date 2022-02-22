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
    public class DepartmentController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();
        private string CustomDataSaveError = new ErrorController().DataSaveCustomError();

        public DepartmentController()
        {
            ViewBag.title = "Student Department";
        }

        // GET: DepartmentModels
        public ActionResult DepartmentList()
        {
            return View(db.Department.ToList());
        }

        // GET: DepartmentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModels department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: DepartmentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeptName")] DepartmentModels department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Department.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("DepartmentList");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("customerror", CustomDataSaveError);
                }
            }

            return View(department);
        }

        // GET: DepartmentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModels department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View("Create", department);
        }

        // POST: DepartmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeptName")] DepartmentModels department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(department).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DepartmentList");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("customerror", CustomDataSaveError);
                }
            }
            return View("Create", department);
        }

        // GET: DepartmentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModels department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View("Details", department);
        }

        // POST: DepartmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModels department = db.Department.Find(id);
            if(department != null)
            {
                try
                {
                    db.Department.Remove(department);
                    db.SaveChanges();
                    return RedirectToAction("DepartmentList");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("customerror", CustomDataSaveError);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
