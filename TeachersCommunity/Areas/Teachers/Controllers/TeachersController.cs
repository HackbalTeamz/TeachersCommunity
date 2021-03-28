using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Security;
using TeachersCommunity.Models;

namespace TeachersCommunity.Areas.Teachers.Controllers
{
    public class TeachersController : Controller
    {
        private Entities db = new Entities();
        // GET: Teachers/Teachers
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult ProfileEdit()
        {
            long TeacherID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            TeacherTbl teacherTbl = db.TeacherTbls.Find(TeacherID);
            return View(teacherTbl);
        }
        [HttpPost]
        public ActionResult ProfileEdit(TeacherTbl teachers)
        {
            db.Entry(teachers).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}