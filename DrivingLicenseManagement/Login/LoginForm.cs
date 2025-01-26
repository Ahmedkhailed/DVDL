using ContactsBusinessLayer.Users;
using DrivingLicenseManagement.Golbal_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            clsUsers User = clsUsers.FindByUserNameAndPassword(tbUserName.Text.ToString(), tbPassword.Text.ToString());

            if (User != null)
            {
                if (User.IsActive)
                {

                    if (checkBox1.Checked)
                    {

                        clsGlobal.RememberUserNameAndPassword(tbUserName.Text.ToString(), tbPassword.Text.ToString());
                    }
                    else
                    {
                        clsGlobal.RememberUserNameAndPassword("", "");
                    }

                    clsGlobal.CurrentUser = User;
                    Form1 frm = new Form1(this);
                    frm.ShowDialog();
                }
                else
                {
                    tbUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid UserName/Password.", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPassword.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbUserName.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tbPassword.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                tbPassword.Text = Password;
                tbUserName.Text = UserName;
                checkBox1.Checked = true;
            }
            else
                checkBox1.Checked = false;
        }
    }
}
