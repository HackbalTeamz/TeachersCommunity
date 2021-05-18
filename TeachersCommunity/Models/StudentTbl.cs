//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class StudentTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentTbl()
        {
            this.QuestionTbls = new HashSet<QuestionTbl>();
            this.StudyMaterialTbls = new HashSet<StudyMaterialTbl>();
            this.TeachersStudentTbls = new HashSet<TeachersStudentTbl>();
            this.RateTbls = new HashSet<RateTbl>();
        }
    
        public long StudentID { get; set; }
        public long CredID { get; set; }
        public long CountryID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string HighestQualification { get; set; }
        public string CurrentStatus { get; set; }
        public string ProfilePic { get; set; }
        public string Location { get; set; }
        public System.DateTime EnteredOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual CredentialTbl CredentialTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionTbl> QuestionTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudyMaterialTbl> StudyMaterialTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeachersStudentTbl> TeachersStudentTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RateTbl> RateTbls { get; set; }
    }
}
