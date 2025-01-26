
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer.InternationalLicenses
{
    public class clsInternationalLicensesData
    {

        public static int AddInternationalLicenses(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            string Query = @"update InternationalLicenses
                             set IsActive = 0
                             where DriverID = @DriverID;

                            INSERT INTO InternationalLicenses
                           (ApplicationID
                           ,DriverID
                           ,IssuedUsingLocalLicenseID
                           ,IssueDate
                           ,ExpirationDate
                           ,IsActive
                           ,CreatedByUserID)
                     VALUES
                           (@ApplicationID
                           ,@DriverID
                           ,@IssuedUsingLocalLicenseID
                           ,@IssueDate
                           ,@ExpirationDate
                           ,@IsActive
                           ,@CreatedByUserID);
                            select SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                        command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                        command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
                        command.Parameters.Add("@IssueDate", SqlDbType.SmallDateTime).Value = IssueDate;
                        command.Parameters.Add("@ExpirationDate", SqlDbType.SmallDateTime).Value = ExpirationDate;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                        command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;


                        object result = command.ExecuteScalar();

                        if (result != null)
                            int.TryParse(result.ToString(), out InternationalLicenseID);
                    }
                    catch (Exception ex)
                    {
                        InternationalLicenseID = -1;
                    }
                }
            }
            return InternationalLicenseID;
        }
            
        public static bool UpdateInternationalLicenses(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int RowsAffected = 0;

            string Query = @"UPDATE [dbo].[InternationalLicenses]
                              SET [ApplicationID] = @ApplicationID 
                                 ,[DriverID] = @DriverID
                                 ,[IssuedUsingLocalLicenseID] = @IssuedUsingLocalLicenseID 
                                 ,[IssueDate] = @IssueDate 
                                 ,[ExpirationDate] = @ExpirationDate 
                                 ,[IsActive] = @IsActive 
                                 ,[CreatedByUserID] = @CreatedByUserID
                            WHERE InternationalLicenseID = @InternationalLicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                        command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                        command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
                        command.Parameters.Add("@IssueDate", SqlDbType.SmallDateTime).Value = IssueDate;
                        command.Parameters.Add("@ExpirationDate", SqlDbType.SmallDateTime).Value = ExpirationDate;
                        command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                        command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                        command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        RowsAffected = 0;
                    }
                }
            }

            return RowsAffected > 0;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            string query = @"select InternationalLicenseID from InternationalLicenses 
                            where DriverID = 1010
                            and GETDATE() between IssueDate and ExpirationDate
                            and IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);

                        InternationalLicenseID = Convert.ToInt32(sqlCommand.ExecuteScalar() ?? -1);
                    }
                    catch (Exception ex)
                    {
                        InternationalLicenseID = -1;
                    }
                }
            }
            return InternationalLicenseID;
        }

        public static bool GetInternationalLicensesByLicenseID(int InternationalLicenseID, out int ApplicationID, out int DriverID, out int IssuedUsingLocalLicenseID, out DateTime IssueDate, out DateTime ExpirationDate, out bool IsActive, out int CreatedByUserID)
        {
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            IsActive = false;
            CreatedByUserID = -1;

            bool isFind = false;

            string Query = @"select * from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                IsActive = (bool)reader["IsActive"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
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

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            string Query = @"select InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive from InternationalLicenses order by IsActive, ExpirationDate desc;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = Command.ExecuteReader())
                            if (reader.HasRows)
                                dt.Load(reader);
                    }
                    catch (Exception ex)
                    {
                        dt = new DataTable();
                    }
                }
            }
            return dt;
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dt = new DataTable();

            string Query = @"SELECT InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive
                             FROM     InternationalLicenses
                             WHERE  (DriverID = @DriverID);";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        Command.Parameters.Add("DriverID", SqlDbType.Int).Value = DriverID;

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dt = new DataTable();
                    }
                }
            }
            return dt;
        }
    
    }
}
