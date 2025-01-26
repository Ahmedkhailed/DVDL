using ContactsDataAccessLayer.LicenseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer.LicenseClasses
{
    public class clsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update  = 1 }
        public enMode Mode = enMode.AddNew;

        public int LicenseClassesID {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public short MinimumAllowedAge { get; set; }
        public short DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClasses()
        {
            LicenseClassesID = -1;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;

            Mode = enMode.AddNew;
        }

        private clsLicenseClasses(int LicenseClassesID, string ClassName, string ClassDescription, short MinimumAllowedAge, short DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassesID = LicenseClassesID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;
        }

        public static DataTable GetAllLicenseClasses() => clsLicenseClassesData.GetAllLicenseClasses();

        public static clsLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            short MinimumAllowedAge = 0;
            short DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassesData.GetLicenseClassesByLicenseClassID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }

        public static clsLicenseClasses Find(string ClassName)
        {
            int LicenseID = -1;
            string ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassesData.GetLicenseClassesByClassName(ref LicenseID, ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClasses(LicenseID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }

        public bool AddNewLicenseClasses()
        {
            this.LicenseClassesID = clsLicenseClassesData.AddNewLicenseClasses(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return this.LicenseClassesID != -1;
        }

        public bool Update() => clsLicenseClassesData.UpdateLicenseClasses(this.LicenseClassesID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewLicenseClasses())
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


    }
}
