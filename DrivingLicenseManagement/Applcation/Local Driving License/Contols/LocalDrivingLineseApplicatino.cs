using ContactsBusinessLayer;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DrivingLicenseManagement
{
    public partial class LocalDrivingLicenseApplication : UserControl
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _LicenseID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get
            {
                return _LocalDrivingLicenseApplicationID;
            }
        }

        public LocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfoByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                _RestLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with applicationId  = " + LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplication(int Application)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByApplicationID(Application);

            if (_LocalDrivingLicenseApplication == null)
            {
                _RestLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with applicationId  = " + Application, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            linkLabelShowLicenseInfo.Enabled = (_LicenseID != -1);

            lbID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbAppliedForLicense.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lbPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            applicationBasicInfo1.LoadApplicationInfo(LocalDrivingLicenseApplicationID);
        }

        private void _RestLocalDrivingLicenseApplicationInfo()
        {
            lbID.Text = "[???]";
            lbAppliedForLicense.Text = "[???]";
            lbPassedTests.Text = "[???]";
            applicationBasicInfo1.RestApplicationInfo();
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo licenseInfo = new frmLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            licenseInfo.ShowDialog();
        }
    }
}
