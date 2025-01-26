using ContactsBusinessLayer.InternationalLicenses;
using ContactsBusinessLayer.Users;
using ContactsDataAccessLayer.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer.Drivers
{
    public  class clsDrivers
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int DriverID {  get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers CreatedUserInfo { get; set; }
        public DateTime CreatedDate { get;}


        public clsDrivers()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedUserInfo = clsUsers.FindByUserID(PersonID);
            this.CreatedDate = CreatedDate;

            Mode = enMode.Update;
        }

        public static clsDrivers FindByDriverID(int DriverID)
        {
            int PersonID, CreatedByUserID;
            DateTime CreatedDate;

            if (clsDriversData.GetDriverByDriverID(DriverID, out PersonID, out CreatedByUserID, out CreatedDate))
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsDrivers FindByPersonID(int personID)
        {
            int DriverID, CreatedByUserID;
            DateTime CreatedDate;

            if (clsDriversData.GetDriverByPersonID(out DriverID, personID, out CreatedByUserID, out CreatedDate))
                return new clsDrivers(DriverID, personID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        private bool AddNewDriver()
        {
            this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUserID);
            return this.DriverID != -1;
        }

        private bool UpdateDriver() => clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return UpdateDriver();

                default:
                    return false;
            }
        }

        public static DataTable GetAllDrivers() => clsDriversData.GetAllDriver();

        public static DataTable GetLicenses(int DriverID) => clsLicense.GetDriverLicense(DriverID);

        public static DataTable GetInternationalLicenses(int DriverID) => clsInternationalLicenses.GetDriverInternationalLicenses(DriverID);
    }
}
