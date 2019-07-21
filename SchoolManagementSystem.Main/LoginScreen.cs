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
    public partial class LoginScreen : Form
    {
        SMSContext context = new SMSContext();
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaxMin.Text="-";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaxMin.Text = "+";
            }
                
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var uc = context.UserCredentials.FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);
                if (uc == null)
                {
                    MessageBox.Show("Please enter correct Username or Password", "Invalid Input");
                    return;
                }
                Globals.CUR_USER = uc;
                this.Hide();
                new Dashboard().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "Exception");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin.PerformClick();
        }

    }
}
