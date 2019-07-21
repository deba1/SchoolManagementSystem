//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagementSystem.Main
{
    using System;
    using System.Collections.Generic;
    
    public partial class SectionInfo
    {
        public SectionInfo()
        {
            this.ClassRoutines = new HashSet<ClassRoutine>();
            this.NoticeInfoes = new HashSet<NoticeInfo>();
            this.StudentInfoes = new HashSet<StudentInfo>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public System.DateTime TimeStart { get; set; }
        public System.DateTime TimeEnd { get; set; }
        public string RoomNo { get; set; }
        public int ClassID { get; set; }
        public int Capacity { get; set; }
    
        public virtual ClassInfo ClassInfo { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<NoticeInfo> NoticeInfoes { get; set; }
        public virtual ICollection<StudentInfo> StudentInfoes { get; set; }
    }
}
