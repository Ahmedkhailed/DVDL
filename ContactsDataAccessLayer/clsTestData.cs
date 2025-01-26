using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public class clsTestData
    {
        public static bool GetTestInfoByID(int TestID, out int TestAppointmentID, out bool TestResult, out string Notes, out int CreatedByUserID)
        {
            bool isFind = false;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = null;
            CreatedByUserID = -1;

            string Query = @"select * from Tests where TestID =	@TestID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@TestID", TestID);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFind = true;
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];
                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFind = false;
                    }
                    finally
                    { }

                    return isFind;
                }
            }
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int ApplicantPersonID, int LicenseClassID, int TestTypeID, out int TestID, out int TestAppointmentID, out bool TestResult, out string Notes, out int CreatedByUserID)
        {
            bool isFind = false;
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = null;
            CreatedByUserID = -1;

            string Query = @"SELECT TOP (1) Tests.*
                            FROM     Tests INNER JOIN
                                              TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID INNER JOIN
                                              LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN
                                              Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            WHERE  (Applications.ApplicantPersonID = @ApplicantPersonID) AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID) AND (TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY Tests.TestID DESC;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFind = true;
                                TestID = (int)reader["TestID"];
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];
                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFind = false;
                    }
                    finally
                    { }

                    return isFind;
                }
            }
        }

        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();

            string query = "select * from Tests;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            return dt;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            string Query = @"INSERT INTO Tests
                           ([TestAppointmentID]
                           ,[TestResult]
                           ,[Notes]
                           ,[CreatedByUserID])
                     VALUES
                           (@TestAppointmentID
                           ,@TestResult
                           ,@Notes
                           ,@CreatedByUserID);

                           UPDATE TestAppointments
                              SET IsLocked = 1
                            WHERE TestAppointmentID = @TestAppointmentID;
                            select SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID); 
                    if (string.IsNullOrEmpty(Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);

                    object Result = command.ExecuteScalar();

                    if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                    {
                        TestID = insertedID;
                    }

                }
            }
            return TestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;

            string Query = @"UPDATE Tests
                              SET TestAppointmentID = @TestAppointmentID 
                                 ,TestResult = @TestResult 
                                 ,Notes = @Notes 
                                 ,CreatedByUserID = @CreatedByUserID 
                            WHERE TestID = @TestID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult); command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@TestID", TestID);

                    try
                    {
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        rowsAffected = 0;
                    }
                }
            }
            return rowsAffected > 0;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            string Query = @"SELECT COUNT(Tests.TestID) AS PassedTestCount
                            FROM     Tests INNER JOIN
                                              TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            WHERE  (TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) AND (Tests.TestResult = 1);";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        object Result = command.ExecuteScalar();

                        if (Result != null && byte.TryParse(Result.ToString(), out byte insetTestCount))
                        {
                            PassedTestCount = insetTestCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        PassedTestCount = 0;
                    }
                }
            }
            return PassedTestCount;
        }

    }
}
