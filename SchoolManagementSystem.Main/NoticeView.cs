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
    public partial class NoticeView : Form
    {
        SMSContext context = new SMSContext();
        public NoticeView()
        {
            InitializeComponent();
        }

        public void Init()
        {
            this.LoadData();
        }

        public void LoadData()
        {
            var si = Globals.CUR_USER.StudentInfo.SectionInfo.ID;
            dgvNotices.AutoGenerateColumns = false;
            var notices = context.NoticeInfoes.Where(x=>x.SectionID == si).ToList();
            dgvNotices.DataSource = notices;
            dgvNotices.Refresh();

            if (notices.Count > 0)
            {
                this.LoadData(notices.First().ID);
            }
            dgvNotices.ClearSelection();
        }

        private void LoadData(int id)
        {
            var not = context.NoticeInfoes.FirstOrDefault(x => x.ID == id);
            MessageBox.Show("@" + (not.UserCredential.TeacherInfo == null ? not.UserCredential.Username : not.UserCredential.TeacherInfo.Name) + ": "+ not.Text, not.Title);
        }

        private void NoticeView_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void dgvNotices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvNotices.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.LoadData(Int32.Parse(id));
            }
        }

        private void dgvNotices_Paint(object sender, PaintEventArgs e)
        {
            dgvNotices.ClearSelection();
        }
    }
}
