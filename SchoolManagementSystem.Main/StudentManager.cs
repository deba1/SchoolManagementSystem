using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace SchoolManagementSystem.Main
{
    public partial class StudentManager : Form
    {
        SMSContext context = new SMSContext();
        SMSContext context2 = new SMSContext();
        public StudentManager()
        {
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = txtName.Text = txtFather.Text = txtMother.Text = txtAddress.Text = txtContactNo.Text = "";
            
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
                    Console.WriteLine("Error in ddlCurriculum event");
                }
                ddlClass.DataSource = context.ClassInfoes.Where(x => x.Year == curr).ToList();
                ddlClass.DisplayMember = "Title";
            }
            ddlClass.SelectedItem = null;
            ddlSection.SelectedItem = null;
            ddlCurriculum.SelectedItem = null;
            this.LoadData();
        }

        public void LoadData()
        {
            dgvStudents.AutoGenerateColumns = false;
            var studentInfo = context.StudentInfoes.ToList();
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
            var stuInfo = context.StudentInfoes.FirstOrDefault(d => d.ID == id);
            if (stuInfo == null)
            {
                this.New();
                return;
            }
            txtID.Text = stuInfo.ID.ToString();
            txtName.Text = stuInfo.Name;
            txtFather.Text = stuInfo.FatherName;
            txtMother.Text = stuInfo.MotherName;
            txtAddress.Text = stuInfo.Address;
            dtDOB.Text = stuInfo.DateOfBirth.ToString();
            txtContactNo.Text = stuInfo.ContactNo.ToString();
            ddlClass.SelectedItem = stuInfo.SectionInfo.ClassInfo;
            ddlCurriculum.SelectedItem = stuInfo.ClassInfo.Year;
            ddlSection.SelectedItem = stuInfo.SectionInfo;
        }

        private void New()
        {
            txtID.Text = txtName.Text = txtFather.Text = txtMother.Text = txtAddress.Text = txtAddress.Text = txtContactNo.Text = "";

            ddlClass.SelectedItem = null;
            ddlSection.SelectedItem = null;
            ddlCurriculum.SelectedItem = null;
            dgvStudents.ClearSelection();
        }


        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }

        private void StudentManager_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassInfo cls = (ClassInfo) ddlClass.SelectedItem;
            if (cls == null)
                return;
            ddlSection.DataSource = cls.SectionInfoes.ToList();
            ddlSection.DisplayMember = "Title";
            ddlSection.SelectedItem = null;
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
            if (String.IsNullOrEmpty(txtName.Text) )
                {
                MessageBox.Show("Please fill up Name field!");
                return;
               }
            else if (String.IsNullOrEmpty(txtFather.Text))
               {
                MessageBox.Show("Please fill up Father's Name field!");
                return;
               }
            
            else if (String.IsNullOrEmpty(txtMother.Text) )
                {
                MessageBox.Show("Please fill up Mother's Name field!");
                return;
               }
            else if( String.IsNullOrEmpty(txtAddress.Text))
               {
                MessageBox.Show("Please fill up Address field!");
                return;
               }
            else if(String.IsNullOrEmpty(txtContactNo.Text))
                {
                MessageBox.Show("Please fill up Contact Number field!");
                return;
                }
            else if(txtContactNo.Text.Length!=10)
            {
                MessageBox.Show("Please enter currect Contact Number!");
                return;
            }
               else if(ddlClass.SelectedItem == null )
               {
                MessageBox.Show("Please select a Class!");
                return;
               }

               else if(ddlSection.SelectedItem == null)
              {
                MessageBox.Show("Please select a Section!");
                return;
               }       

           try
            {
                var insection = (SectionInfo)ddlSection.SelectedItem;
                StudentInfo studentInfo;
                UserCredential ucs;
                if (txtID.Text == "")
                {
                    studentInfo = new StudentInfo();
                    context.StudentInfoes.Add(studentInfo);
                    ucs = new UserCredential();
                    context2.UserCredentials.Add(ucs);    
                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    studentInfo = context.StudentInfoes.FirstOrDefault(d => d.ID == id);
                    ucs = context2.UserCredentials.FirstOrDefault(d => d.StudentID == id);
                    if (studentInfo == null || ucs == null)
                    {
                        this.Init();
                        return;
                    }
                }

                studentInfo.Name = txtName.Text;
                studentInfo.FatherName = txtFather.Text;
                studentInfo.MotherName = txtMother.Text;
                studentInfo.Address = txtAddress.Text;
                studentInfo.DateOfBirth = Convert.ToDateTime(dtDOB.Text);
                studentInfo.ContactNo = Convert.ToInt32(txtContactNo.Text);
                studentInfo.ClassInfo = insection.ClassInfo;
                studentInfo.SectionInfo = insection;
                context.SaveChanges();
                ucs.Password = txtPassword.Text;
                ucs.Username = "S-" + studentInfo.ID;
                ucs.UserTypeID = 2;
                ucs.StudentID = studentInfo.ID;
                MessageBox.Show("ID: S-" + studentInfo.ID);
                context2.SaveChanges();
                this.LoadData();
                this.LoadData(studentInfo.ID);


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
                MessageBox.Show(ex.Message+" "+ex.InnerException);
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
                var ucs = context2.UserCredentials.FirstOrDefault(d => d.StudentID == id);
                var stuInfo = context.StudentInfoes.FirstOrDefault(d => d.ID == id);
                if (stuInfo == null)
                {
                    this.Init();
                    return;
                }
                context2.UserCredentials.Remove(ucs);
                context.StudentInfoes.Remove(stuInfo);
                context2.SaveChanges();
                context.SaveChanges();
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
