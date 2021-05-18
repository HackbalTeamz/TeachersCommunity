using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeachersCommunity.Models;

namespace TeachersCommunity.Areas.Teachers.Controllers
{
    public class StudentListController : Controller
    {
        private Entities db = new Entities();
        // GET: Teachers/StudentList
        public ActionResult Index()
        {
            long TeacherID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            var studentTbls = db.TeachersStudentTbls.Where(x=>x.TeacherId == TeacherID).Select(x=>x.StudentTbl).ToList();
            return View(studentTbls.ToList());
            //return View();
        }
        public ActionResult Approve(long id)
        {
            long TeacherID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            TeachersStudentTbl TeachersStudentTbls = db.TeachersStudentTbls.Where(x => x.TeacherId == TeacherID & x.StudentId == id).FirstOrDefault();
            TeachersStudentTbls.IsApprove = true;
            db.Entry(TeachersStudentTbls).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}