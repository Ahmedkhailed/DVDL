using ContactsDataAccessLayer.Local_Driving_License_Applications;
using ContactsDataAccessLayer.MangeApplicationTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer.MangeApplicationTypes
{
    public class clsApplicationTypes
    {

        public int ID;
        public string Title;
        public decimal Fees;

        public clsApplicationTypes()
        {
            ID = -1;
            this.Title = string.Empty;
            this.Fees = 0;
        }

        private clsApplicationTypes(int ApplicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            this.ID = ApplicationTypeID;
            this.Title = applicationTypeTitle;
            this.Fees = applicationFees;
        }

        static public DataTable GetAllApplicationTypes() => clsManageApplicationTypesClassesAccessLayer.GetAllApplicationTypes();

        private bool UpdateApplication(string ApplicationTypeTitle, decimal ApplicationFees) => clsManageApplicationTypesClassesAccessLayer.UpdateApplicationType(this.ID, ApplicationTypeTitle, ApplicationFees);

        public bool Save() => UpdateApplication(this.Title, this.Fees);

        static public clsApplicationTypes Find(int ID)
        {
            string Title = string.Empty;
            decimal Fees = 0;
            if (clsManageApplicationTypesClassesAccessLayer.GetApplicationTypeInfoByyID(ID, ref Title, ref Fees))
                return new clsApplicationTypes(ID, Title, Fees);
            else
                return null;
        }
    }
}