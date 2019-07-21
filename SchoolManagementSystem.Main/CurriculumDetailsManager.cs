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
    public partial class CurriculumDetailsManager : Form
    {
        int cur = 0;
        SMSContext context = new SMSContext();
        public CurriculumDetailsManager(int cur)
        {
            this.cur = cur;
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = "";
            ddlSubject.DataSource = context.SubjectInfoes.ToList();
            ddlSubject.DisplayMember = "Name";
            ddlSubject.SelectedItem = null;
            this.LoadData();
        }

        public void LoadData()
        {
            dgvCurriculum.AutoGenerateColumns = false;
            var curriculum = context.CurriculumDetails.ToList();
            if (cur != 0)
            {
                curriculum = curriculum.Where(d => d.ClassID == cur).ToList();
            }
            dgvCurriculum.DataSource = curriculum;
            dgvCurriculum.Refresh();

            if (curriculum.Count > 0)
            {
                this.LoadData(curriculum.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            var curriculum = context.CurriculumDetails.FirstOrDefault(d => d.ID == id);
            if (curriculum == null)
            {
                this.New();
                return;
            }
            txtID.Text = curriculum.ID.ToString();
            ddlSubject.SelectedItem = curriculum.SubjectInfo;
            
        }

        private void New()
        {
            txtID.Text = "";
            ddlSubject.SelectedItem = null;
            dgvCurriculum.ClearSelection();
        }

        private void CurriculumDManager_Load(object sender, EventArgs e)
        {
            this.Text = "Curriculum Subjects "+cur;
            this.Init();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Init();
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
                var curriculum = context.CurriculumDetails.FirstOrDefault(d => d.ID == id);
                if (curriculum == null)
                {
                    this.Init();
                    return;
                }
                context.CurriculumDetails.Remove(curriculum);
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
                CurriculumDetail cud;
                if (txtID.Text == "")
                {
                    cud = new CurriculumDetail();
                    context.CurriculumDetails.Add(cud);

                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    cud = context.CurriculumDetails.FirstOrDefault(d => d.ID == id);
                    if (cud == null)
                    {
                        this.Init();
                        return;
                    }
                }

                cud.SubjectInfo = (SubjectInfo) ddlSubject.SelectedItem;
                cud.ClassID = cur;
                context.SaveChanges();
                this.LoadData();
                this.LoadData(cud.ID);


                dgvCurriculum.ClearSelection();
                for (int i = 0; i < dgvCurriculum.Rows.Count; i++)
                {
                    string id = dgvCurriculum.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvCurriculum.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException);
            }
        }

        private void dgvCurriculum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvCurriculum.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }
    }
}
