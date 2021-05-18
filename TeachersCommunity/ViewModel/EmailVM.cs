using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeachersCommunity.ViewModel
{
    public class EmailVM
    {
        public string Name { get; set; }
        public string SendEmail { get; set; }
        public string AttachmentPath { get; set; }
        public string Subject { get; set; }
        public string EmailType { get; set; }
        public string EmailCode { get; set; }
        public string EmailContent { get; set; }
    }
}