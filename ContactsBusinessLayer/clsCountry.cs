using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {
        public int ID {  get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            ID = -1;
            CountryName = "";
        }

        private clsCountry(int iD, string countryName)
        {
            ID = iD;
            CountryName = countryName;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";
            if (clsCountryData.GetCountryByID(ID, ref CountryName))
                return new clsCountry(ID, CountryName);
            else
                return null;
        }

        public static clsCountry Find(string countryName)
        {
            int ID = -1;
            if (clsCountryData.GetCountryByCountryName(countryName, ref ID))
                return new clsCountry(ID, countryName);
            else
                return null;
        }

        public static DataTable GetAllCountry() => clsCountryData.GetAllCountry();

    }
}
