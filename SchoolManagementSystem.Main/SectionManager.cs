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
    public partial class SectionManager : Form
    {
        int ClassID = 0; 
        SMSContext context = new SMSContext();
        
        public SectionManager(int classId)
        {
            this.ClassID = classId;
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = txtTitle.Text = txtRoom.Text = "";
            dtStart.Text = dtEnd.Text = DateTime.Now.ToString();
            this.LoadData();
        }

        public void LoadData()
        {
            dgvSections.AutoGenerateColumns = false;
            var sectionInfo = context.SectionInfoes.ToList();
            if (ClassID!=0)
            {
                sectionInfo = sectionInfo.Where(d => d.ClassID == ClassID).ToList();
            }
            if (txtSearch.Text != "")
            {
                sectionInfo = sectionInfo.Where(d => d.Title.Contains(txtSearch.Text)).ToList();
            }
            dgvSections.DataSource = sectionInfo;
            dgvSections.Refresh();

            if (sectionInfo.Count > 0)
            {
                this.LoadData(sectionInfo.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            var sectionInfo = context.SectionInfoes.FirstOrDefault(d => d.ID == id);
            if (sectionInfo == null)
            {
                this.New();
                return;
            }
            txtID.Text = sectionInfo.ID.ToString();
            txtCapacity.Text = sectionInfo.Capacity.ToString();
            txtRoom.Text = sectionInfo.RoomNo;
            dtStart.Text = sectionInfo.Start;
            dtEnd.Text = sectionInfo.End;
            txtTitle.Text = sectionInfo.Title;
        }

        private void New()
        {
            txtID.Text = txtTitle.Text = txtCapacity.Text = txtRoom.Text = "";
            dtEnd.Text = dtStart.Text = DateTime.Now.ToString();
            dgvSections.ClearSelection();
        }

        private void SectionManager_Load(object sender, EventArgs e)
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
                var sectionInfo = context.SectionInfoes.FirstOrDefault(s => s.ID == id);
                if (sectionInfo == null)
                {
                    this.Init();
                    return;
                }
                context.SectionInfoes.Remove(sectionInfo);
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
            if (String.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Invalid Input");
                return;
            }
            try
            {
                SectionInfo si;
                if (txtID.Text == "")
                {
                    si = new SectionInfo();
                    context.SectionInfoes.Add(si);

                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    si = context.SectionInfoes.FirstOrDefault(d => d.ID == id);
                    if (si == null)
                    {
                        this.Init();
                        return;
                    }
                }

                si.Title = txtTitle.Text;
                si.RoomNo = txtRoom.Text;
                si.ClassID = this.ClassID;
                si.Capacity = Convert.ToInt32(txtCapacity.Text);
                si.TimeStart = Convert.ToDateTime(dtStart.Text);
                si.TimeEnd = Convert.ToDateTime(dtEnd.Text);
                context.SaveChanges();
                this.LoadData();
                this.LoadData(si.ID);


                dgvSections.ClearSelection();
                for (int i = 0; i < dgvSections.Rows.Count; i++)
                {
                    string id = dgvSections.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvSections.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+" "+ex.InnerException);
            }
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

        private void dgvSections_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvSections.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }

        private void btnRoutine_Click(object sender, EventArgs e)
        {
            try
              {
                if (txtID.Text == "")
                {
                    MessageBox.Show("Please select a row first");
                    return;
                }
                int id = Int32.Parse(txtID.Text);
                new ClassRoutineManager(id).ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvSections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
