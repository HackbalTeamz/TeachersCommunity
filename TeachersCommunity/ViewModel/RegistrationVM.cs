using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeachersCommunity.Models;

namespace TeachersCommunity
{
    public class RegistrationVM
    {
        public CredentialTbl credentialTbl { get; set; }
        public AdminTbl adminTbl { get; set; }
        public StudentTbl studentTbl { get; set; }
        public TeacherTbl teacherTbl { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
    }
}