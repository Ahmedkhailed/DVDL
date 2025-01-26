using ContactsBusinessLayer;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.InternationalLicenses;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsBusinessLayer.Users;
using DrivingLicenseManagement.Golbal_Classes;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private clsLicense _NewLicense;

        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            filterDriverLicenseInfo1.FocusFilter();

            lbApplcationDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbApplcationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString("#.##");
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;

        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLicense NewLicense = filterDriverLicenseInfo1.SelectedLicenseInfo.RenewLicense(tbNotes.Text, clsGlobal.CurrentUser.UserID);

                if (NewLicense == null)
                {
                    MessageBox.Show("Failed to renew the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _NewLicense = NewLicense;

                lbRLAppplicationID.Text = NewLicense.ApplicationID.ToString();
                lbRenewedLicenseID.Text = NewLicense.LicenseID.ToString();

                btnRenew.Enabled = false;
                filterDriverLicenseInfo1.FilterEnabled = false;
                linkLabelNewShowLicenseInfo.Enabled = true;

                MessageBox.Show("Licensed renewed successfully with ID = " + NewLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e) => this.Close();

        private void linkLabelNewShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo driverInfo = new frmLicenseInfo(_NewLicense.LicenseID);
            driverInfo.ShowDialog();
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseInfo = new frmLicenseHistory(filterDriverLicenseInfo1.LicenseID);
            licenseInfo.ShowDialog();
        }

        private void filterDriverLicenseInfo1_LicenseIDSelected(int LicenseID)
        {
            btnRenew.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = (LicenseID != -1);

            if (LicenseID == -1)
                return;

            clsLicense licensesInfo = clsLicense.Find(LicenseID);

            lbOldLicenseID.Text = LicenseID.ToString();
            lbExpirationDate.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.ExpirationDate.ToShortDateString();
            lbLicenseFees.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.PaidFees.ToString("#.##");
            lbTotalFees.Text = (filterDriverLicenseInfo1.SelectedLicenseInfo.PaidFees + Convert.ToDecimal(lbApplcationFees.Text)).ToString("#.##");
            tbNotes.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.Notes;
            lbApplcationDate.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.ApplicationInfo.ApplicationDate.ToShortDateString();
            lbIssueDate.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.IssueDate.ToShortDateString();
              
            if (!filterDriverLicenseInfo1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not active, Choose an active license", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (filterDriverLicenseInfo1.SelectedLicenseInfo.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("Selected License is not yet expired, it will expire on : " + licensesInfo.ExpirationDate.ToString("dd/MMM/yyyy", CultureInfo.CreateSpecificCulture("en-US")), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRenew.Enabled = true;
        }
    
    }
}

