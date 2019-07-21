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
    public partial class ResultManager : Form
    {
        SMSContext context = new SMSContext();
        List<SectionInfo> mysections;
        public ResultManager()
        {
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = "";
            this.LoadData();
        }

        public void LoadData()
        {
            SectionInfo ss = (SectionInfo)ddlSection.SelectedItem;
            var studentInfo = context.StudentInfoes.Where(x=>x.SectionInfo == ss).ToList();
            dgvStudents.AutoGenerateColumns = false;
            if (txtSearch.Text != "")
            {
                studentInfo = studentInfo.Where(d => d.Name.Contains(txtSearch.Text)).ToList();
            }
            dgvStudents.DataSource = studentInfo;
            dgvStudents.Refresh();
            //dgvStudents.ClearSelection();
            if (studentInfo.Count > 0)
            {
                this.LoadData(studentInfo.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            ResultInfo nr = null;
            var result = context.ResultInfoes.FirstOrDefault(x => x.ID == id && x.SubjectInfo == Globals.CUR_USER.TeacherInfo.SubjectInfo);
            if (result == null)
            {
                nr = new ResultInfo();
                nr.StudentID = id;
                nr.SubjectInfo = Globals.CUR_USER.TeacherInfo.SubjectInfo;
                nr.HalfYearly = 0;
                nr.Yearly = 0;
                context.ResultInfoes.Add(nr);
                context.SaveChanges();
            }
            txtID.Text = nr==null ? result.ID.ToString() : nr.ID.ToString();
            txtHalfYearly.Text = result.HalfYearly.ToString();
            txtYearly.Text = result.Yearly.ToString();
            
        }

        private void New()
        {
            txtID.Text = txtHalfYearly.Text = txtYearly.Text = "";
            dgvStudents.ClearSelection();
        }

        private void ResultManager_Load(object sender, EventArgs e)
        {
            mysections = Globals.CUR_USER.TeacherInfo.ClassRoutines.Select(x => x.SectionInfo).Distinct().ToList();
            ddlCurriculum.DataSource = context.ClassInfoes.ToList().Select(x => x.Year).Distinct().ToList();
            if (ddlCurriculum.SelectedItem != null)
            {
                var curr = 0;
                try
                {
                    curr = Convert.ToInt32(ddlCurriculum.SelectedItem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in init");
                }
                ddlClass.DataSource = context.ClassInfoes.Where(x => x.Year == curr).ToList();
                ddlClass.DisplayMember = "Title";
            }
            ddlClass.SelectedItem = null;
            ddlSection.SelectedItem = null;
            ddlCurriculum.SelectedItem = null;
        }

        private void ddlCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curr = 0;
            try
            {
                curr = Convert.ToInt32(ddlCurriculum.SelectedItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ddlCurriculum event");
            }
            ddlClass.DataSource = context.ClassInfoes.Where(x => x.Year == curr).ToList();
            ddlClass.DisplayMember = "Title";
            ddlClass.SelectedItem = null;
        }

        private void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassInfo cls = (ClassInfo)ddlClass.SelectedItem;
            if (cls == null)
                return;
            ddlSection.DataSource = cls.SectionInfoes.Intersect(mysections).ToList();
            ddlSection.DisplayMember = "Title";
            ddlSection.SelectedItem = null;
        }

        private void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal hy = 0, y = 0;
            if (!String.IsNullOrEmpty(txtHalfYearly.Text))
            {
                hy = Convert.ToDecimal(txtHalfYearly.Text);
            }
            if (!String.IsNullOrEmpty(txtYearly.Text))
            {
                y = Convert.ToDecimal(txtYearly.Text);
            }

            try
            {
                int rid = Int32.Parse(txtID.Text);
                var result = context.ResultInfoes.FirstOrDefault(d => d.ID == rid);
                if (result == null)
                {
                    this.Init();
                    return;
                }

                result.HalfYearly = Convert.ToDecimal(txtHalfYearly.Text);
                result.Yearly = Convert.ToDecimal(txtYearly.Text);
                context.SaveChanges();
                this.LoadData();
                this.LoadData(result.ID);


                dgvStudents.ClearSelection();
                for (int i = 0; i < dgvStudents.Rows.Count; i++)
                {
                    string id = dgvStudents.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvStudents.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException);
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }
    }
}
