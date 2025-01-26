using ContactsBusinessLayer.Local_Driving_License_Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement.Licenses.Local_Licenses.Controls
{
    public partial class ApplicationBasicInfo : UserControl
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;

        public ApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            lbIDApplication.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lbStatus.Text = _LocalDrivingLicenseApplication.Status.ToString();
            lbFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString("#.##");
            lbType.Text = _LocalDrivingLicenseApplication.ApplicationType.ToString();
            lbAppliction.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lbDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lbStatusDate.Text = _LocalDrivingLicenseApplication.LastStatusDate.ToShortDateString();
            lbCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;
        }

        public void RestApplicationInfo()
        {
            lbIDApplication.Text = "[???]";
            lbStatus.Text = "[???]";
            lbFees.Text = "[???]";
            lbType.Text = "[???]";
            lbAppliction.Text = "[???]";
            lbDate.Text = "[???]";
            lbStatusDate.Text = "[???]";
            lbCreatedBy.Text = "[???]";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails personDetails = new frmPersonDetails(_LocalDrivingLicenseApplication.ApplicationPersonID);
            personDetails.ShowDialog();
        }
    }
}
