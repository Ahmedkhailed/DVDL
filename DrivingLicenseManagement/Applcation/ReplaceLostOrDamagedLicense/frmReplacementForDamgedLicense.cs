using ContactsBusinessLayer;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.MangeApplicationTypes;
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
    public partial class frmReplacementForDamagedLicense : Form
    {
        private int _NewLicenseID;

        public frmReplacementForDamagedLicense()
        {
            InitializeComponent();
        }

        private void frmReplacementForDamagedLicense_Load(object sender, EventArgs e)
        {
            radioButtonDamagedLicense.Checked = true;
            lbApplcationDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lbApplcationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense).Fees.ToString("#.##");
        }

        private void radioButtonDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = "Replacement for Damaged License";
            this.Text = lbTitle.Text;
            lbApplcationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense).Fees.ToString("#.##");
        }

        private void radioButtonLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = "  Replacement for Lost License";
            this.Text = lbTitle.Text;
            lbApplcationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReplacementForALostDrivingLicense).Fees.ToString("#.##");
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(_NewLicenseID);
            LicenseHistory.ShowDialog();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLicense NewLicense = filterDriverLicenseInfo1.SelectedLicenseInfo.Replace((radioButtonDamagedLicense.Checked) ? clsLicense.enIssueReason.ReplacementForDamaged : clsLicense.enIssueReason.ReplacementForLost, clsGlobal.CurrentUser.UserID);

                if (NewLicense == null)
                {
                    MessageBox.Show("Failed to issue a replacement for this an selected license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _NewLicenseID = NewLicense.LicenseID;

                lbReplacedLicenseID.Text = NewLicense.LicenseID.ToString();
                lbRLAppplicationID.Text = NewLicense.ApplicationID.ToString();

                filterDriverLicenseInfo1.FilterEnabled = false;
                linkLabelNewShowLicenseInfo.Enabled = true;
                btnIssueReplacement.Enabled = false;
                groupBoxReplacementFor.Enabled = false;

                MessageBox.Show("License Replaced Successfully whit id=" + NewLicense.LicenseID, "License Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabelNewShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo driverInfo = new frmLicenseInfo(_NewLicenseID);
            driverInfo.ShowDialog();
        }

        private void filterDriverLicenseInfo1_LicenseIDSelected(int LicenseID)
        {
            lbOldLicenseID.Text = LicenseID.ToString();
            btnIssueReplacement.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = (LicenseID != -1);

            if (LicenseID == -1)
                return;

            if (!filterDriverLicenseInfo1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

    }
}
