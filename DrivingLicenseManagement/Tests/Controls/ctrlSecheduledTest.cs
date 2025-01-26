using ContactsBusinessLayer;
using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.TestAppointments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement.Tests.Controls
{
    public partial class ctrlSecheduledTest : UserControl
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (value)
                {
                    case clsTestType.enTestType.VisionTest:
                        groupBoxTestType.Text = "Vision Test";
                        lbTitle.Text = "Vision Test";
                        pictureBox1.Image = Properties.Resources.eye_with_thick_outline_variant;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        groupBoxTestType.Text = "Written Test";
                        lbTitle.Text = "Written Test";
                        pictureBox1.Image = Properties.Resources.cv;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        groupBoxTestType.Text = "Street Test";
                        lbTitle.Text = "Street Test";
                        pictureBox1.Image = Properties.Resources.hatchback_car_variant_side_view_silhouette;
                        break;
                }
            }
        }

        public int TestAppointmentID = -1;
        public int TestID = -1;

        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }

        public void LoadData(int TestAppointmentID)
        {
            clsTestAppointments testAppointments = clsTestAppointments.Find(TestAppointmentID);

            if (testAppointments != null)
            {
                TestAppointmentID = testAppointments.TestAppointmentID;
                TestID = testAppointments.TestID;

                lbDLAppID.Text = testAppointments.LocalDrivingLicenseApplicationID.ToString();
                lbDClass.Text = testAppointments.LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
                lbName.Text = testAppointments.LocalDrivingLicenseApplicationInfo.PersonFullName;
                lbTrail.Text = testAppointments.LocalDrivingLicenseApplicationInfo.TotalTrialsPerTest(TestTypeID).ToString();
                lbDate.Text = testAppointments.AppointmentDate.ToShortDateString();
                lbFees.Text = testAppointments.PaidFees.ToString("#.##");
                lbTestID.Text = (testAppointments.TestID != -1) ? testAppointments.TestID.ToString() : "Not Taken Yet";
            }
        }

    }
}
