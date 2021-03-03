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
    public class RoleTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/RoleTbls
        public ActionResult Index()
        {
            return View(db.RoleTbls.ToList());
        }

        // GET: Admin/RoleTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleTbl roleTbl = db.RoleTbls.Find(id);
            if (roleTbl == null)
            {
                return HttpNotFound();
            }
            return View(roleTbl);
        }

        // GET: Admin/RoleTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoleTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,RoleName")] RoleTbl roleTbl)
        {
            if (ModelState.IsValid)
            {
                db.RoleTbls.Add(roleTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleTbl);
        }

        // GET: Admin/RoleTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleTbl roleTbl = db.RoleTbls.Find(id);
            if (roleTbl == null)
            {
                return HttpNotFound();
            }
            return View(roleTbl);
        }

        // POST: Admin/RoleTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,RoleName")] RoleTbl roleTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleTbl);
        }

        // GET: Admin/RoleTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleTbl roleTbl = db.RoleTbls.Find(id);
            if (roleTbl == null)
            {
                return HttpNotFound();
            }
            return View(roleTbl);
        }

        // POST: Admin/RoleTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleTbl roleTbl = db.RoleTbls.Find(id);
            db.RoleTbls.Remove(roleTbl);
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
