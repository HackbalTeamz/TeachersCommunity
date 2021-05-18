using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TeachersCommunity.Models;
using TeachersCommunity.ViewModel;

namespace TeachersCommunity.Helper
{
    public class EmailHelper
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected Entities db = new Entities();
        public bool EmailSend(EmailVM emailVM)
        {
            EmailConfigTbl emailConfigTbl = db.EmailConfigTbls.Where(x => x.IsActive == true).FirstOrDefault();
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(emailConfigTbl.Email);
            message.To.Add(new MailAddress(emailVM.SendEmail));
            message.Bcc.Add(new MailAddress("abdu@hackbal.com"));
            message.Subject = EmailSubjectBuilder(emailVM.Name, emailVM.Subject);
            message.IsBodyHtml = true;
            message.Body = EmailBodyBuilder(emailVM.Name, emailVM.EmailCode, emailVM.EmailContent, emailVM.EmailType);
            if (emailVM.AttachmentPath != null)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(emailVM.AttachmentPath);
                message.Attachments.Add(attachment);
            }
            smtp.Port = Convert.ToInt32(emailConfigTbl.EmailPort);
            smtp.Host = emailConfigTbl.EmailHost;
            smtp.EnableSsl = Convert.ToBoolean(emailConfigTbl.EnableSSL);
            smtp.UseDefaultCredentials = Convert.ToBoolean(emailConfigTbl.UseDefaultCred);
            smtp.Credentials = new NetworkCredential(emailConfigTbl.Email, emailConfigTbl.EmailPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                log.Info("Message Send:-" + message.Body);
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }

        }
        public string EmailBodyBuilder(string Name, string EmailCode, string MessageContent, string Type)
        {
            StoreTbl storeTbl = db.StoreTbls.Where(x => x.IsActive == true).FirstOrDefault();
            //string UnSubs = "If you wish to opt out of all type of emails, click <a href='"+ storeTbl.StoreURL+ "Home/UnSubcribeEmail'>Unsubscribe</a>";
            if (Type == "Registration")
            {

                string messageBody = "Hai " + Name + " " + MessageContent + " " + EmailCode;
                return messageBody;
            }
            else if (Type == "ResetPassword")
            {
                string messageBody = "Hai " + Name + " " + MessageContent + " " + EmailCode;
                return messageBody;
            }
            else if (Type == "Welcome")
            {
                try
                {
                    string textFile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Template/WelcomeEmailTemplate.html");
                    string Body = File.ReadAllText(textFile);
                    string messageBody = String.Format(Body, Name, EmailCode, storeTbl.StoreURL, MessageContent);
                    return messageBody;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
            else if (Type == "PFCourse")
            {
                try
                {
                    string textFile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Template/PFCourse.html");
                    string Body = File.ReadAllText(textFile);
                    string messageBody = String.Format(Body, Name, storeTbl.StoreURL);
                    return messageBody;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
            else
            {
                try
                {
                    //string textFile = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Template/EmailTemplate.html");
                    string Body = "Hai {0}, <br> {1}";
                    string messageBody = String.Format(Body, Name, MessageContent);
                    return messageBody;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }

        }
        public string EmailSubjectBuilder(string Name, string Subject)
        {
            try
            {
                string messageBody = String.Format("{0}", Subject);
                return messageBody;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
    }
}