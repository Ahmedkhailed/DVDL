using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.TestAppointments;
using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsTest
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID {  get; set; }
        public clsTestAppointments TestAppointments { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers CreatedByUserInfo;

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = 0;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = 0;

            _Mode = enMode.AddNew;
        }

        private clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            this.TestID = testID;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;
            this.TestAppointmentID = testAppointmentID;
            this.TestAppointments = clsTestAppointments.Find(testAppointmentID);
            this.TestResult = testResult;
            this.CreatedByUserInfo = clsUsers.FindByUserID(createdByUserID);

            _Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return this.TestID != -1;
        }

        private bool _UpdateTest() => clsTestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTest();

                default: 
                    return false;
            }
        }

        public static DataTable GetAllTests() => clsTestData.GetAllTests();

        public static clsTest Find(int TestID)
        {
            int TestAppointmentID, CreatedByUserID;
            bool TestResult;
            string Notes;

            if (clsTestData.GetTestInfoByID(TestID, out TestAppointmentID, out TestResult, out Notes, out CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }

        public static clsTest FindLastTestPerPersonAndLicenseClass(int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID, TestID, CreatedByUserID;
            bool TestResult;
            string Notes;

            if (clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, LicenseClassID, (int)TestTypeID, out TestID, out TestAppointmentID, out TestResult, out Notes, out CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID) => clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);

    }
}
