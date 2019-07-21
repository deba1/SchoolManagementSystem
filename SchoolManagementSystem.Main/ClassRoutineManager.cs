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
    public partial class ClassRoutineManager : Form
    {
        SMSContext context = new SMSContext();
        int sectionId = 0;
        SectionInfo section;
        public ClassRoutineManager(int sid)
        {
            sectionId = sid;
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = "";
            section = context.SectionInfoes.FirstOrDefault(d => d.ID == sectionId);
            if (section == null)
            {
                this.Init();
                return;
            }

            ddlDay.DataSource = context.DayInfoes.ToList();
            ddlDay.DisplayMember = "Title";
            ddlDay.SelectedItem = null;
            var curriculum = section.ClassInfo.CurriculumDetails.ToList();
            List<SubjectInfo> subs = new List<SubjectInfo>();
            foreach (var sub in curriculum)
            {
                subs.Add(sub.SubjectInfo);
            }
            ddlSubject.DataSource = subs;
            ddlSubject.DisplayMember = "Name";
            ddlSubject.SelectedItem = null;
            if (ddlSubject.SelectedItem==null)
            {
                ddlTeacher.Enabled = false;
            }
            else
            {
                ddlTeacher.Enabled = true;
            }
            this.LoadData();
        }

        public void LoadData()
        {
            dgvClassRoutine.AutoGenerateColumns = false;
            var classRoutine = context.ClassRoutines.Where(d=>d.SectionID==this.sectionId).ToList();
            dgvClassRoutine.DataSource = classRoutine;
            dgvClassRoutine.Refresh();
            if (classRoutine.Count > 0)
            {
                this.LoadData(classRoutine.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            var classRoutine = context.ClassRoutines.FirstOrDefault(d => d.ID == id);
            if (classRoutine == null)
            {
                this.New();
                return;
            }
            txtID.Text = classRoutine.ID.ToString();
            ddlDay.SelectedItem = classRoutine.DayInfo;
            ddlSubject.SelectedItem = classRoutine.SubjectInfo;
            ddlTeacher.SelectedItem = classRoutine.TeacherInfo;
            dtStart.Text = classRoutine.TimeStart.ToString();
            dtEnd.Text = classRoutine.TimeEnd.ToString();
        }

        private void New()
        {
            txtID.Text = "";

            ddlSubject.SelectedItem = null;
            ddlDay.SelectedItem = null;
            ddlTeacher.SelectedItem = null;
            dgvClassRoutine.ClearSelection();
        }


        private void dgvClassRoutine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvClassRoutine.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }

        private void ClassRoutineManager_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            this.Init();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("Please select a row first");
                    return;
                }
                if (MessageBox.Show("Are you sure delete this item?", "Delete", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                int id = Int32.Parse(txtID.Text);
                var classRoutine = context.ClassRoutines.FirstOrDefault(d => d.ID == id);
                if (classRoutine == null)
                {
                    this.Init();
                    return;
                }
                context.ClassRoutines.Remove(classRoutine);
                context.SaveChanges();
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ClassRoutine cr;
                if (txtID.Text == "")
                {
                    cr = new ClassRoutine();
                    context.ClassRoutines.Add(cr);

                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    cr = context.ClassRoutines.FirstOrDefault(d => d.ID == id);
                    if (cr == null)
                    {
                        this.Init();
                        return;
                    }
                }

                cr.DayInfo = (DayInfo) ddlDay.SelectedItem;
                cr.SectionInfo = section;
                var sub = (SubjectInfo)ddlSubject.SelectedItem;
                cr.SubjectID = sub.ID;
                cr.TeacherInfo = (TeacherInfo) ddlTeacher.SelectedItem;
                cr.TimeStart = Convert.ToDateTime(dtStart.Text);
                cr.TimeEnd = Convert.ToDateTime(dtEnd.Text);
                context.SaveChanges();
                this.LoadData();
                this.LoadData(cr.ID);


                dgvClassRoutine.ClearSelection();
                for (int i = 0; i < dgvClassRoutine.Rows.Count; i++)
                {
                    string id = dgvClassRoutine.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvClassRoutine.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException);
            }
        }

        private void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectInfo sub = (SubjectInfo)ddlSubject.SelectedItem;
            if (sub == null)
            {
                ddlTeacher.Enabled = false;
                return;
            }
            else
            {
                ddlTeacher.Enabled = true;
            }
            ddlTeacher.DataSource = sub.TeacherInfoes.ToList();
            ddlTeacher.DisplayMember = "Name";
            ddlTeacher.SelectedItem = null;
        }

    }
}
