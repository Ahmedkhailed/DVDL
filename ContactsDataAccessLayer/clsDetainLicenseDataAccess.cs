using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer.Detain
{
    public class clsDetainLicenseDataAccess
    {
        public static bool GetDetainLicenseByLicenseID(int LicenseID, out int DetainID, out DateTime DetainDate, out decimal FineFees, out int CreatedByUserID, out bool IsReleased, out DateTime ReleaseDate, out int ReleasedByUserID, out int ReleaseApplicationID)
        {
            DetainID = 0;
            DetainDate = DateTime.Now;
            FineFees = 0m;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleaseDate = DateTime.MaxValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

            bool isFind = false;
            string Query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFind = true;

                                DetainID = reader["DetainID"] != DBNull.Value ? Convert.ToInt32(reader["DetainID"]) : -1;
                                DetainDate = reader["DetainDate"] != DBNull.Value ? Convert.ToDateTime(reader["DetainDate"]) : DateTime.MinValue;
                                FineFees = reader["FineFees"] != DBNull.Value ? Convert.ToDecimal(reader["FineFees"]) : 0;
                                CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["CreatedByUserID"]) : -1;
                                IsReleased = reader["IsReleased"] != DBNull.Value && Convert.ToBoolean(reader["IsReleased"]);
                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MaxValue : (DateTime)reader["ReleaseDate"];
                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error occurred: {ex.Message}");
                    }
                }
            }
            return isFind;
        }

        public static bool GetDetainLicenseByDetainID(int DetainID, out int LicenseID, out DateTime DetainDate, out decimal FineFees, out int CreatedByUserID, out bool IsReleased, out DateTime ReleaseDate, out int ReleasedByUserID, out int ReleaseApplicationID)
        {
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0m;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleaseDate = DateTime.MaxValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

            bool isFind = false;
            string Query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                DetainID = reader["LicenseID"] != DBNull.Value ? Convert.ToInt32(reader["LicenseID"]) : -1;
                                DetainDate = reader["DetainDate"] != DBNull.Value ? Convert.ToDateTime(reader["DetainDate"]) : DateTime.MinValue;
                                FineFees = reader["FineFees"] != DBNull.Value ? Convert.ToDecimal(reader["FineFees"]) : 0;
                                CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["CreatedByUserID"]) : -1;
                                IsReleased = reader["IsReleased"] != DBNull.Value && Convert.ToBoolean(reader["IsReleased"]);
                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MaxValue : (DateTime)reader["ReleaseDate"];
                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
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

        public static DataTable GetAllDetainLicense()
        {
            string query = @"select * from DetainedLicenses_View order by IsReleased ,DetainID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                DataTable resultTable = new DataTable();

                dataAdapter.Fill(resultTable);

                return resultTable;
            }
        }

        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainID = -1;

            string Query = @"INSERT INTO [dbo].[DetainedLicenses]
                                   ([LicenseID]
                                   ,[DetainDate]
                                   ,[FineFees]
                                   ,[CreatedByUserID]
                                   ,[IsReleased]
                                   ,[ReleaseDate]
                                   ,[ReleasedByUserID]
                                   ,[ReleaseApplicationID])
                             VALUES
                                   (@LicenseID
                                   ,@DetainDate
                                   ,@FineFees
                                   ,@CreatedByUserID
                                   ,@IsReleased
                                   ,@ReleaseDate
                                   ,@ReleasedByUserID
                                   ,@ReleaseApplicationID)
	                        	   select SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate == DateTime.MaxValue ? (object)DBNull.Value : ReleaseDate);
                        command.Parameters.AddWithValue("@ReleasedByUserID", (ReleasedByUserID == -1) ? (object)DBNull.Value : ReleasedByUserID);
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID == -1 ? (object)DBNull.Value : ReleaseApplicationID);

                        object Result = command.ExecuteScalar();
                        if (Result != null) 
                            int.TryParse(Result.ToString(), out DetainID);
                    }
                    catch (Exception ex)
                    {
                        DetainID = -1;
                    }
                }
            }

            return DetainID;
        }

        public static bool UpdateDetain(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            string Query = @"UPDATE [dbo].[DetainedLicenses]
                               SET [LicenseID] = @LicenseID
                                  ,[DetainDate] = @DetainDate
                                  ,[FineFees] = @FineFees
                                  ,[CreatedByUserID] = @CreatedByUserID
                                  ,[IsReleased] = @IsReleased
                                  ,[ReleaseDate] = @ReleaseDate
                                  ,[ReleasedByUserID] = @ReleasedByUserID
                                  ,[ReleaseApplicationID] = @ReleaseApplicationID
                             WHERE DetainID = @DetainID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                        command.Parameters.AddWithValue("@DetainID", DetainID);

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        RowsAffected = 0;
                    }
                }
            }

            return RowsAffected > 0;
        }

        public static bool IsDetain(int LicenseID)
        {
            bool isDetain = false;

            string Query = @"select 1 from DetainedLicenses where LicenseID = @LicenseID and IsReleased = 0;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                        object result = command.ExecuteScalar();

                        if (result != null)
                            isDetain = true;
                    }
                    catch (Exception ex)
                    {
                        isDetain = false;
                    }
                }
            }
            return isDetain;
        }

        public static bool ReleaseDetainLicense(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            string Query = @"UPDATE DetainedLicenses
                            SET IsReleased = 1
                               ,ReleaseDate = @ReleaseDate
                               ,ReleasedByUserID = @ReleasedByUserID
                               ,ReleaseApplicationID = @ReleaseApplicationID
                          WHERE DetainID = @DetainID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@DetainID", DetainID);
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                        command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);

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
        
    }
}
