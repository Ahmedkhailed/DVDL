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
using System.Security.Cryptography;

namespace DrivingLicenseManagement
{
    public partial class frmChangePassword : Form
    {
        private clsUsers _User;
        private int _UserID = -1;

        public frmChangePassword(int UserId)
        {
            InitializeComponent();
            _UserID = UserId;
        }

        private void _ResetDefaultValues()
        {
            tbCurrentPassword.Select();
            tbConfirmPassword.Text = string.Empty;
            tbCurrentPassword.Text = string.Empty;
            tbNewPassword.Text = string.Empty;
            
            _User = clsUsers.FindByUserID(_UserID);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_User == null )
            {
                MessageBox.Show("Could not found user with id = " + _UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            userInfo1.LoadData(_UserID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_User.ChangePassword(tbCurrentPassword.Text.ToString(), tbNewPassword.Text.ToString()))
            {
                MessageBox.Show("Password Changed Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefaultValues();
            }
            else
                MessageBox.Show("An Error Occurred, Password did not change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPassword.Text))
            {
                errorProvider1.SetError(tbNewPassword, "New Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, null);
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfirmPassword.Text != tbNewPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }
        }

        static private string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes);
            }
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Username cannot be blank");
            }
            else if (_User.Password != ComputeHash(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Current cannot be blank");
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, null);
            }
        }

    }
}
