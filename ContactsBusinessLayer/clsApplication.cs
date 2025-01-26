
using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;
        public enum enApplicationType { NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementForALostDrivingLicense = 3, ReplacementForADamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5, NewInternationalLicense = 6, RetakeTest = 8}
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
        
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enApplicationType ApplicationType { get; set; }
        public clsApplicationTypes ApplicationTypeInfo;
        public enApplicationStatus Status { get; set; }
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case enApplicationStatus.New:
                        return "new";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknow";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers CreatedByUserInfo;

        public clsApplication()
        {
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationType = enApplicationType.NewLocalDrivingLicense;
            Status = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
        }

        private clsApplication(int applicationID, int applicationPersonID, DateTime applicationDate, enApplicationType applicationTypeID, enApplicationStatus applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicationPersonID = applicationPersonID;
            PersonInfo = clsPerson.Find(ApplicationPersonID);
            ApplicationDate = applicationDate;
            ApplicationType = applicationTypeID;
            ApplicationTypeInfo = clsApplicationTypes.Find((int)ApplicationType);
            Status = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUsers.FindByUserID(createdByUserID);

            Mode = enMode.Update;
        }

        public static DataTable GetAllApplications() => clsApplicationData.GetAllApplications();

        public static clsApplication Find(int ApplicationID)
        {
            int ApplicationPersonID, ApplicationTypeID, CreatedByUserID;
            DateTime ApplicationDate, LastStatusDate;
            short ApplicationStatus;
            decimal PaidFees;

            if (clsApplicationData.GetApplicationByID(ApplicationID, out ApplicationPersonID, out ApplicationDate, out ApplicationTypeID, out ApplicationStatus, out LastStatusDate, out PaidFees, out CreatedByUserID))
                return new clsApplication(ApplicationID, ApplicationPersonID, ApplicationDate, (enApplicationType)ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;
        }

        public bool DeleteApplication() => clsApplicationData.DeleteApplication(this.ApplicationID);

        private bool _UpdateApplication() => clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate, (int)this.ApplicationType,(short) this.Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        static public bool UpdateStatus(int ApplicationID, short Status) => clsApplicationData.UpdateStatus(ApplicationID, Status);

        public static int GetActiveApplicationIDForLicenseClass(int ApplicantPersonID, enApplicationType ApplicationTypeID, int LicenseClassID) => clsApplicationData.GetActiveApplicationIDForLicenseClass(ApplicantPersonID, (int)ApplicationTypeID, LicenseClassID);

        private bool _AddNewApplication()
        {
           this.ApplicationID = clsApplicationData.AddNewApplication(ApplicationPersonID, ApplicationDate, (int)ApplicationType, (short)Status, LastStatusDate, PaidFees, CreatedByUserID);
            return this.ApplicationID != -1;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return (_UpdateApplication());

            }

            return false;
        }

        public bool Cancel() => clsApplicationData.UpdateStatus(ApplicationID, (short)enApplicationStatus.Cancelled);

        public bool SetCompleted() => clsApplication.UpdateStatus(ApplicationID, (short)enApplicationStatus.Completed);
        
    }
}
