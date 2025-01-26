using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ContactsDataAccessLayer
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByID(int LicenseID, out int ApplicationID, out int DriverID, out int LicenseClassID, out DateTime IssueDate, out DateTime ExpirationDate, out string Notes, out decimal PaidFees, out bool IsActive, out short IssueReason, out int CreatedByUserID)
        {
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = 1;
            CreatedByUserID = -1;

            bool isFind = false;

            string Query = @"select * from Licenses where LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFind = true;
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClassID = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                                PaidFees = (decimal)reader["PaidFees"];
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = Convert.ToInt16(reader["IssueReason"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                isFind = true;
                            }
                        }
                    }
                    catch (Exception ex) 
                    {
                        isFind = false;
                    }
                }
            }
            return isFind;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int ActiveLicenseID = -1;

            string query = @"SELECT Licenses.LicenseID
                            FROM     Licenses INNER JOIN
                                              Drivers ON Licenses.DriverID = Drivers.DriverID
                            where Licenses.LicenseClass = @LicenseClassID
                            and Drivers.PersonID = @PersonID
                            and IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        object result = command.ExecuteScalar();

                        if (result != null)
                            int.TryParse(result.ToString(), out ActiveLicenseID);   
                    }
                    catch (Exception ex) { }
                }
            }
            return ActiveLicenseID;
        }

        public static DataTable GetAllLicense()
        {
            DataTable dt = new DataTable();

            string Query = "select * from Licenses order by LicenseID desc;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                dt.Load(reader);
                        }
                    }
                    catch (System.Exception ex) { }
                }
            }
            return dt;
        }

        public static DataTable GetDriverLicense(int DriverID)
        {
            DataTable dt = new DataTable();

            string Query = @"SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
                            FROM     Licenses INNER JOIN
                                              LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            WHERE  (DriverID = @DriverID)
                            Order By IsActive Desc, ExpirationDate Desc;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@DriverID", DriverID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                                dt.Load(reader);
                        }
                    }
                    catch (System.Exception ex) { }
                }
            }
            return dt;
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, short IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            string Query = @"INSERT INTO [dbo].[Licenses]
                               ([ApplicationID]
                               ,[DriverID]
                               ,[LicenseClass]
                               ,[IssueDate]
                               ,[ExpirationDate]
                               ,[Notes]
                               ,[PaidFees]
                               ,[IsActive]
                               ,[IssueReason]
                               ,[CreatedByUserID])
                         VALUES
                               (@ApplicationID
                               ,@DriverID 
                               ,@LicenseClass 
                               ,@IssueDate 
                               ,@ExpirationDate 
                               ,@Notes 
                               ,@PaidFees 
                               ,@IsActive 
                               ,@IssueReason
                               ,@CreatedByUserID);
	                    	   select SCOPE_IDENTITY();";

            using ( SqlConnection connection = new SqlConnection( clsDataAccessSetting.ConnectionString))
            {
                using ( SqlCommand command = new SqlCommand(Query,connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        object Result = command.ExecuteScalar();
                        if (Result != null)
                            int.TryParse(Result.ToString(), out LicenseID);
                    }
                    catch (Exception ex) { }
                }
            }
            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, short IssueReason, int CreatedByUserID)
        {
            int RowsAffected = 0;

            string Query = @"UPDATE [dbo].[Licenses]
                               SET [ApplicationID] = @ApplicationID 
                                  ,[DriverID] = @DriverID 
                                  ,[LicenseClass] = @LicenseClass
                                  ,[IssueDate] = @IssueDate 
                                  ,[ExpirationDate] = @ExpirationDate 
                                  ,[Notes] = @Notes 
                                  ,[PaidFees] = @PaidFees 
                                  ,[IsActive] = @IsActive 
                                  ,[IssueReason] = @IssueReason 
                                  ,[CreatedByUserID] = @CreatedByUserID 
                             WHERE LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            return RowsAffected > 0;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            int RowsAffected = 0;

            string Query = @"UPDATE [dbo].[Licenses]
                               SET IsActive = 0 
                             WHERE LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            return RowsAffected > 0;
        } 
        
    }
}
