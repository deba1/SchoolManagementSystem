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
    public partial class ClassManager : Form
    {
        SMSContext context = new SMSContext();
        public ClassManager()
        {
            InitializeComponent();
        }

        public void Init()
        {
            txtID.Text = txtTitle.Text = txtYear.Text = "";
            this.LoadData();
        }

        public void LoadData()
        {
            dgvClasses.AutoGenerateColumns = false;
            var classInfo = context.ClassInfoes.ToList();
            if (txtSearch.Text != "")
            {
                classInfo = classInfo.Where(d => d.Title.Contains(txtSearch.Text)).ToList();
            }
            dgvClasses.DataSource = classInfo;
            dgvClasses.Refresh();

            if (classInfo.Count > 0)
            {
                this.LoadData(classInfo.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            var classInfo = context.ClassInfoes.FirstOrDefault(d => d.ID == id);
            if (classInfo == null)
            {
                this.New();
                return;
            }
            txtID.Text = classInfo.ID.ToString();
            txtYear.Text = classInfo.Year.ToString();
            txtTitle.Text = classInfo.Title;
        }

        private void New()
        {
            txtID.Text = txtTitle.Text = txtYear.Text = "";
            dgvClasses.ClearSelection();
        }
        
        private void ClassManager_Load(object sender, EventArgs e)
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
                var classInfo = context.ClassInfoes.FirstOrDefault(d => d.ID == id);
                if (classInfo == null)
                {
                    this.Init();
                    return;
                }
                context.ClassInfoes.Remove(classInfo);
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
            if (String.IsNullOrEmpty(txtTitle.Text) || String.IsNullOrEmpty(txtYear.Text))
            {
                MessageBox.Show("Invalid Input");
                return;
            }
            try
            {
                ClassInfo cls;
                if (txtID.Text == "")
                {
                    cls = new ClassInfo();
                    context.ClassInfoes.Add(cls);

                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    cls = context.ClassInfoes.FirstOrDefault(d => d.ID == id);
                    if (cls == null)
                    {
                        this.Init();
                        return;
                    }
                }

                cls.Title = txtTitle.Text;
                cls.Year = Convert.ToInt32(txtYear.Text);
                context.SaveChanges();
                this.LoadData();
                this.LoadData(cls.ID);


                dgvClasses.ClearSelection();
                for (int i = 0; i < dgvClasses.Rows.Count; i++)
                {
                    string id = dgvClasses.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvClasses.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException);
            }
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvClasses.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a row first");
                return;
            }
            new SectionManager(Convert.ToInt32(txtID.Text)).ShowDialog();
        }

        private void btnCurriculum_Click(object sender, EventArgs e)
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
