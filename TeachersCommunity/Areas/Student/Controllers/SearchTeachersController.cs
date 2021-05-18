using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeachersCommunity.Models;

namespace TeachersCommunity.Areas.Student.Controllers
{
    public class SearchTeachersController : Controller
    {
        private Entities db = new Entities();
        // GET: Student/SearchTeachers
        public ActionResult Index()
        {
            StudentDashboardVM studentDashboardVM = new StudentDashboardVM();
            return View(studentDashboardVM);
        }
        [HttpPost]
        public ActionResult Index(string Location)
        {
            StudentDashboardVM studentDashboardVM = new StudentDashboardVM();
            studentDashboardVM.teacherTbllist = db.TeacherTbls.Where(c => c.Location.Contains(Location)&&c.IsActive == true).ToList();
            studentDashboardVM.fullteacherTbllist = db.TeacherTbls.ToList();

            return View(studentDashboardVM);
        }
    }
}