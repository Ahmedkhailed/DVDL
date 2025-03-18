using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ContactsDataAccessLayer
{
    static class clsDataAccessSetting
        {
            public static string ConnectionString = ConfigurationManager.ConnectionStrings["ContactsDB"].ConnectionString;
    }
}
