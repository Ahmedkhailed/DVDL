using ContactsBusinessLayer.clsManageTestApplication;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer.Local_Driving_License_Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ContactsBusinessLayer.Local_Driving_License_Applications
{
    public class clsLocalDrivingLicenseApplications : clsApplication
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo { get; set; }
        public string PersonFullName
        {
            get
            {
                return base.PersonInfo.FullName;
            }
        }
        
        public clsLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;

            Mode = enMode.AddNew;
        }

        private  clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate, enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationType = ApplicationTypeID;
            this.Status = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
            this.PersonInfo = clsPerson.Find(ApplicationPersonID);
            this.ApplicationTypeInfo = clsApplicationTypes.Find((int)ApplicationTypeID);
            this.CreatedByUserInfo = clsUsers.FindByUserID(CreatedByUserID);

            Mode = enMode.Update;
        }

        public int GetPassedTestCount() => clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);

        public static int GetPassedTestCount(int LocalDrivingLicenseApplicationID) => clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID);

        public bool PassedAllTests() => GetPassedTestCount() == 3;

        public static clsLocalDrivingLicenseApplications FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID, LicenseClassID;

            if (clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsInfoByID(LocalDrivingLicenseApplicationID, out ApplicationID, out LicenseClassID))
            {
                clsApplication Application = clsApplication.Find(ApplicationID);
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, Application.ApplicationPersonID, Application.ApplicationDate, Application.ApplicationType, Application.Status, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplications FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID, LicenseClassID;

            if (clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsInfoByID(ApplicationID, out LocalDrivingLicenseApplicationID, out LicenseClassID))
            {
                clsApplication Application = clsApplication.Find(ApplicationID);
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, Application.ApplicationPersonID, Application.ApplicationDate, Application.ApplicationType, Application.Status, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public static DataTable GetAllDrivingLicenseApplication() => clsLocalDrivingLicenseApplicationsData.GetAllDrivingLicenseApplication();

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);
            return (LocalDrivingLicenseApplicationID != -1);
        }

        private bool Update() => clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                        return false;
                case enMode.Update:
                    return Update();
                default: return false;
            }
        }

        public static int GetApplicationID(int LocalDrivingLicenseApplicationID) => clsLocalDrivingLicenseApplicationsData.GetApplicationID(LocalDrivingLicenseApplicationID);

        public bool Delete()
        {
           if (!clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID))
                return false;

           return base.DeleteApplication();
        }

        public int GetActiveLicenseID() => clsLicense.GetActiveLicenseIDByPersonID(this.ApplicationPersonID, this.LicenseClassID);

        public bool DoesAttendTestType(int TestTypeID) => clsLocalDrivingLicenseApplicationsData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, TestTypeID);

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID) => clsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID) => clsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID) => clsLocalDrivingLicenseApplicationsData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID) => clsLocalDrivingLicenseApplicationsData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID) => clsLocalDrivingLicenseApplicationsData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        public clsTest GetLastTestPerTestType(clsTestType.enTestType testTypeID) => clsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicationPersonID, this.LicenseClassID, testTypeID);

        public int IssueLicenseForFirstTime(string Notes, int CreatedByUserID)
        {
            clsDrivers Driver = clsDrivers.FindByPersonID(this.ApplicationPersonID);

            if (Driver == null)
            {
                Driver = new clsDrivers();
                Driver.PersonID = this.ApplicationPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (!Driver.Save())
                    return -1;
            }

            clsLicense license = new clsLicense();

            license.ApplicationID = this.ApplicationID;
            license.DriverID = Driver.DriverID;
            license.LicenseClassID = this.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefaultValidityLength);
            license.Notes = Notes;
            license.PaidFees = this.LicenseClassInfo.ClassFees;
            license.IsActive = true;
            license.IssueReason = clsLicense.enIssueReason.FirsTime;
            license.CreatedByUserID = CreatedByUserID;

            if (license.Save())
            {
                this.SetCompleted();
                return license.LicenseID;
            }
            return -1;
        }

    }
}
