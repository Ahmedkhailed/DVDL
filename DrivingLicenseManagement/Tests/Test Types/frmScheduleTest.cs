using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.Local_Driving_License_Applications;
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
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplication = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _TestAppointmentID = -1;

        public frmScheduleTest(int LocalDrivingLicenseApplication, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplication = LocalDrivingLicenseApplication;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            visiontest1.TestTypeID = _TestTypeID;
            visiontest1.LoadInfo(_LocalDrivingLicenseApplication, _TestAppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

    }
}
