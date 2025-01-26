using ContactsBusinessLayer.Drivers;
using ContactsBusinessLayer.LicenseClasses;
using ContactsBusinessLayer.Local_Driving_License_Applications;
using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer.Driver;
using ContactsDataAccessLayer.InternationalLicenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ContactsBusinessLayer.InternationalLicenses
{
    public class clsInternationalLicenses: clsApplication
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;

        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDrivers DriverInfo { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public  bool IsActive { get; set; }

        public clsInternationalLicenses()
        {
            ApplicationID = -1;
            InternationalLicenseID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.MaxValue;
            ExpirationDate = DateTime.MaxValue;
            IsActive = false;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsInternationalLicenses(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int ApplicantPersonID, DateTime ApplicationDate, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            base.ApplicationID = applicationID;
            base.ApplicationPersonID = ApplicationPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationType = clsApplication.enApplicationType.NewInternationalLicense;
            base.Status = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;
            base.CreatedByUserInfo = clsUsers.FindByUserID(CreatedByUserID);

            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.DriverInfo = clsDrivers.FindByDriverID(driverID);
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public  bool AddNew()
        {
            this.InternationalLicenseID =clsInternationalLicensesData.AddInternationalLicenses(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return InternationalLicenseID != -1;
        }

        private bool Update() => clsInternationalLicensesData.UpdateInternationalLicenses(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return Update();

                default:
                    return false;
            }
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID) => clsInternationalLicensesData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        public static clsInternationalLicenses Find(int InternationalLicenseID)
        {
            int ApplicationID, DriverID, IssuedUsingLocalLicenseID, CreatedByUserID;
            DateTime IssueDate, ExpirationDate;
            bool IsActive = false;

            if (clsInternationalLicensesData.GetInternationalLicensesByLicenseID(InternationalLicenseID, out ApplicationID, out DriverID, out IssuedUsingLocalLicenseID, out IssueDate, out ExpirationDate, out IsActive, out CreatedByUserID))
            {
                clsApplication application = clsApplication.Find(ApplicationID);
                return new clsInternationalLicenses(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, application.ApplicationPersonID, application.ApplicationDate, application.Status, application.LastStatusDate, application.PaidFees, application.CreatedByUserID);
            }

            return null;
        }

        public static DataTable GetAllInternationalLicenses() => clsInternationalLicensesData.GetAllInternationalLicenses();

        public static DataTable GetDriverInternationalLicenses(int DriverID) => clsInternationalLicensesData.GetDriverInternationalLicenses(DriverID);

    }
}
