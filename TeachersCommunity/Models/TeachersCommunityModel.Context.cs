﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeachersCommunity.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminTbl> AdminTbls { get; set; }
        public virtual DbSet<AnswersTbl> AnswersTbls { get; set; }
        public virtual DbSet<AppointmentsTbl> AppointmentsTbls { get; set; }
        public virtual DbSet<CredentialTbl> CredentialTbls { get; set; }
        public virtual DbSet<QuestionTbl> QuestionTbls { get; set; }
        public virtual DbSet<RoleTbl> RoleTbls { get; set; }
        public virtual DbSet<StudentTbl> StudentTbls { get; set; }
        public virtual DbSet<StudyMaterialTbl> StudyMaterialTbls { get; set; }
        public virtual DbSet<SubjectTbl> SubjectTbls { get; set; }
        public virtual DbSet<TeachersStudentTbl> TeachersStudentTbls { get; set; }
        public virtual DbSet<TeacherTbl> TeacherTbls { get; set; }
        public virtual DbSet<EmailConfigTbl> EmailConfigTbls { get; set; }
        public virtual DbSet<StoreTbl> StoreTbls { get; set; }
    }
}
