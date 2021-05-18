using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeachersCommunity.Models;

namespace TeachersCommunity.Areas.Teachers.Controllers
{
    public class StudyMaterialTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: Teachers/StudyMaterialTbls
        public ActionResult Index()
        {
            var studyMaterialTbls = db.StudyMaterialTbls.Include(s => s.StudentTbl).Include(s => s.TeacherTbl);
            return View(studyMaterialTbls.ToList());
        }

        // GET: Teachers/StudyMaterialTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyMaterialTbl studyMaterialTbl = db.StudyMaterialTbls.Find(id);
            if (studyMaterialTbl == null)
            {
                return HttpNotFound();
            }
            return View(studyMaterialTbl);
        }

        // GET: Teachers/StudyMaterialTbls/Create
        public ActionResult Create()
        {
            List<StudentTbl> studentTbls = new List<StudentTbl>();
            long TeacherID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            foreach (var item in db.TeachersStudentTbls.Where(x=>x.TeacherId == TeacherID))
            {
                studentTbls.AddRange(db.StudentTbls.Where(x => x.StudentID == item.StudentId));
            }
            ViewBag.StudentID = new SelectList(studentTbls, "StudentID", "Name");
            ViewBag.TeacherID = new SelectList(db.TeacherTbls, "TeacherID", "FullName");
            return View();
        }

        // POST: Teachers/StudyMaterialTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudyMaterialTbl studyMaterialTbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                long TeacherID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
                if (file.ContentLength > 0)
                {
                    string _Extenstion = Path.GetExtension(file.FileName);
                    if (_Extenstion == ".pdf")
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/StudyMeterials"), _FileName);  //Folder Name ee Blue
                        file.SaveAs(_path);
                        studyMaterialTbl.MaterilaLink = _FileName;
                    }
                }
                studyMaterialTbl.TeacherID = TeacherID;
                studyMaterialTbl.CreatedOn = DateTime.Now;
                studyMaterialTbl.UpdatedOn = DateTime.Now;
                db.StudyMaterialTbls.Add(studyMaterialTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.StudentTbls, "StudentID", "Name", studyMaterialTbl.StudentID);
            ViewBag.TeacherID = new SelectList(db.TeacherTbls, "TeacherID", "FullName", studyMaterialTbl.TeacherID);
            return View(studyMaterialTbl);
        }

        // GET: Teachers/StudyMaterialTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyMaterialTbl studyMaterialTbl = db.StudyMaterialTbls.Find(id);
            if (studyMaterialTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.StudentTbls, "StudentID", "Name", studyMaterialTbl.StudentID);
            ViewBag.TeacherID = new SelectList(db.TeacherTbls, "TeacherID", "FullName", studyMaterialTbl.TeacherID);
            return View(studyMaterialTbl);
        }

        // POST: Teachers/StudyMaterialTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialID,StudentID,TeacherID,MaterialName,MaterialDetails,MaterilaLink,CreatedOn,UpdatedOn")] StudyMaterialTbl studyMaterialTbl)
        {
            if (ModelState.IsValid)
            {
                studyMaterialTbl.UpdatedOn = DateTime.Now;
                db.Entry(studyMaterialTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.StudentTbls, "StudentID", "Name", studyMaterialTbl.StudentID);
            ViewBag.TeacherID = new SelectList(db.TeacherTbls, "TeacherID", "FullName", studyMaterialTbl.TeacherID);
            return View(studyMaterialTbl);
        }

        // GET: Teachers/StudyMaterialTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyMaterialTbl studyMaterialTbl = db.StudyMaterialTbls.Find(id);
            if (studyMaterialTbl == null)
            {
                return HttpNotFound();
            }
            return View(studyMaterialTbl);
        }

        // POST: Teachers/StudyMaterialTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            StudyMaterialTbl studyMaterialTbl = db.StudyMaterialTbls.Find(id);
            db.StudyMaterialTbls.Remove(studyMaterialTbl);
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
