using ContactsBusinessLayer;
using ContactsBusinessLayer.InternationalLicenses;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsBusinessLayer.Users;
using DrivingLicenseManagement.Golbal_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private int _InternationalID = -1;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to issue the License?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsInternationalLicenses internationalLicenses = new clsInternationalLicenses();
                internationalLicenses.ApplicationPersonID = filterDriverLicenseInfo1.SelectedLicenseInfo.DriverInfo.PersonID;
                internationalLicenses.ApplicationDate = DateTime.Now;
                internationalLicenses.ApplicationType = clsApplication.enApplicationType.NewInternationalLicense;
                internationalLicenses.Status = clsApplication.enApplicationStatus.Completed;
                internationalLicenses.LastStatusDate = DateTime.Now;
                internationalLicenses.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
                internationalLicenses.ApplicationID = filterDriverLicenseInfo1.SelectedLicenseInfo.ApplicationID;
                internationalLicenses.DriverID = filterDriverLicenseInfo1.SelectedLicenseInfo.DriverID;
                internationalLicenses.IssuedUsingLocalLicenseID = filterDriverLicenseInfo1.SelectedLicenseInfo.LicenseID;
                internationalLicenses.IssueDate = filterDriverLicenseInfo1.SelectedLicenseInfo.IssueDate;
                internationalLicenses.ExpirationDate = DateTime.Now.AddYears(1);
                internationalLicenses.IsActive = filterDriverLicenseInfo1.SelectedLicenseInfo.IsActive;
                internationalLicenses.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                
                if (internationalLicenses.Save())
                {
                    _InternationalID = internationalLicenses.InternationalLicenseID;
                    btnIssue.Enabled = false;
                    filterDriverLicenseInfo1.FilterEnabled = false;
                    linkLabelShowLicenseInfo.Enabled = true;
                    lbILApplicationID.Text = internationalLicenses.ApplicationID.ToString();
                    lbILLicenseID.Text = internationalLicenses.InternationalLicenseID.ToString();
                    lbApplicationDate.Text = internationalLicenses.ApplicationDate.ToShortDateString();
                    lbIssueDate.Text = internationalLicenses.IssueDate.ToShortDateString();
                    lbExprationDate.Text = internationalLicenses.ExpirationDate.ToShortDateString();
                    MessageBox.Show("international License issued Successfully with id = " + internationalLicenses.InternationalLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseInfo = new frmLicenseHistory(filterDriverLicenseInfo1.SelectedLicenseInfo.DriverInfo.PersonID);
            licenseInfo.ShowDialog();
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalDriverInfo driverInfo = new frmInternationalDriverInfo(_InternationalID);
            driverInfo.ShowDialog();
        }
      
        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lbApplicationDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lbExprationDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            filterDriverLicenseInfo1.FocusFilter();
        }

        private void filterDriverLicenseInfo1_LicenseIDSelected(int LicenseID)
        {
            lbLocalLicenseID.Text = LicenseID.ToString();
            linkLabelShowLicenseHistory.Enabled = (LicenseID != -1);
            linkLabelShowLicenseInfo.Enabled = false;
            btnIssue.Enabled = false;

            if (LicenseID == -1)
                return;

            if (filterDriverLicenseInfo1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be class be class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveInternationalLicenseID = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(filterDriverLicenseInfo1.SelectedLicenseInfo.DriverID);

            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("Person already has an active international license with " + ActiveInternationalLicenseID , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error );
                lbILLicenseID.Text = ActiveInternationalLicenseID.ToString();
                _InternationalID = ActiveInternationalLicenseID;
                linkLabelShowLicenseInfo.Enabled = true;
                return;
            }

            if (!filterDriverLicenseInfo1.SelectedLicenseInfo.IsActive || filterDriverLicenseInfo1.SelectedLicenseInfo.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("This license is not active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssue.Enabled = true;
        }
    
    }
}
