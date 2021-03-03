using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeachersCommunity.Models;

namespace TeachersCommunity.Controllers
{
    public class AccountController : Controller
    {
        private Entities db = new Entities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email, string Password)
        {
            CredentialTbl credentialTbl = db.CredentialTbls.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
            if(credentialTbl!=null)
            {
                if(credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Student))
                {
                    return RedirectToAction("Dashboard", "Student");
                }
                else if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Admin))
                {
                    return RedirectToAction("Dashboard", "Admin/Admin");
                }
            }
            return View();
        }
    }
}