using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer.ManageTestType;
using ContactsDataAccessLayer.TestAppointments;
using ContactsDataAccessLayer.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer.TestAppointments
{
    public class clsTestAppointments
    {
        public enum enMode { AddNew = 1, Update = 2}
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID;
        public clsTestType.enTestType TestTypeID;
        public clsTestType TestTypeInfo;
        public int LocalDrivingLicenseApplicationID;
        public clsLocalDrivingLicenseApplications LocalDrivingLicenseApplicationInfo;
        public DateTime AppointmentDate;
        public decimal PaidFees;
        public int CreatedByUserID;
        public clsUsers CreatedByUserInfo;
        public bool IsLocked;
        public int RetakeTestApplicationID;
        public clsApplication RetakeTestApplicationInfo;
        public int TestID
        {
            get { return _GetTestID(); }
        }

        public clsTestAppointments()
        {
            TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;

            TestTypeInfo = null;
            LocalDrivingLicenseApplicationInfo = null;
            CreatedByUserInfo = null;
            RetakeTestApplicationInfo = null;
        }

        private clsTestAppointments(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            TestTypeInfo = clsTestType.Find(TestTypeID);
            LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
            CreatedByUserInfo = clsUsers.FindByUserID(CreatedByUserID);
            if (RetakeTestApplicationID != -1)
                RetakeTestApplicationInfo = clsApplication.Find(RetakeTestApplicationID);

            Mode = enMode.Update;
        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {
            int TestTypeID, LocalDrivingLicenseApplicationID, CreatedByUserID, RetakeTestApplicationID;
            DateTime AppointmentDate;
            decimal PaidFees;
            bool IsLocked;

            if (clsTestAppointmentsData.GetTestAppointmentByID(TestAppointmentID, out TestTypeID, out LocalDrivingLicenseApplicationID, out AppointmentDate, out PaidFees, out CreatedByUserID, out IsLocked, out RetakeTestApplicationID))
                return new clsTestAppointments(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;
        }

        public static clsTestAppointments GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TestAppointmentID, CreatedByUserID, RetakeTestApplicationID;
            DateTime AppointmentDate;
            decimal PaidFees;
            bool IsLocked;

            if (clsTestAppointmentsData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID, out TestAppointmentID, out AppointmentDate, out PaidFees, out CreatedByUserID, out IsLocked, out RetakeTestApplicationID))
                return new clsTestAppointments(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;
        }

        public static DataTable GetAllTestAppointments() => clsTestAppointmentsData.GetAllTestAppointments();

        public static DataTable GetAllTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID) => clsTestAppointmentsData.GetAllTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        
        public static bool IsValid(int LocalDrivingLicenseApplicationID, string Title)
        {
            return clsTestAppointmentsData.IsValid(LocalDrivingLicenseApplicationID, Title);
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
            return TestAppointmentID != -1;
        }
       
        private bool _UpdateAppointmentByID() => clsTestAppointmentsData.UpdateAppointmentByID(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                
                case enMode.Update:
                    return _UpdateAppointmentByID();
                
                default:
                    return false;
            }
        }

        private int _GetTestID() => clsTestAppointmentsData.GetTestID(this.TestAppointmentID);

    }
}
