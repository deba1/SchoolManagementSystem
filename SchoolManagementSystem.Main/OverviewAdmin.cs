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
    public partial class OverviewAdmin : Form
    {
        SMSContext context = new SMSContext();
        public OverviewAdmin()
        {
            InitializeComponent();
        }

        private void OverviewAdmin_Load(object sender, EventArgs e)
        {
            lblStudents.Text = context.StudentInfoes.Count().ToString();
            lblTeachers.Text = context.TeacherInfoes.Count().ToString();
        }


    }
}
