using ContactsBusinessLayer;
using DrivingLicenseManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson Person
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void ResetPersonInfo()
        {
            linkLabelEditPersonInfo.Enabled = false;
            lbPersonID.Text = "[????]";
            lbName.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbGendor.Text = "[????]";
            lbEmail.Text = "[????]";
            lbAddress.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbPhone.Text = "[????]";
            lbCountry.Text = "[????]";

            pbGendor.Image = Resources.user__4_;
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person With ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person With NationalNo = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            linkLabelEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lbPersonID.Text = _PersonID.ToString();
            lbName.Text = (_Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName);
            lbNationalNo.Text = _Person.NationalNo.ToString();
            lbGendor.Text = _Person.Gender == 0 ? "Male" : "Female";
            lbEmail.Text = _Person.Email;
            lbAddress.Text = _Person.Address;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lbPhone.Text = _Person.Phone;
            lbCountry.Text = _Person.CountryInfo.CountryName;
            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            string ImagePath = _Person.ImagePath;
            if (ImagePath == "")
            {
                if (_Person.Gender == 0)
                    pbPerson.Image = Resources.user__4_;
                else
                    pbPerson.Image = Resources.woman__2_;
            }
            else
            {
                if (File.Exists(ImagePath))
                    pbPerson.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frmEditPerson = new frmAddEditPerson(_PersonID);
            frmEditPerson.ShowDialog();

            LoadPersonInfo(_PersonID);
        }

    }
}
