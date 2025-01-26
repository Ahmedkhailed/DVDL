using ContactsBusinessLayer;
using ContactsBusinessLayer.Detain;
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
    public partial class frmDetainLicense : Form
    {
        private int _DetainID = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to detain this license", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(tbFineFees.Text))
                {
                    _DetainID = filterDriverLicenseInfo1.SelectedLicenseInfo.Detain(Convert.ToDecimal(tbFineFees.Text), clsGlobal.CurrentUser.UserID);
                    if (_DetainID != -1)
                    {
                        lbDetainID.Text = _DetainID.ToString();

                        btnDetain.Enabled = false;
                        tbFineFees.Enabled = false;
                        linkLabelNewShowLicenseInfo.Enabled = true;
                        filterDriverLicenseInfo1.FilterEnabled = false;
                        btnDetain.Enabled = false;
                        MessageBox.Show("License Detained Successfully With ID = " + _DetainID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter the value of the fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(filterDriverLicenseInfo1.SelectedLicenseInfo.DriverInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void linkLabelNewShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo driverInfo = new frmLicenseInfo(filterDriverLicenseInfo1.LicenseID);
            driverInfo.ShowDialog();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lbDetainDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            filterDriverLicenseInfo1.FocusFilter();
        }

        private void filterDriverLicenseInfo1_LicenseIDSelected(int LicenseID)
        {
            linkLabelShowLicenseHistory.Enabled = (LicenseID != -1);

            if (LicenseID == -1)
                return;

            if (filterDriverLicenseInfo1.SelectedLicenseInfo.IsDetain)
            {
                btnDetain.Enabled = false;

                MessageBox.Show("Selected License is already Detain, choose another one.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbLicenseID.Text = LicenseID.ToString();
            tbFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void tbFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFineFees, "Fees cannot be empty?");
            }
            else if (!clsValidation.IsNumber(tbFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFineFees, "Invalid Number");
            }
            else
                errorProvider1.SetError(tbFineFees, null);
        }
   
    }
}
