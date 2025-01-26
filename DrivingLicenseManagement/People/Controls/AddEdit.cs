using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Runtime.CompilerServices;
using DrivingLicenseManagement.Golbal_Classes;
using System.Resources;
using DrivingLicenseManagement.Properties;

namespace DrivingLicenseManagement
{
    public partial class AddEdit : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public int PersonID { get; set; }
        public clsPerson Person;

        public AddEdit()
        {
            InitializeComponent();
        }

        private bool _HandlePersonImage()
        {
            if (Person.ImagePath == pbPerson.ImageLocation)
            {
                if (Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(Person.ImagePath);
                    }
                    catch(IOException)
                    {

                    }

                }

                if (pbPerson.ImageLocation != null)
                {
                    string SourceImageFile = pbPerson.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPerson.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void AddEdit_Load(object sender, EventArgs e)
        {
            DateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            if (PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LoadData();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPerson.ImageLocation == null)
                pbPerson.Image = Resources.user__4_;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPerson.ImageLocation == null)
                pbPerson.Image = Resources.woman__2_;
        }

        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                pbPerson.Load(FilePath);
                linkLabelRemove.Visible = true;
            }
        }

        private void _LoadData()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                Person = new clsPerson();
                comboBoxCountry.SelectedIndex = comboBoxCountry.FindString("Egypt");
                return;
            }

            Person = clsPerson.Find(PersonID);

            if (Person != null)
            {
                tbNationalNo.Text = Person.NationalNo;
                tbFirstName.Text = Person.FirstName;
                tbSecond.Text = Person.SecondName;
                tbThird.Text = Person.ThirdName;
                tbLast.Text = Person.LastName;
                DateOfBirth.Value = Person.DateOfBirth;

                if (Person.Gender == 0)
                    tbMale.Checked = true;
                else
                    rbFemale.Checked = true;

                tbAddress.Text = Person.Address;
                tbPhone.Text = Person.Phone;
                tbEmail.Text = Person.Email;
                comboBoxCountry.SelectedValue = Person.NationalityCountryID;

                if (Person.ImagePath != "")
                {
                    pbPerson.Load(Person.ImagePath);
                    linkLabelRemove.Visible = true;
                }
                else
                {
                    if (tbMale.Checked)
                        pbPerson.Image = Resources.user__4_;
                    else
                        pbPerson.Image = Resources.woman__2_;
                }
            }
        }

        private bool _error()
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(tbFirstName.Text))
            { errorProvider1.SetError(tbFirstName, "First Name"); return false; }

            if (string.IsNullOrEmpty(tbLast.Text))
            { errorProvider1.SetError(tbLast, "Last"); return false; }

            if (string.IsNullOrEmpty(tbSecond.Text))
            { errorProvider1.SetError(tbSecond, "Second"); return false; }

            if (!clsValidation.ValidateEmail(tbEmail.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            { errorProvider1.SetError(tbEmail, "Validated Email Address format");  return false; }

            if (clsPerson.IsPersonExists(tbNationalNo.Text) && _Mode == enMode.AddNew)
            { errorProvider1.SetError(tbNationalNo, "National Number is used for another person"); return false; }

            if (string.IsNullOrEmpty(tbNationalNo.Text))
            { errorProvider1.SetError(tbNationalNo, "National No"); return false; }

            if (string.IsNullOrEmpty(tbPhone.Text))
            { errorProvider1.SetError(tbPhone, "Phone"); return false; }

            return true;
        }

        public int SaveData()
        {
            if (!_HandlePersonImage() || _error())
            {
                Person.NationalNo = tbNationalNo.Text.Trim();
                Person.FirstName = tbFirstName.Text.Trim();
                Person.SecondName = tbSecond.Text.Trim();
                Person.ThirdName = tbThird.Text.Trim();
                Person.LastName = tbLast.Text.Trim();
                Person.DateOfBirth = DateOfBirth.Value;

                if (tbMale.Checked)
                    Person.Gender = 0;
                else
                    Person.Gender = 1;

                Person.Address = tbAddress.Text.Trim();
                Person.Phone = tbPhone.Text.Trim();

                if (!string.IsNullOrEmpty(tbEmail.Text))
                    Person.Email = tbEmail.Text;
                else
                    Person.Email = "";

                Person.NationalityCountryID = (int)comboBoxCountry.SelectedValue;

                if (pbPerson.ImageLocation != null)
                    Person.ImagePath = pbPerson.ImageLocation.ToString();
                else
                    Person.ImagePath = "";


                if (Person.Save())
                {
                    _Mode = enMode.Update;
                    MessageBox.Show("Data Save Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("don't save");
            }
            else
            {
                MessageBox.Show("Some filed are not valid, put the mouse over the red icons\n to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Person.PersonID;
        }

        private void _FillCountriesInComboBox()
        {
            comboBoxCountry.DataSource = clsCountry.GetAllCountry();

            comboBoxCountry.DisplayMember = "CountryName";
            comboBoxCountry.ValueMember = "CountryID";
        }

        private void tbNationalNo_Validated(object sender, EventArgs e)
        {
            if (clsPerson.IsPersonExists(tbNationalNo.Text))
                errorProvider1.SetError(tbNationalNo, "National Number is used for another person");
            else
                errorProvider1.Clear();
        }

        private void tbEmail_Validated(object sender, EventArgs e)
        {
            if (!clsValidation.ValidateEmail(tbEmail.Text) && !string.IsNullOrEmpty(tbEmail.Text))
                errorProvider1.SetError(tbEmail, "Validated Email Address format");
            else
                errorProvider1.Clear();
        }

        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPerson.ImageLocation = null;

            if (tbMale.Checked)
                pbPerson.Image = Resources.user__4_;
            else
                pbPerson.Image = Resources.woman__2_;

            linkLabelRemove.Visible = false;
        }
    }
}
