using ContactsBusinessLayer.Detain;
using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsLicense
    {
        public enum enMode { AddNew =  0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirsTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 };

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public int DriverID { get; set; }
        public clsDrivers DriverInfo { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(IssueReason);
            }
        }
        public int CreatedByUserID { get; set; }
        public bool IsDetain
        {
            get
            {
                return clsDetain.IsDetain(LicenseID);
            }
        }
        public clsUsers CreatedByUserInfo { get; set; }
        public clsDetain DetainInfo { get; set; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = -1;
            IsActive = false;
            IssueReason = enIssueReason.FirsTime;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicense (int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            ApplicationInfo = clsApplication.Find(applicationID);
            DriverID = driverID;
            DriverInfo = clsDrivers.FindByDriverID(driverID);
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClasses.Find(licenseClassID);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUsers.FindByUserID(createdByUserID);
            DetainInfo = clsDetain.FindByLicenseID(licenseID);

            Mode = enMode.Update;
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationId, DriverID, LicenseClassID, CreatedByUserID;
            DateTime IssueDate, ExpirationDate;
            string Notes;
            decimal PaidFees;
            bool IsActive;
            short IssueReason;

            if (clsLicenseData.GetLicenseInfoByID(LicenseID, out ApplicationId, out DriverID, out LicenseClassID, out IssueDate, out ExpirationDate, out Notes, out PaidFees, out IsActive, out IssueReason, out CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationId, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID) => clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID) => GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1;

        private bool AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (short)this.IssueReason, this.CreatedByUserID);
            return this.LicenseID != -1;
        }

        private bool UpdateLicense() => clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (short)this.IssueReason, this.CreatedByUserID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return UpdateLicense();

                default:
                    return false;
            }
        }

        public bool DeactivateLicense() => clsLicenseData.DeactivateLicense(this.LicenseID);

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirsTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement for Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public static DataTable GetAllLicense() => clsLicenseData.GetAllLicense();

        public static DataTable GetDriverLicense(int DriverID) => clsLicenseData.GetDriverLicense(DriverID);

        public int Detain(decimal FineFees, int CreatedByUserID)
        {
            clsDetain detain = new clsDetain();
            detain.LicenseID = this.LicenseID;
            detain.DetainDate = DateTime.Now;
            detain.FineFees = FineFees;
            detain.CreatedByUserID = CreatedByUserID;
            detain.IsReleased = false;

            return (detain.Save()) ? detain.DetainID : -1;
        }

        public bool ReleaseDetainedLicense(int ReleaseByUserID)
        {
            clsApplication application = new clsApplication();
            application.ApplicationPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationType = clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            application.Status = clsApplication.enApplicationStatus.Completed;
            application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).Fees;
            application.CreatedByUserID = ReleaseByUserID;

            return (application.Save()) ? this.DetainInfo.ReleaseDetainLicense(ReleaseByUserID, application.ApplicationID) : false;
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication application = new clsApplication();
            application.ApplicationPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationType = clsApplication.enApplicationType.RenewDrivingLicense;
            application.Status = clsApplication.enApplicationStatus.Completed;
            application.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            application.CreatedByUserID = CreatedByUserID;

            if (!application.Save())
                return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.PaidFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            DeactivateLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason issueReason, int CreatedByUserID)
        {
            clsApplication application = new clsApplication();
            application.ApplicationPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationType = (issueReason == enIssueReason.ReplacementForDamaged) ? clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense : clsApplication.enApplicationType.ReplacementForALostDrivingLicense;
            application.Status = clsApplication.enApplicationStatus.Completed;
            application.PaidFees = clsApplicationTypes.Find((int)application.ApplicationType).Fees;
            application.CreatedByUserID = CreatedByUserID;

            if (!application.Save())
                return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = issueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            DeactivateLicense();

            return NewLicense;
        }

    }
}
