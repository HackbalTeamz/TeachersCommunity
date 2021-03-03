using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeachersCommunity.Models;

namespace TeachersCommunity.Controllers
{
    public class StudentTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: StudentTbls
        public ActionResult Index()
        {
            var studentTbls = db.StudentTbls.Include(s => s.CredentialTbl);
            return View(studentTbls.ToList());
        }

        // GET: StudentTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }
            return View(studentTbl);
        }

        // GET: StudentTbls/Create
        public ActionResult Create()
        {
            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email");
            return View();
        }

        // POST: StudentTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,CredID,CountryID,Name,Gender,DOB,Phone,HighestQualification,CurrentStatus,ProfilePic,Location,EnteredOn,UpdatedOn")] StudentTbl studentTbl)
        {
            if (ModelState.IsValid)
            {
                db.StudentTbls.Add(studentTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email", studentTbl.CredID);
            return View(studentTbl);
        }

        // GET: StudentTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email", studentTbl.CredID);
            return View(studentTbl);
        }

        // POST: StudentTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,CredID,CountryID,Name,Gender,DOB,Phone,HighestQualification,CurrentStatus,ProfilePic,Location,EnteredOn,UpdatedOn")] StudentTbl studentTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CredID = new SelectList(db.CredentialTbls, "CredID", "Email", studentTbl.CredID);
            return View(studentTbl);
        }

        // GET: StudentTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            if (studentTbl == null)
            {
                return HttpNotFound();
            }
            return View(studentTbl);
        }

        // POST: StudentTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            StudentTbl studentTbl = db.StudentTbls.Find(id);
            db.StudentTbls.Remove(studentTbl);
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
