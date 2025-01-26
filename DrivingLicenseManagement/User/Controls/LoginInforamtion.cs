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
    public partial class LoginInformation : UserControl
    {
        public LoginInformation()
        {
            InitializeComponent();
        }

        public void FillData(clsUsers User)
        {
            lbUserID.Text = User.UserID.ToString();
            lbUserName.Text = User.UserName.ToString();

            if (User.IsActive)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";
        }
    
        public void ResetInfo()
        {
            lbIsActive.Text = "[???]";
            lbUserID.Text = "[???]";
            lbUserID.Text = "[???]";
        }
    }
}
