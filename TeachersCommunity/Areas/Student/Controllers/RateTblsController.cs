using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeachersCommunity.Models;

namespace TeachersCommunity.Areas.Student.Controllers
{
    public class RateTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: Student/RateTbls
        public ActionResult Index()
        {
            List<RateTbl> ObjectList = new List<RateTbl>();
            long StudentID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            foreach (var item in db.TeachersStudentTbls.Where(x => x.StudentId == StudentID))
            {
                ObjectList.AddRange(db.RateTbls.Include(r => r.StudentTbl).Include(r => r.TeacherTbl).Where(x => x.StudentID == StudentID & x.TeacherID == item.TeacherId));
            }
            return View(ObjectList.ToList());
        }

        // GET: Student/RateTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateTbl rateTbl = db.RateTbls.Find(id);
            if (rateTbl == null)
            {
                return HttpNotFound();
            }
            return View(rateTbl);
        }

        // GET: Student/RateTbls/Create
        public ActionResult Create()
        {
            List<TeacherTbl> ObjectList = new List<TeacherTbl>();
            long StudentID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            foreach (var item in db.TeachersStudentTbls.Where(x => x.StudentId == StudentID))
            {
                ObjectList.Add(db.TeacherTbls.Find(item.TeacherId));
            }
            ViewBag.TeacherID = new SelectList(ObjectList, "TeacherID", "FullName");
            return View();
        }

        // POST: Student/RateTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateTbl rateTbl)
        {
            if (ModelState.IsValid)
            {
                long StudentID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
                rateTbl.StudentID = StudentID;
                rateTbl.EnteredOn = DateTime.Now;
                rateTbl.UpdatedOn = DateTime.Now;
                db.RateTbls.Add(rateTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.StudentTbls, "StudentID", "Name", rateTbl.StudentID);
            ViewBag.TeacherID = new SelectList(db.TeacherTbls, "TeacherID", "FullName", rateTbl.TeacherID);
            return View(rateTbl);
        }

        // GET: Student/RateTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateTbl rateTbl = db.RateTbls.Find(id);
            if (rateTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.StudentTbls, "StudentID", "Name", rateTbl.StudentID);
            ViewBag.TeacherID = new SelectList(db.TeacherTbls, "TeacherID", "FullName", rateTbl.TeacherID);
            return View(rateTbl);
        }

        // POST: Student/RateTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingID,TeacherID,StudentID,Rate,EnteredOn,UpdatedOn")] RateTbl rateTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.StudentTbls, "StudentID", "Name", rateTbl.StudentID);
            ViewBag.TeacherID = new SelectList(db.TeacherTbls, "TeacherID", "FullName", rateTbl.TeacherID);
            return View(rateTbl);
        }

        // GET: Student/RateTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateTbl rateTbl = db.RateTbls.Find(id);
            if (rateTbl == null)
            {
                return HttpNotFound();
            }
            return View(rateTbl);
        }

        // POST: Student/RateTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateTbl rateTbl = db.RateTbls.Find(id);
            db.RateTbls.Remove(rateTbl);
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
