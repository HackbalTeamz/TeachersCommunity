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
                    return RedirectToAction("Dashboard", "Student/Student");
                }
                else if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Admin))
                {
                    return RedirectToAction("Dashboard", "Admin/Admin");
                }
                else if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Teachers))
                {
                    return RedirectToAction("Dashboard", "Teachers/Teachers");
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.RoleID = new SelectList(db.RoleTbls, "RoleID", "RoleName");
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationVM registrationVM)
        {
            registrationVM.credentialTbl.EnteredOn = DateTime.Now;
            registrationVM.credentialTbl.UpdatedOn = DateTime.Now;
            db.CredentialTbls.Add(registrationVM.credentialTbl);
            db.SaveChanges();
            return View();
        }
    }
}