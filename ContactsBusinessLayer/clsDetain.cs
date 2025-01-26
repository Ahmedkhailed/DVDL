using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer.Detain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer.Detain
{
    public class clsDetain
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers CreatedByUserInfo { get; set; }
        public decimal FineFees { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleaseByUserID { get; set; }
        public clsUsers ReleaseByUserInfo { get; set; }
        public int ReleaseApplicationID { get; set; }
        public clsApplication ReleaseApplicationInfo { get; set; }

        public clsDetain()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            CreatedByUserID = -1;
            FineFees = 0;
            IsReleased = false;
            ReleaseDate = DateTime.MaxValue;
            ReleaseByUserID = -1;
            ReleaseApplicationID = -1;

            Mode = enMode.AddNew;
        }

        private clsDetain(int detainID, int licenseID, DateTime detainDate, int createdByUserID, decimal fineFees, bool isReleased, DateTime releaseDate, int releaseByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUsers.FindByUserID(createdByUserID);
            FineFees = fineFees;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleaseByUserID = releaseByUserID;
            ReleaseByUserInfo = clsUsers.FindByUserID(releaseByUserID);
            ReleaseApplicationID = releaseApplicationID;
            ReleaseApplicationInfo = clsApplication.Find(releaseApplicationID);

            Mode = enMode.Update;
        }

        public static bool IsDetain(int LicenseID) => clsDetainLicenseDataAccess.IsDetain(LicenseID);

        public bool ReleaseDetainLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.ReleaseApplicationID = clsDetainLicenseDataAccess.ReleaseDetainLicense(DetainID, ReleasedByUserID, ReleaseApplicationID) ? ReleaseApplicationID : -1;
            return this.ReleaseApplicationID != -1;
        }

        public static clsDetain FindByLicenseID(int LicenseID)
        {
            int DetainID, CreatedByUserID, ReleaseApplicationID, ReleasedByUserID;
            DateTime DetainDate, ReleaseDate;
            decimal FineFees;
            bool IsReleased;

            if (clsDetainLicenseDataAccess.GetDetainLicenseByLicenseID(LicenseID, out DetainID, out DetainDate, out FineFees, out CreatedByUserID, out IsReleased, out ReleaseDate, out ReleasedByUserID, out ReleaseApplicationID))
                return new clsDetain(DetainID, LicenseID, DetainDate, CreatedByUserID, FineFees, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            else
                return null;
        }
        public static clsDetain Find(int DetainID)
        {
            int LicenseID, CreatedByUserID, ReleaseApplicationID, ReleasedByUserID;
            DateTime DetainDate, ReleaseDate;
            decimal FineFees;
            bool IsReleased;

            if (clsDetainLicenseDataAccess.GetDetainLicenseByDetainID(DetainID, out LicenseID, out DetainDate, out FineFees, out CreatedByUserID, out IsReleased, out ReleaseDate, out ReleasedByUserID, out ReleaseApplicationID))
                return new clsDetain(DetainID, LicenseID, DetainDate, CreatedByUserID, FineFees, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            else
                return null;
        }

        public static DataTable GetDetainedLicenses() => clsDetainLicenseDataAccess.GetAllDetainLicense();

        private bool AddNewDetain()
        {
            this.DetainID = clsDetainLicenseDataAccess.AddNewDetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleaseByUserID, this.ReleaseApplicationID);
            return this.DetainID != -1;
        }

        private bool UpdateDetain() => clsDetainLicenseDataAccess.UpdateDetain(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleaseByUserID, this.ReleaseApplicationID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewDetain())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return UpdateDetain();

                default:
                    return false;
            }
        }

    }
}
