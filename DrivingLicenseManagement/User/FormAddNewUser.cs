using ContactsBusinessLayer.Users;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormAddNewUser : Form
    {
        enum enMode { AddNew = 0, Update = 1 }
        private enMode _mode = enMode.AddNew;
        private clsUsers _User;
        private int _UserID = -1;


        public FormAddNewUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _mode = enMode.Update;
        }

        public FormAddNewUser()
        {
            InitializeComponent();
            _mode = enMode.AddNew;
        }

        private void _ResetDefaultValue()
        {
            if (_mode == enMode.AddNew)
            {
                lbTitle.Text = "Add New User";
                this.Text = "Add New User";
                tpLoginInfo.Enabled = false;
                findPeople2.FilterFocus();
            }
            else
            {
                lbTitle.Text = "Update User";
                this.Text = "Update User";
                lbUserID.Text = _UserID.ToString();
            }

            tbUserName.Text = "";
            tbPassword.Text = "";
            tbConfirmPassword.Text = "";
        }

        private void _LoadData()
        {
            findPeople2.FilterEnabled = false;
            _User = clsUsers.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            findPeople2.LoadPersonInfo(_User.PersonID);

            lbUserID.Text = _User.UserID.ToString();
            tbUserName.Text = _User.UserName.ToString();
            cbIsActive.Checked = _User.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_Validating())
            {
                MessageBox.Show("Some filed are not valid, put the mouse over the red icons\n to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_mode == enMode.AddNew)
                    _User = new clsUsers();

                _User.PersonID = findPeople2.PersonID;
                _User.UserName = tbUserName.Text.Trim();
                _User.Password = tbPassword.Text.Trim();
                _User.IsActive = cbIsActive.Checked;

                if (_User.Save())
                {
                    lbUserID.Text = _User.UserID.ToString();
                    _mode = enMode.Update;
                    lbTitle.Text = "Update User";
                    this.Text = "Update User";

                    MessageBox.Show("Data Saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error: Data Is not save Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (findPeople2.PersonID != -1)
            {
                if ((!clsUsers.IsUserExistForPersonID(_UserID) || _mode == enMode.Update))
                {
                    tabControl1.SelectedTab = tpLoginInfo;
                }
                else
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    findPeople2.FilterFocus();
                }
            }
            else
            {
                MessageBox.Show("Please select a person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                findPeople2.FilterFocus();
            }
        }
        
        private bool _Validating()
        {
            bool isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(tbUserName.Text))
            { errorProvider1.SetError(tbUserName, "This field is required"); isValid = false; }

            if (string.IsNullOrEmpty(tbPassword.Text))
            { errorProvider1.SetError(tbPassword, "This field is required"); isValid = false; }

            if (string.IsNullOrEmpty(tbConfirmPassword.Text))
            { errorProvider1.SetError(tbConfirmPassword, "This field is required"); isValid = false; }

            if (tbConfirmPassword.Text != tbPassword.Text)
            { errorProvider1.SetError(tbConfirmPassword, "The password is different"); isValid = false; }

            return isValid;
        }

        private void findPeople2_BackData(int PersonId)
        {
            _User = clsUsers.FindByPersonID(PersonId);
            btnNext.Enabled = true;
            if (!clsUsers.IsUserExistForPersonID(PersonId) || _mode == enMode.Update)
            {
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                tpLoginInfo.Enabled = false;
                _UserID = _User.UserID;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void FormAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (_mode == enMode.Update)
                _LoadData();
        }
    }
}
