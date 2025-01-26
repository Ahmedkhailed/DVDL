using ContactsBusinessLayer.InternationalLicenses;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class DriverLicenseInternationalInfo : UserControl
    {
        private clsInternationalLicenses _InternationalLicense;
        public DriverLicenseInternationalInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gender == 0)
                pictureBoxPerson.Image = Resources.user__4_;
            else
                pictureBoxPerson.Image = Resources.woman__2_;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBoxPerson.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void FillData(int InternationalID)
        {
            _InternationalLicense = clsInternationalLicenses.Find(InternationalID);

            if (_InternationalLicense != null)
            {
                lbName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
                lbLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString("#.##");
                lbNationalNo.Text = _InternationalLicense.DriverInfo.    PersonInfo.NationalNo;
                lbGender.Text = _InternationalLicense.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
                lbIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
                lbIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "NO";
                lbDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
                lbDriverID.Text = _InternationalLicense.DriverID.ToString();
                lbExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
                _LoadPersonImage();
            }

        }
    }
}
