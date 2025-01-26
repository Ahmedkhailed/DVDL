using ContactsBusinessLayer.MangeApplicationTypes;
using ContactsDataAccessLayer.ManageTestType;
using ContactsDataAccessLayer.MangeApplicationTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer.clsManageTestApplication
{
    public class clsTestType
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3};

        public clsTestType.enTestType ID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public clsTestType()
        {
            ID = clsTestType.enTestType.VisionTest;
            this.Title = string.Empty;
            this.Description = string.Empty;
            this.Fees = 0;
        }

        private clsTestType(clsTestType.enTestType ID, string Title, string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        static public DataTable GetAllTestTypes() => clsTestTypeData.GetAllTestTypes();

        public bool UpdateTest(string Title, string Description, decimal Fees) => clsTestTypeData.UpdateTestTypes((int)this.ID, Title, Description, Fees);

        public bool Save() => UpdateTest(Title, Description, Fees);

        static public clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string Description = string.Empty;
            string Title = string.Empty;
            decimal Fees = 0;
            if (clsTestTypeData.GetTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))
                return new clsTestType(TestTypeID, Title, Description, Fees);
            else
                return null;
        }
    
    }
}
