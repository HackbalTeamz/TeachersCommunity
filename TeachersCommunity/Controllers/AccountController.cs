using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
                    StudentTbl studentTbl = db.StudentTbls.Where(x => x.CredID == credentialTbl.CredID).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(Convert.ToString(studentTbl.StudentID + "|" + ConstantValue.Student), false);
                    return RedirectToAction("Dashboard", "Student/Student");
                }
                else if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Admin))
                {
                    return RedirectToAction("Dashboard", "Admin/Admin");
                }
                else if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Teachers))
                {
                    TeacherTbl teacherTbl = db.TeacherTbls.Where(x => x.CredID == credentialTbl.CredID).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(Convert.ToString(teacherTbl.TeacherID + "|" + ConstantValue.Teachers), false);
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
            if(registrationVM.credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Student))
            {
                registrationVM.studentTbl = new StudentTbl();
                registrationVM.studentTbl.Name = registrationVM.Name;
                registrationVM.studentTbl.CredID = registrationVM.credentialTbl.CredID;
                registrationVM.studentTbl.Location = registrationVM.Location;
                registrationVM.studentTbl.Gender = registrationVM.Gender;
                registrationVM.studentTbl.Phone = registrationVM.Phone;
                registrationVM.studentTbl.EnteredOn = DateTime.Now;
                registrationVM.studentTbl.UpdatedOn = DateTime.Now;
                db.StudentTbls.Add(registrationVM.studentTbl);
            }
            else if (registrationVM.credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Teachers))
            {
                registrationVM.teacherTbl = new TeacherTbl();
                registrationVM.teacherTbl.FullName = registrationVM.Name;
                registrationVM.teacherTbl.CredID = registrationVM.credentialTbl.CredID;
                registrationVM.teacherTbl.Location = registrationVM.Location;
                registrationVM.teacherTbl.Gender = registrationVM.Gender;
                registrationVM.teacherTbl.Phone = registrationVM.Phone;
                registrationVM.teacherTbl.EnterdOn = DateTime.Now;
                registrationVM.teacherTbl.UpdatedOn = DateTime.Now;
                db.TeacherTbls.Add(registrationVM.teacherTbl);
            }
            db.SaveChanges();
            ViewBag.RoleID = new SelectList(db.RoleTbls, "RoleID", "RoleName");
            return View();
        }
    }
}