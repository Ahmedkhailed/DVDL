using ContactsBusinessLayer;
using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.TestAppointments;
using DrivingLicenseManagement.Golbal_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicenseManagement
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;
        private clsTestType.enTestType _TestType;

        private int _TestID = -1;
        private clsTest _Test;

        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestType = TestTypeID;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = (rbPass.Checked) ? true : false;
            _Test.Notes = tbNotes.Text;
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the pass/fail results after you save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Test.TestAppointmentID = _TestAppointmentID;
                _Test.TestResult = (rbPass.Checked) ? true : false;
                _Test.Notes = tbNotes.Text.Trim();
                _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (_Test.Save())
                {
                    btnSave.Enabled = false;
                    MessageBox.Show("Data Save successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblUserMessage.Visible = true;
                }
                else
                    MessageBox.Show("Error : Data is not save successfully.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.TestTypeID = _TestType;
            ctrlSecheduledTest1.LoadData(_TestAppointmentID);

            if (ctrlSecheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;

            _TestID = ctrlSecheduledTest1.TestID;
            if (_TestID != -1)
            {
                _Test = clsTest.Find(_TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                tbNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
            else
                _Test = new clsTest();
        }

    }
}
