using ContactsBusinessLayer;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.InternationalLicenses;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.MangeApplicationTypes;
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
using static System.Net.Mime.MediaTypeNames;

namespace DrivingLicenseManagement
{
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        private  int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplications _localDrivingLicenseApplications;

        public frmIssueDriverLicenseForTheFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _localDrivingLicenseApplications.IssueLicenseForFirstTime(tbNotes.Text, clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License issued Successfully With License ID = " + LicenseID, "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                this.Close();
            }
            else
                MessageBox.Show("License was not issued !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            tbNotes.Focus();
            _localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if ( _localDrivingLicenseApplications == null )
            {
                MessageBox.Show("No ApplicationID with id : " + _LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_localDrivingLicenseApplications.PassedAllTests())
            {
                MessageBox.Show("Person Should pass all test first", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _localDrivingLicenseApplications.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("Person already has License before with License ID" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            localDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
        }

    }
}
