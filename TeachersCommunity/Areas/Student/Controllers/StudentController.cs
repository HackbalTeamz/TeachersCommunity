using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachersCommunity.Areas.Student.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/Student
        public ActionResult Dashboard()
        {
            StudentDashboardVM studentDashboardVM = new StudentDashboardVM();
            return View(studentDashboardVM);
        }
    }
}