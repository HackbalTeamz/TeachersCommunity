using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeachersCommunity.Models;

namespace TeachersCommunity.Areas.Student.Controllers
{
    public class TeacherDetailsController : Controller
    {
        private Entities db = new Entities();
        // GET: Student/TeacherDetails
        public ActionResult Index(int? id)
        {
            StudentDashboardVM studentDashboardVM = new StudentDashboardVM();
            if (id!=0)
            {
                studentDashboardVM.teacherTbl = db.TeacherTbls.Find(id);
            }
            else
            {
                studentDashboardVM.teacherTbl = new TeacherTbl();
            }
            return View(studentDashboardVM);
        }
        public ActionResult Interest(int? id)
        {
            long StudentID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            TeachersStudentTbl teachersStudentTbl = new TeachersStudentTbl();
            teachersStudentTbl.TeacherId = id;
            teachersStudentTbl.StudentId = StudentID;
            teachersStudentTbl.IsApprove = false;
            db.TeachersStudentTbls.Add(teachersStudentTbl);
            db.SaveChanges();
            return RedirectToAction("Index", "SearchTeachers");
        }
        public ActionResult ApprovedTeachersList()
        {
            long StudentID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            List<TeacherTbl> teachersStudentTbl = db.TeachersStudentTbls.Where(x=>x.StudentId == StudentID & x.IsApprove == true).Select(x=>x.TeacherTbl).ToList();
            return View(teachersStudentTbl);
        }
        public ActionResult PendingTeachersList()
        {
            long StudentID = Convert.ToInt64(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0]);
            List<TeacherTbl> teachersStudentTbl = db.TeachersStudentTbls.Where(x => x.StudentId == StudentID & x.IsApprove == false).Select(x => x.TeacherTbl).ToList();
            return View(teachersStudentTbl);
        }
    }
}