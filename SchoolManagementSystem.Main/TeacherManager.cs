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
    public partial class TeacherManager : Form
    {
        SMSContext context = new SMSContext();
        SMSContext context2 = new SMSContext();
        public TeacherManager()
        {
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = txtName.Text = txtFather.Text = txtMother.Text = txtAddress.Text = txtContactNo.Text = txtSkills.Text = "";
            ddlAssSubject.DataSource = context.SubjectInfoes.ToList();
            ddlAssSubject.DisplayMember = "Name";
            ddlAssSubject.SelectedItem = null;
            this.LoadData();
        }

        public void LoadData()
        {
            dgvTeachers.AutoGenerateColumns = false;
            var teacherInfo = context.TeacherInfoes.ToList();
            if (txtSearch.Text != "")
            {
                teacherInfo = teacherInfo.Where(d => d.Name.Contains(txtSearch.Text)).ToList();
            }
            dgvTeachers.DataSource = teacherInfo;
            dgvTeachers.Refresh();
            if (teacherInfo.Count > 0)
            {
                this.LoadData(teacherInfo.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            var teacherInfo = context.TeacherInfoes.FirstOrDefault(d => d.ID == id);
            if (teacherInfo == null)
            {
                this.New();
                return;
            }
            txtID.Text = teacherInfo.ID.ToString();
            txtName.Text = teacherInfo.Name;
            txtFather.Text = teacherInfo.FatherName;
            txtMother.Text = teacherInfo.MotherName;
            txtAddress.Text = teacherInfo.Address;
            txtContactNo.Text = teacherInfo.ContactNo.ToString();
            dtDOB.Text = teacherInfo.DateOfBirth.ToString();
            txtSkills.Text = teacherInfo.Skills;
            ddlAssSubject.SelectedItem = teacherInfo.SubjectInfo;
        }

        private void New()
        {
            txtID.Text = txtName.Text = txtFather.Text = txtMother.Text = txtAddress.Text = txtAddress.Text = txtContactNo.Text = txtSkills.Text = "";

            ddlAssSubject.SelectedItem = null;
            dgvTeachers.ClearSelection();
        }


        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvTeachers.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }

        private void TeacherManager_Load(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please fill up Name field!");
                return;
            }
            else if (String.IsNullOrEmpty(txtFather.Text))
            {
                MessageBox.Show("Please fill up Father's Name field!");
                return;
            }

            else if (String.IsNullOrEmpty(txtMother.Text))
            {
                MessageBox.Show("Please fill up Mother's Name field!");
                return;
            }
            else if (String.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please fill up Address field!");
                return;
            }
            else if (String.IsNullOrEmpty(txtContactNo.Text))
            {
                MessageBox.Show("Please fill up Contact Number field!");
                return;
            }
            else if (txtContactNo.Text.Length != 10)
            {
                MessageBox.Show("Please enter currect Contact Number!");
                return;
            }
            else if (ddlAssSubject.SelectedItem == null)
            {
                MessageBox.Show("Please select a Subject!");
                return;
            }

            try
            {
                var subject = (SubjectInfo)ddlAssSubject.SelectedItem;
                TeacherInfo teacherInfo;
                UserCredential ucs;
                if (txtID.Text == "")
                {
                    teacherInfo = new TeacherInfo();
                    context.TeacherInfoes.Add(teacherInfo);
                    ucs = new UserCredential();
                    context2.UserCredentials.Add(ucs);
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    teacherInfo = context.TeacherInfoes.FirstOrDefault(d => d.ID == id);
                    ucs = context2.UserCredentials.FirstOrDefault(d => d.TeacherID == id);
                    if (teacherInfo == null || ucs == null)
                    {
                        this.Init();
                        return;
                    }
                }

                teacherInfo.Name = txtName.Text;
                teacherInfo.FatherName = txtFather.Text;
                teacherInfo.MotherName = txtMother.Text;
                teacherInfo.Address = txtAddress.Text;
                teacherInfo.DateOfBirth = Convert.ToDateTime(dtDOB.Text);
                teacherInfo.ContactNo = Convert.ToInt32(txtContactNo.Text);
                teacherInfo.SubjectInfo = subject;
                teacherInfo.Skills = txtSkills.Text;
                context.SaveChanges();
                ucs.Password = txtPassword.Text;
                ucs.Username = "T-" + teacherInfo.ID;
                ucs.UserTypeID = 3;
                ucs.TeacherID = teacherInfo.ID;
                context2.SaveChanges();
                this.LoadData();
                this.LoadData(teacherInfo.ID);


                dgvTeachers.ClearSelection();
                for (int i = 0; i < dgvTeachers.Rows.Count; i++)
                {
                    string id = dgvTeachers.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvTeachers.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException);
            }
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
                var teacherInfo = context.TeacherInfoes.FirstOrDefault(d => d.ID == id);
                var ucs = context2.UserCredentials.FirstOrDefault(d => d.TeacherID == id);
                if (teacherInfo == null || ucs == null)
                {
                    this.Init();
                    return;
                }
                context.TeacherInfoes.Remove(teacherInfo);
                context2.UserCredentials.Remove(ucs);

                context2.SaveChanges();
                context.SaveChanges();
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
