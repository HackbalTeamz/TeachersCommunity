using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeachersCommunity.Models;

namespace TeachersCommunity.Areas.Admin.Controllers
{
    public class TeacherTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/TeacherTbls
        public ActionResult Index()
        {
            var teacherTbls = db.TeacherTbls.Include(t => t.CredentialTbl);
            return View(teacherTbls.ToList());
        }

        // GET: Admin/TeacherTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherTbl teacherTbl = db.TeacherTbls.Find(id);
            if (teacherTbl == null)
            {
                return HttpNotFound();
            }
            return View(teacherTbl);
        }

        // GET: Admin/TeacherTbls/Create
        public ActionResult Create()
        {
            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email");
            return View();
        }

        // POST: Admin/TeacherTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherID,CredID,FullName,Location,EnterdOn,UpdatedOn,Gender,Phone,DOB,IsOffline,OfflineTime,IsOnline,OnlineTime,Days,DemoClassURL")] TeacherTbl teacherTbl)
        {
            if (ModelState.IsValid)
            {
                db.TeacherTbls.Add(teacherTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email", teacherTbl.CredID);
            return View(teacherTbl);
        }

        // GET: Admin/TeacherTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherTbl teacherTbl = db.TeacherTbls.Find(id);
            if (teacherTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email", teacherTbl.CredID);
            return View(teacherTbl);
        }

        // POST: Admin/TeacherTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherID,CredID,FullName,Location,EnterdOn,UpdatedOn,Gender,Phone,DOB,IsOffline,OfflineTime,IsOnline,OnlineTime,Days,DemoClassURL")] TeacherTbl teacherTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email", teacherTbl.CredID);
            return View(teacherTbl);
        }

        // GET: Admin/TeacherTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherTbl teacherTbl = db.TeacherTbls.Find(id);
            if (teacherTbl == null)
            {
                return HttpNotFound();
            }
            return View(teacherTbl);
        }

        // POST: Admin/TeacherTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TeacherTbl teacherTbl = db.TeacherTbls.Find(id);
            db.TeacherTbls.Remove(teacherTbl);
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
        public ActionResult ActivateTeachers()
        {
            var teacherTbls = db.TeacherTbls.Include(t => t.CredentialTbl);
            return View(teacherTbls.ToList());
        }
        public ActionResult StatusChange(long? id)
        {
            TeacherTbl teacherTbl = db.TeacherTbls.Find(id);
            if(teacherTbl.IsActive!=null)
            {
                if (Convert.ToBoolean(teacherTbl.IsActive))
                {
                    teacherTbl.IsActive = false;
                }
                else
                {
                    teacherTbl.IsActive = true;
                }
            }
            else
            {
                teacherTbl.IsActive = true;
            }
            db.Entry(teacherTbl).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ActivateTeachers");
        }
    }
}
