using ContactsBusinessLayer;
using ContactsBusinessLayer.Detain;
using ContactsBusinessLayer.MangeApplicationTypes;
using DrivingLicenseManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class DriverLicenseInfo : UserControl
    {
        private int _licenseID;
        private clsLicense _License;

        public int LicenseID
        {
            get
            {
                return _licenseID;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return _License;
            }
        }

        public DriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gender == 0)
                pictureBoxPerson.Image = Resources.user__4_;
            else
                pictureBoxPerson.Image = Resources.woman__2_;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pictureBoxPerson.Load(ImagePath);
                else
                    MessageBox.Show("Cloud not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadData(int LicenseID)
        {
            _licenseID = LicenseID;
            _License = clsLicense.Find(LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find license id : " + LicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _licenseID = -1;
                return;
            }

            lbClass.Text = _License.LicenseClassInfo.ClassName;
            lbName.Text = _License.DriverInfo.PersonInfo.FullName;
            lbLicenseID.Text = _License.LicenseID.ToString();
            lbNationalNo.Text = _License.ApplicationInfo.PersonInfo.NationalNo;
            lbGender.Text = _License.ApplicationInfo.PersonInfo.Gender == 0 ? "Male" : "Femail";
            lbIssueDate.Text = _License.IssueDate.ToShortDateString();
            lbIssueReason.Text = _License.IssueReasonText;
            lbNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lbIsActive.Text = (_License.IsActive) ? "Yes" : "NO";
            lbDateOfBirth.Text = _License.ApplicationInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lbDriverID.Text = _License.DriverID.ToString();
            lbExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lbIsDetained.Text = _License.IsDetain ? "yes" : "No";
            _LoadPersonImage();
        }

    }
}
