using ContactsBusinessLayer;
using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.TestAppointments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ContactsBusinessLayer.clsManageTestApplication.clsTestType;

namespace DrivingLicenseManagement
{
    public partial class frmVisionTestAppointments : Form
    {

        private int _localDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestTypeID;
        

        public frmVisionTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType testTypeID)
        {
            InitializeComponent();

            _localDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
        }

        private void _SetImage()
        {
            if (_TestTypeID == clsTestType.enTestType.VisionTest)
            {
                pictureBox1.Image = Properties.Resources.eye_with_thick_outline_variant;
            }
            else if (_TestTypeID == clsTestType.enTestType.WrittenTest)
            {
                pictureBox1.Image = Properties.Resources.cv;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.hatchback_car_variant_side_view_silhouette;
            }
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            _SetImage();

            localDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingLicenseApplicationID(_localDrivingLicenseApplicationID);
            lbTitle.Text = clsTestType.Find(_TestTypeID).Title;
            dataGridView1.DataSource = clsTestAppointments.GetAllTestAppointmentsPerTestType(_localDrivingLicenseApplicationID, _TestTypeID);

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 150;

                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 100;
            }
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplications localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(_localDrivingLicenseApplicationID);

            if (localDrivingLicenseApplications.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person already have an active appointment for this test, you cannot add new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = localDrivingLicenseApplications.GetLastTestPerTestType(_TestTypeID);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_localDrivingLicenseApplicationID, _TestTypeID);
                frm1.ShowDialog();
                this.frmVisionTestAppointments_Load(null, null);
                return;
            }

            if (LastTest.TestResult)
            {
                MessageBox.Show("This person already passed this test before, you can only retake failed test", "Nor allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest scheduleTest = new frmScheduleTest(_localDrivingLicenseApplicationID, _TestTypeID);
            scheduleTest.ShowDialog();
            this.frmVisionTestAppointments_Load(null, null);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            frmScheduleTest ScheduleTest = new frmScheduleTest(_localDrivingLicenseApplicationID, _TestTypeID, (int)dataGridView1.CurrentRow.Cells[0].Value);
            ScheduleTest.ShowDialog();
            this.frmVisionTestAppointments_Load(null, null);
        }

        private void TakeTest_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest((int)dataGridView1.CurrentRow.Cells[0].Value, _TestTypeID);
            takeTest.ShowDialog();
            this.frmVisionTestAppointments_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

    }
}
