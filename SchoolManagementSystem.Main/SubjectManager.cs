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
    public partial class SubjectManager : Form
    {
        SMSContext context = new SMSContext();
        public SubjectManager()
        {
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = txtName.Text = txtCode.Text = "";

            this.LoadData();
        }

        public void LoadData()
        {
            dgvSubjects.AutoGenerateColumns = false;
            var Subjects = context.SubjectInfoes.ToList();
            if (txtSearch.Text != "")
            {
                Subjects = Subjects.Where(d => d.Name.Contains(txtSearch.Text)).ToList();
            }
            dgvSubjects.DataSource = Subjects;
            dgvSubjects.Refresh();

            if (Subjects.Count > 0)
            {
                this.LoadData(Subjects.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            var Subjects = context.SubjectInfoes.FirstOrDefault(d => d.ID == id);
            if (Subjects == null)
            {
                this.New();
                return;
            }
            txtID.Text = Subjects.ID.ToString();
            txtName.Text = Subjects.Name;
            txtCode.Text = Subjects.Code.ToString();

        }

        private void New()
        {
            txtID.Text = txtName.Text = txtCode.Text="";

            dgvSubjects.ClearSelection();
        }

        private void SubjectManager_Load(object sender, EventArgs e)
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
                var Subjects = context.SubjectInfoes.FirstOrDefault(d => d.ID == id);
                if (Subjects == null)
                {
                    this.Init();
                    return;
                }
                context.SubjectInfoes.Remove(Subjects);
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
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Invalid Input");
                return;
            }
           
            try
            {
                
                SubjectInfo si;
                if (txtID.Text == "")
                {
                    si = new SubjectInfo();
                    context.SubjectInfoes.Add(si);

                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    si = context.SubjectInfoes.FirstOrDefault(d => d.ID == id);
                    if (si == null)
                    {
                        this.Init();
                        return;
                    }
                }


                si.Name = txtName.Text;
                si.Code = Convert.ToInt32(txtCode.Text);
                context.SaveChanges();
                this.LoadData();
                this.LoadData(si.ID);


                dgvSubjects.ClearSelection();
                for (int i = 0; i < dgvSubjects.Rows.Count; i++)
                {
                    string id = dgvSubjects.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvSubjects.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvSubjects.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a row first");
                return;
            }
                
            new CurriculumDetailsManager(Convert.ToInt32(txtID.Text)).ShowDialog();
        }


    }
}
