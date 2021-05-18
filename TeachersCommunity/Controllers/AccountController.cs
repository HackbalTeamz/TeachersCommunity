using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeachersCommunity.Helper;
using TeachersCommunity.Models;
using TeachersCommunity.ViewModel;

namespace TeachersCommunity.Controllers
{
    public class AccountController : Controller
    {
        private Entities db = new Entities();
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                if (Convert.ToBoolean(credentialTbl.IsEmailverify))
                {
                    if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Student))
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
                else
                {
                    return RedirectToAction("EmailVerification", new { Email = credentialTbl.Email });
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            List<RoleTbl> roleTbls = new List<RoleTbl>();

            foreach(var item in db.RoleTbls)
            {
                if(item.RoleID!=1)
                {
                    roleTbls.Add(item);
                }
            }
            ViewBag.RoleID = new SelectList(roleTbls, "RoleID", "RoleName");
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationVM registrationVM)
        {
            registrationVM.credentialTbl.EnteredOn = DateTime.Now;
            registrationVM.credentialTbl.UpdatedOn = DateTime.Now;
            registrationVM.credentialTbl.EmailVerificationCode = StringRandomGenerator.RandomNumber(6);
            registrationVM.credentialTbl.IsEmailverify = false;
            db.CredentialTbls.Add(registrationVM.credentialTbl);
            db.SaveChanges();
            EmailVM emailVM = new EmailVM();
            if (registrationVM.credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Student))
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
                emailVM.Name = registrationVM.studentTbl.Name;
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
                emailVM.Name = registrationVM.teacherTbl.FullName;
            }
            db.SaveChanges();
            
            emailVM.Subject = "Verify Your Email Address";
            emailVM.SendEmail = registrationVM.credentialTbl.Email;
            emailVM.EmailType = "Registration";
            emailVM.EmailContent = "To verify the email address belongs to you, enter the passcode below to your email verification page";
            emailVM.EmailCode = registrationVM.credentialTbl.EmailVerificationCode;
            new EmailHelper().EmailSend(emailVM);
            ViewBag.RoleID = new SelectList(db.RoleTbls, "RoleID", "RoleName");
            return RedirectToAction("EmailVerification", new { Email = registrationVM.credentialTbl.Email });
        }
        public ActionResult Logout()
        {
            Session["Role"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EmailVerification(string Email, string Msg)
        {
            CredentialTbl credenstialTbl = new CredentialTbl();
            credenstialTbl.Email = Email;
            ViewBag.Message = Msg;
            return View(credenstialTbl);
        }
        [HttpPost]
        public ActionResult EmailVerification(CredentialTbl credenstialTb)
        {
            string Msg = "Something Wrong, Please Contact Admin";
            try
            {
                if (credenstialTb.EmailVerificationCode != null)
                {
                    CredentialTbl credentialTbl = db.CredentialTbls.Where(x => x.Email == credenstialTb.Email).FirstOrDefault();
                    EmailVM emailVM = new EmailVM();
                    if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Student))
                    {
                        StudentTbl studentTbl = db.StudentTbls.Where(x => x.CredID == credentialTbl.CredID).FirstOrDefault();
                        
                        emailVM.Name = studentTbl.Name;
                        //FormsAuthentication.SetAuthCookie(Convert.ToString(studentTbl.StudentID + "|" + ConstantValue.Student), false);
                        //return RedirectToAction("Dashboard", "Student/Student");
                    }
                    else if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Admin))
                    {
                        return RedirectToAction("Dashboard", "Admin/Admin");
                    }
                    else if (credentialTbl.RoleID == Convert.ToInt32(ConstantValue.Teachers))
                    {
                        TeacherTbl teacherTbl = db.TeacherTbls.Where(x => x.CredID == credentialTbl.CredID).FirstOrDefault();
                        teacherTbl.IsActive = true;
                        db.Entry(teacherTbl).State = EntityState.Modified;
                        db.SaveChanges();
                        emailVM.Name = teacherTbl.FullName;
                        //FormsAuthentication.SetAuthCookie(Convert.ToString(teacherTbl.TeacherID + "|" + ConstantValue.Teachers), false);
                        //return RedirectToAction("Dashboard", "Teachers/Teachers");
                    }
                    //StudentTbl studentsTbl = db.StudentTbls.Where(x => x.CredID == credentialTbl.CredID).FirstOrDefault();
                    if (credentialTbl != null)
                    {
                        if (Convert.ToBoolean(credentialTbl.IsEmailverify))
                        {
                            Msg = "Email is Already Verified Please Login";
                            return RedirectToAction("Index", new { Msg = Msg });
                        }
                        else if (credentialTbl.EmailVerificationCode == credenstialTb.EmailVerificationCode)
                        {
                            credentialTbl.IsEmailverify = true;
                            credentialTbl.EmailVerificationCode = null;
                            credentialTbl.UpdatedOn = DateTime.UtcNow;
                            db.Entry(credentialTbl).State = EntityState.Modified;
                            db.SaveChanges();
                            emailVM.Subject = "Welcome Email | Kaizen Tutor";
                            emailVM.SendEmail = credentialTbl.Email;
                            emailVM.EmailType = "Welcome";
                            emailVM.EmailContent = "WelcomeEmail";
                            new EmailHelper().EmailSend(emailVM);
                            //emailVM = new EmailVM();
                            //emailVM.Subject = "New Student Registration Details | Kaizen Tutor";
                            //emailVM.SendEmail = "kaizentutors2020@gmail.com";
                            //emailVM.EmailType = "NewRegistrationInfo";
                            //emailVM.EmailContent = "Mobile Number:- " + studentsTbl.Phone;
                            //emailVM.Name = studentsTbl.FName + " " + studentsTbl.LName;
                            //new EmailHelper().EmailSend(emailVM);
                            Msg = "Email is Verified Please Login";
                            //string MsgCont = "Sucessfully Registered on Kaizen tutor, Please Login with Email and Password";
                            //List<StudentsTbl> studentsTbls = new List<StudentsTbl>();
                            //studentsTbls.Add(studentsTbl);
                            //_ = new SMSHelper().BulkSMSAsync(MsgCont, studentsTbls);
                            return RedirectToAction("Index", new { Msg = Msg });
                        }

                    }
                    else
                    {
                        Msg = "Incorrect Email, Please Try Again";
                        return RedirectToAction("EmailVerification", new { Msg = Msg });
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    log.InfoFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        log.InfoFormat("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("EmailVerification", new { Msg = Msg });
        }
    }
}