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
    public partial class UserInfo : UserControl
    {

        private clsUsers _User;
        private int _UserID = -1;

        public clsUsers User
        {
            get
            {
                return _User;
            }
        }

        public UserInfo()
        {
            InitializeComponent();
        }

        public void LoadData(int UserID)
        {
            _UserID = UserID;
            _User = clsUsers.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            if (_User != null)
            {
                show2.LoadPersonInfo(User.PersonID);
                loginInformation2.FillData(_User);
            }
        }

        private void _ResetPersonInfo()
        {
            show2.ResetPersonInfo();
            loginInformation2.ResetInfo();
        }
            
    }
}
