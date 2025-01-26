using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer.LicenseClasses
{

    public class clsLicenseClassesData
    {

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            string Query = "select * from LicenseClasses;";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                dt.Load(Reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return dt;
        }

        public static bool GetLicenseClassesByLicenseClassID(int LicenseClassID, ref string ClassName, ref string ClassDescription, ref short MinimumAllowedAge, ref short DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFind = false;

            string Query = "select * from LicenseClasses where LicenseClassID = @LicenseClassID;";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                isFind = true;
                                ClassName = (string)Reader["ClassName"];
                                ClassDescription = (string)Reader["ClassDescription"];
                                MinimumAllowedAge = Convert.ToInt16(Reader["MinimumAllowedAge"]);
                                DefaultValidityLength = Convert.ToInt16(Reader["DefaultValidityLength"]);
                                ClassFees = (decimal)Reader["ClassFees"];
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return isFind;
        }

        public static bool GetLicenseClassesByClassName(ref int LicenseClassID, string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFind = false;

            string Query = "select * from LicenseClasses where ClassName = @ClassName;";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        command.Parameters.AddWithValue("@ClassName", ClassName);

                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                isFind = true;
                                LicenseClassID = (int)Reader["LicenseClassID"];
                                ClassDescription = (string)Reader["ClassDescription"];
                                MinimumAllowedAge = (byte)Reader["MinimumAllowedAge"];
                                DefaultValidityLength = (byte)Reader["DefaultValidityLength"];
                                ClassFees = (decimal)Reader["ClassFees"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return isFind;
        }

        public static int AddNewLicenseClasses(string ClassName, string ClassDescription, short MinimumAllowedAge, short DefaultValidityLength, decimal ClassFees)
        {
            int LicenseClassesId = -1;

            string Query = @"INSERT INTO LicenseClasses
                                   (ClassName
                                   ,ClassDescription
                                   ,MinimumAllowedAge
                                   ,DefaultValidityLength
                                   ,ClassFees)
                             VALUES
                                   (@ClassName 
                                   ,@ClassDescription 
                                   ,@MinimumAllowedAge 
                                   ,@DefaultValidityLength 
                                   ,@ClassFees);
	                        	   select SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ClassName", ClassName);
                        command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                        command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                        command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                        command.Parameters.AddWithValue("@ClassFees", ClassFees);

                        object Result = command.ExecuteScalar();
                        if (Result != null)
                            int.TryParse(Result.ToString(), out LicenseClassesId);
                    }
                    catch (Exception ex) { }
                }
            }
            return LicenseClassesId;
        }

        public static bool UpdateLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription, short MinimumAllowedAge, short DefaultValidityLength, decimal ClassFees)
        {
            int RowsAffected = 0;

            string Query = @"UPDATE LicenseClasses
                              SET ClassName = @ClassName
                                 ,ClassDescription = @ClassDescription
                                 ,MinimumAllowedAge = @MinimumAllowedAge
                                 ,DefaultValidityLength = @DefaultValidityLength
                                 ,ClassFees = @ClassFees
                            WHERE LicenseClassID = @LicenseClassID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command =  new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ClassName", ClassName);
                        command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                        command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                        command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                        command.Parameters.AddWithValue("@ClassFees", ClassFees);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch(Exception ex) { }
                }
            }
            return RowsAffected > 0;
        }

    }
}
