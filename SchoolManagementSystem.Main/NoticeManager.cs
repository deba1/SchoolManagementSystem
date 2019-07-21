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
    public partial class NoticeManager : Form
    {
        SMSContext context = new SMSContext();
        public NoticeManager()
        {
            InitializeComponent();
        }

        public void Init()
        {
            var tid = Globals.CUR_USER.TeacherID;
            txtID.Text = txtTitle.Text = "";
            var teacher = context.TeacherInfoes.FirstOrDefault(x => x.ID == tid);
            ddlSection.DataSource = teacher.ClassRoutines.Select(x => x.SectionInfo).Distinct().ToList();
            ddlSection.DisplayMember = "Signature";
            ddlSection.SelectedItem = null;
            this.LoadData();
        }

        public void LoadData()
        {
            dgvNotices.AutoGenerateColumns = false;
            var notices = context.NoticeInfoes.ToList();
            dgvNotices.DataSource = notices;
            dgvNotices.Refresh();

            if (notices.Count > 0)
            {
                this.LoadData(notices.First().ID);
            }
            else
            {
                this.New();
            }
        }

        private void LoadData(int id)
        {
            var notices = context.NoticeInfoes.FirstOrDefault(d => d.ID == id);
            if (notices == null)
            {
                this.New();
                return;
            }
            ddlSection.SelectedItem = notices.SectionInfo;
            txtID.Text = notices.ID.ToString();
            txtTitle.Text = notices.Title;
            rtxtBody.Text = notices.Text;
        }

        private void New()
        {
            txtID.Text = txtTitle.Text = rtxtBody.Text = "";
            ddlSection.SelectedItem = null;
            dgvNotices.ClearSelection();
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
                var notice = context.NoticeInfoes.FirstOrDefault(d => d.ID == id);
                if (notice == null)
                {
                    this.Init();
                    return;
                }
                context.NoticeInfoes.Remove(notice);
                context.SaveChanges();
                this.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void NoticeManager_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTitle.Text) || String.IsNullOrEmpty(rtxtBody.Text) || ddlSection.SelectedItem == null)
            {
                MessageBox.Show("Invalid Input");
                return;
            }
            try
            {
                NoticeInfo notice;
                if (txtID.Text == "")
                {
                    notice = new NoticeInfo();
                    context.NoticeInfoes.Add(notice);

                }
                else
                {
                    int id = Int32.Parse(txtID.Text);
                    notice = context.NoticeInfoes.FirstOrDefault(d => d.ID == id);
                    if (notice == null)
                    {
                        this.Init();
                        return;
                    }
                }
                var sec = (SectionInfo)ddlSection.SelectedItem;
                notice.Title = txtTitle.Text;
                notice.SectionID = sec.ID;
                notice.Text = rtxtBody.Text;
                notice.OwnerID = Globals.CUR_USER.ID;
                context.SaveChanges();
                this.LoadData();
                this.LoadData(notice.ID);


                dgvNotices.ClearSelection();
                for (int i = 0; i < dgvNotices.Rows.Count; i++)
                {
                    string id = dgvNotices.Rows[i].Cells[0].Value.ToString();
                    if (id == txtID.Text)
                    {
                        dgvNotices.Rows[i].Selected = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException);
            }
        }

        private void dgvNotices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvNotices.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }
    }
}
