using ContactsBusinessLayer;
using ContactsBusinessLayer.Detain;
using ContactsBusinessLayer.Drivers;
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
    public partial class frmReleaseDetainLicense : Form
    {
        private int _SelectedLicenseID = -1;

        public frmReleaseDetainLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainLicense(int LicenseID)
        {
            InitializeComponent();

            _SelectedLicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(filterDriverLicenseInfo1.SelectedLicenseInfo.DriverInfo.PersonID);
            licenseHistory.ShowDialog();
        }

        private void linkLabelNewShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo licenseInfo = new frmLicenseInfo(filterDriverLicenseInfo1.LicenseID);
            licenseInfo.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (filterDriverLicenseInfo1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID))
                {
                    MessageBox.Show("Detained License released Successfully", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lbReleaseApplicationID.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.DetainInfo.ReleaseApplicationID.ToString();
                    btnRelease.Enabled = false;
                    linkLabelNewShowLicenseInfo.Enabled = true;
                    filterDriverLicenseInfo1.FilterEnabled = false;
                }
                else
                {
                    MessageBox.Show("Failed to release the detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                }
            }
            
        }

        private void filterDriverLicenseInfo1_LicenseIDSelected(int LicenseID)
        {
            linkLabelShowLicenseHistory.Enabled = (LicenseID != -1);

            if (LicenseID == -1) 
                return;

            if (!filterDriverLicenseInfo1.SelectedLicenseInfo.IsDetain)
            {
                btnRelease.Enabled = false;

                MessageBox.Show("Selected License is not detain, choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbDetainID.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.DetainInfo.DetainID.ToString();
            lbLicenseID.Text = LicenseID.ToString();
            lbDetainDate.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.DetainInfo.DetainDate.ToShortDateString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lbApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).Fees.ToString();
            lbFineFees.Text = filterDriverLicenseInfo1.SelectedLicenseInfo.DetainInfo.FineFees.ToString();
            lbTotalFees.Text = (Convert.ToDecimal(lbApplicationFees.Text) + Convert.ToDecimal(lbFineFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void frmReleaseDetainLicense_Load(object sender, EventArgs e)
        {
            if (_SelectedLicenseID != -1)
            {
                filterDriverLicenseInfo1.LoadData(_SelectedLicenseID);
                filterDriverLicenseInfo1.FilterEnabled = false;
            }
            else
                filterDriverLicenseInfo1.FocusFilter();
        }
    }
}
