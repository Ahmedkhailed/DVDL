using ContactsBusinessLayer;
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
    public partial class FilterDriverLicenseInfo : UserControl
    {
        public delegate void LicenseIDSelectedEventHandler(int LicenseID);
        public event LicenseIDSelectedEventHandler LicenseIDSelected;

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                groupBox1.Enabled = value;
            }
        }

        private int _licenseID = -1;
        public int LicenseID
        {
            get { return driverLicenseInfo2.LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return driverLicenseInfo2.SelectedLicenseInfo; }
        }

        public FilterDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadData(int LicenseID)
        {
            tbFindBy.Text = LicenseID.ToString();
            driverLicenseInfo2.LoadData(LicenseID);
            _licenseID = driverLicenseInfo2.LicenseID;

            if (driverLicenseInfo2.SelectedLicenseInfo != null)
                LicenseIDSelected?.Invoke(driverLicenseInfo2.SelectedLicenseInfo.LicenseID);
            else
                LicenseIDSelected?.Invoke(-1);
        }

        public void FocusFilter() => tbFindBy.Focus();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFindBy.Focus();
                return;
            }
            _licenseID = int.Parse(tbFindBy.Text);
            LoadData(_licenseID);
        }
        
        private void tbFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();
        }

        private void tbFindBy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFindBy.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFindBy, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFindBy, null);
            }
        }

    }
}
