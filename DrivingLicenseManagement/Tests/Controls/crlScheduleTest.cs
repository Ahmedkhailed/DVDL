using ContactsBusinessLayer;
using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsBusinessLayer.TestAppointments;
using DrivingLicenseManagement.Golbal_Classes;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DrivingLicenseManagement.frmScheduleTest;

namespace DrivingLicenseManagement
{
    public partial class VisionTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplications _localDrivingLicenseApplications;

        private int _TestAppointmentID = -1;
        private clsTestAppointments _TestAppointment = new clsTestAppointments();

        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestType; }
            set
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestType.enTestType.VisionTest:
                        groupBoxTestType.Text = "Vision Test";
                        pictureBox1.Image = Properties.Resources.eye_with_thick_outline_variant;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        groupBoxTestType.Text = "Written Test";
                        pictureBox1.Image = Properties.Resources.cv;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        groupBoxTestType.Text = "Street Test";
                        pictureBox1.Image = Properties.Resources.hatchback_car_variant_side_view_silhouette;
                        break;
                }
            }
        }

        public VisionTest()
        {
            InitializeComponent();
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lbFees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dateTimePicker1.MinDate = DateTime.Now;
            else
                dateTimePicker1.MinDate = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                gbRetakeTestInfo.Enabled = false;
                lb_R_App_Fees.Text = "0";
                lbTitle.Text = "Schedule Test";
                lb_R_Test_App_ID.Text = "N/A";
            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lb_R_Test_App_ID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                lb_R_App_Fees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                lbTitle.Text = "Schedule Retake Test";
            }

            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestType))
            {
                lblUserMessage.Text = "Person already have an active appointment for this test";
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                return false;
            }
            lblUserMessage.Visible = false;

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Text = "Person already sat for the test, appointment locked";
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                return false;
            }
            lblUserMessage.Visible = false;

            return true;  
        }

        private bool _HandlePreviousTestConstraint()
        {
            switch(TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    if (!_localDrivingLicenseApplications.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Cannot Schedule, Vision Test should be passed first";
                        btnSave.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dateTimePicker1.Enabled = true;
                        return true;
                    }

                case clsTestType.enTestType.StreetTest:
                    if (!_localDrivingLicenseApplications.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Cannot Schedule, Written Test should be passed first";
                        btnSave.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dateTimePicker1.Enabled = true;
                        return true;
                    }

                default:
                    return true;
            }
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplications == null)
            {
                MessageBox.Show("Error : No local driving license application with id + " + LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            _CreationMode = _localDrivingLicenseApplications.DoesAttendTestType((int)_TestType) ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                gbRetakeTestInfo.Enabled = true;
                lb_R_App_Fees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString("#.##");
                lb_R_Test_App_ID.Text = "0";
                lbTitle.Text = "Schedule Retake Test";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lb_R_App_Fees.Text = "0";
                lb_R_Test_App_ID.Text = "N/A";
                lbTitle.Text = "Schedule Test";
            }

            lbDLAppID.Text = _localDrivingLicenseApplications.LocalDrivingLicenseApplicationID.ToString();
            lbDClass.Text = _localDrivingLicenseApplications.LicenseClassInfo.ClassName;
            lbName.Text = _localDrivingLicenseApplications.PersonFullName;
            lbTrail.Text = _localDrivingLicenseApplications.TotalTrialsPerTest(_TestType).ToString();

            if (_Mode == enMode.AddNew)
            {
                lbFees.Text = clsTestType.Find(_TestType).Fees.ToString();
                dateTimePicker1.MinDate = DateTime.Now;

                _TestAppointment = new clsTestAppointments();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lbTotalFees.Text = (Convert.ToSingle(lb_R_App_Fees.Text) + Convert.ToSingle(lbFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint()) return;

            if (!_HandleAppointmentLockedConstraint()) return;

            if (_HandlePreviousTestConstraint()) return;

        }
        
        private bool _HandleRetakeApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication Application = new clsApplication();
                Application.ApplicationPersonID = _localDrivingLicenseApplications.ApplicationPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationType = clsApplication.enApplicationType.RetakeTest;
                Application.Status = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    MessageBox.Show("failed to create application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication()) return;

            _TestAppointment.TestTypeID = _TestType;
            _TestAppointment.LocalDrivingLicenseApplicationID = Convert.ToInt32(lbDLAppID.Text);
            _TestAppointment.AppointmentDate = dateTimePicker1.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(lbTotalFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Data Save Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
            }
            else
                MessageBox.Show("Error : data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}

