using ContactsBusinessLayer;
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
using static ContactsBusinessLayer.clsApplication;
using static DrivingLicenseManagement.AddEdit;
using static System.Net.Mime.MediaTypeNames;

namespace DrivingLicenseManagement
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        private enum _enMode { AddNew = 1, Update = 2 };
        private _enMode _Mode = _enMode.AddNew;

        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = _enMode.Update;
        }

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = _enMode.AddNew;
        }

        private void _fillLicenseClassInComboBox()
        {
            cbLicenseClass.DataSource = clsLicenseClasses.GetAllLicenseClasses();
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.SelectedIndex = 0;
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void _ResetDefaultValues()
        {
            _fillLicenseClassInComboBox();

            if (_Mode == _enMode.AddNew)
            {
                lbTitle.Text = "New Local Driving License Application";

                _LocalDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();
                findPeople1.FilterFocus();
                tpApplictioninfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lbApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewLocalDrivingLicense).Fees.ToString();
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lbTitle.Text = "Update Local Driving License Application";

                tpApplictioninfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {
            findPeople1.FilterEnabled = false;

            _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplications == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            findPeople1.LoadPersonInfo(_LocalDrivingLicenseApplications.ApplicationPersonID);

            lbDLApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lbApplicationDate.Text = _LocalDrivingLicenseApplications.ApplicationDate.ToShortDateString();
            lbApplicationFees.Text = _LocalDrivingLicenseApplications.PaidFees.ToString();
            lbCreatedBy.Text = clsUsers.FindByUserID(_LocalDrivingLicenseApplications.CreatedByUserID).UserName;
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplications.LicenseClassInfo.ClassName);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tpApplictioninfo;

        private void tabControl1_Click(object sender, EventArgs e) => btnSave.Enabled = (clsPerson.IsPersonExists(_SelectedPersonID));

        private void btnSave_Click(object sender, EventArgs e)
        {
            int licenseClassesID = clsLicenseClasses.Find((int)cbLicenseClass.SelectedValue).LicenseClassesID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, enApplicationType.NewLocalDrivingLicense, licenseClassesID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another license Class, the selected person Already have an active application for the selected class with " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(findPeople1.PersonID, licenseClassesID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, choose different driving class.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplications.ApplicationPersonID = findPeople1.PersonID;
            _LocalDrivingLicenseApplications.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplications.ApplicationType = clsApplication.enApplicationType.NewLocalDrivingLicense;
            _LocalDrivingLicenseApplications.Status = enApplicationStatus.New;
            _LocalDrivingLicenseApplications.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplications.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplications.PaidFees = Convert.ToDecimal(lbApplicationFees.Text);
            _LocalDrivingLicenseApplications.LicenseClassID = (int)cbLicenseClass.SelectedValue;

            if (clsLicenseClasses.Find(licenseClassesID).MinimumAllowedAge <= clsPerson.Find(_SelectedPersonID).GetPersonAge())
                if (_LocalDrivingLicenseApplications.Save())
                {
                    lbDLApplicationID.Text = _LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID.ToString();

                    _Mode = _enMode.Update;

                    lbTitle.Text = "Update Local Driving License Application";

                    MessageBox.Show("Saved data successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error : Date Is not saved successfully. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Error : This age is not permitted for this license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void findPeople1_BackData(int PersonId)
        {
            _SelectedPersonID = PersonId;
            if (PersonId != -1)
            {
                btnNext.Enabled = true;
                btnSave.Enabled = true;
                tpApplictioninfo.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
                btnSave.Enabled = false;
                tpApplictioninfo.Enabled = false;
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e) => findPeople1.FilterFocus();

    }
}
