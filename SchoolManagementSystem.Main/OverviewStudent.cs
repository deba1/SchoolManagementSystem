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
    public partial class OverviewStudent : Form
    {
        SMSContext context = new SMSContext();
        public OverviewStudent()
        {
            InitializeComponent();
        }

        public void LoadRoutine(int day, Label lbl)
        {
            var routine = Globals.CUR_USER.StudentInfo.SectionInfo.ClassRoutines.Where(x => x.DayID == day).OrderBy(x=>x.TimeStart).ToList();
            foreach (var rou in routine)
            {
                lbl.Text = (lbl.Text == "---" ? "" : lbl.Text+" |") + " " + rou.SubjectInfo.Name + " (" + rou.Start + ") ";
            }
        }

        private void OverviewStudent_Load(object sender, EventArgs e)
        {
            var section = Globals.CUR_USER.StudentInfo.SectionInfo;
            lblHeader.Text = "Class Routine (Class - " + section.ClassTitle + ", Section - " + section.Title + ", Room - " + section.RoomNo+")";

            LoadRoutine(1, lblSat);
            LoadRoutine(2, lblSun);
            LoadRoutine(3, lblMon);
            LoadRoutine(4, lblTue);
            LoadRoutine(5, lblWed);
            LoadRoutine(6, lblThu);
        }
    }
}
