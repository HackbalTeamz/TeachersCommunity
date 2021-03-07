using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeachersCommunity.Areas.Teachers.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Teachers/Teachers
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}