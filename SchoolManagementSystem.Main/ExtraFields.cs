using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Main
{
    partial class StudentInfo
    {
        public string ClassTitle
        {
            get
            {
                if (this.ClassInfo == null)
                    return "-";
                return this.ClassInfo.Title.ToString();
            }
        }

        public string SectionTitle
        {
            get
            {
                if (this.SectionInfo == null)
                    return "-";
                return this.SectionInfo.Title.ToString();
            }
        }
    }


    partial class SectionInfo
    {
        public string Signature
        {
            get
            {
                return this.ClassTitle + "-" + this.Title;
            }
        }
        public string ClassTitle
        {
            get
            {
                if (this.ClassInfo == null)
                    return "-";
                return this.ClassInfo.Title.ToString();
            }
        }
        public string Start
        {
            get
            {
                if (this.ClassInfo == null)
                    return "-";
                return this.TimeStart.ToString("hh:mm tt");
            }
        }

        public string End
        {
            get
            {
                if (this.ClassInfo == null)
                    return "-";
                return this.TimeEnd.ToString("hh:mm tt");
            }
        }
    }

    partial class CurriculumDetail
    {
        public string Subject
        {
            get
            {
                if (this.SubjectInfo == null)
                    return "-";
                return this.SubjectInfo.Name;
            }
        }

    }

    partial class ClassRoutine
    {
        public string Start
        {
            get
            {
                return this.TimeStart.ToString("hh:mm tt");
            }
        }

        public string End
        {
            get
            {
                return this.TimeEnd.ToString("hh:mm tt");
            }
        }

        public string Subject
        {
            get
            {
                if (this.SubjectInfo == null)
                    return "-";
                return this.SubjectInfo.Name;
            }
        }

        public string Teacher
        {
            get
            {
                if (this.TeacherInfo == null)
                    return "-";
                return this.TeacherInfo.Name;
            }
        }

        public string Day
        {
            get
            {
                if (this.DayInfo == null)
                    return "-";
                return this.DayInfo.Title;
            }
        }
    }

    partial class TeacherInfo
    {
        public string AssSubject
        {
            get
            {
                if (this.SubjectInfo == null)
                    return "-";
                return this.SubjectInfo.Name;
            }
        }
    }

    partial class NoticeInfo
    {
        public string SecSignature
        {
            get
            {
                if (this.SectionInfo == null)
                    return "-";
                return this.SectionInfo.Signature;
            }
        }
    }
}
