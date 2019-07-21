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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void LoadPage(Form fm, Panel to)
        {
            this.Text = fm.Text;
            fm.TopLevel = false;
            fm.AutoScroll = true;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            to.Controls.Clear();
            to.Controls.Add(fm);
            fm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.CUR_USER = null;
            this.Hide();
            new LoginScreen().Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (Globals.CUR_USER.StudentInfo != null)
            {
                mnuAdmin.Visible = false;
                mnuTeacher.Visible = false;
                this.LoadPage(new OverviewStudent(), pnlContainer);
            }
            else if (Globals.CUR_USER.TeacherInfo != null)
            {
                mnuAdmin.Visible = false;
                mnuStudent.Visible = false;
                this.LoadPage(new OverviewTeacher(), pnlContainer);
            }
            else
            {
                mnuStudent.Visible = false;
                mnuTeacher.Visible = false;
                this.LoadPage(new OverviewAdmin(), pnlContainer);
            }
            this.Text = "Welcome, " + (Globals.CUR_USER.StudentInfo != null ? Globals.CUR_USER.StudentInfo.Name : Globals.CUR_USER.TeacherInfo != null ? Globals.CUR_USER.TeacherInfo.Name : Globals.CUR_USER.Username);
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void allStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadPage(new StudentManager(), pnlContainer);
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadPage(new ClassManager(), pnlContainer);
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Welcome, " + Globals.CUR_USER.Username;
            this.LoadPage(new OverviewAdmin(), pnlContainer);
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadPage(new SubjectManager(), pnlContainer);
        }

        private void allTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadPage(new TeacherManager(), pnlContainer);
        }

        private void uploadResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadPage(new ResultManager(), pnlContainer);
        }

        private void noticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadPage(new NoticeManager(), pnlContainer);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.LoadPage(new NoticeView(), pnlContainer);
        }
    }
}
