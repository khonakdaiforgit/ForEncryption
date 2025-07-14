using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureFileEncryptor
{
    public partial class frmSetPassword : Form
    {
        public frmSetPassword()
        {
            InitializeComponent();
        }

        private void btnShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            frmMain.Password = txtPassword.Text;
            this.Close();
        }
    }
}
