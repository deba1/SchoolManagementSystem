using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.Main
{
    public partial class OverviewTeacher : Form
    {
        SMSContext context = new SMSContext();
        public OverviewTeacher()
        {
            InitializeComponent();
        }

        public void LoadRoutine(int day, Label lbl)
        {
            var routine = context.ClassRoutines.Where(x => x.DayID == day && x.TeacherID == Globals.CUR_USER.TeacherID).OrderBy(x => x.TimeStart).ToList();
            foreach (var rou in routine)
            {
                lbl.Text = (lbl.Text == "---" ? "" : lbl.Text) + " " + rou.SubjectInfo.Name + " (@" + rou.Start + ", Sec:"+rou.SectionInfo.Title+", Room:"+rou.SectionInfo.RoomNo+") ";
            }
        }

        private void OverviewTeacher_Load(object sender, EventArgs e)
        {
            LoadRoutine(1, lblSat);
            LoadRoutine(2, lblSun);
            LoadRoutine(3, lblMon);
            LoadRoutine(4, lblTue);
            LoadRoutine(5, lblWed);
            LoadRoutine(6, lblThu);
        }
    }
}
