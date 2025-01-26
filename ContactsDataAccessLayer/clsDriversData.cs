using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer.Driver
{
    public class clsDriversData
    {

        public static bool GetDriverByDriverID(int DriverID, out int PersonID, out int CreatedByUserID, out DateTime CreatedDate)
        {
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;

            string Query = "select * from Drivers where DriverID = @DriverID;";

            bool isFind = false;
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

                            if (reader.Read())
                            {
                                isFind = true;
                                PersonID = (int)reader["PersonID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static bool GetDriverByPersonID(out int DriverID, int PersonID, out int CreatedByUserID, out DateTime CreatedDate)
        {
            DriverID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            bool isFind = false;

            string Query = "select * from Drivers where PersonID = @PersonID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFind = true;
                                DriverID = (int)reader["DriverID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFind = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFind;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int DriverID = -1;

            string Query = @"INSERT INTO Drivers
                           (PersonID
                           ,CreatedByUserID
                           ,CreatedDate)
                     VALUES
                           (@PersonID
                           ,@CreatedByUserID
                           ,@CreatedDate);
                            select SCOPE_IDENTITY();";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = PersonID;
                        command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                        command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;
                        
                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                            DriverID = insertedID;

                    }
                    catch (Exception ex)
                    {
                        DriverID = -1;
                    }
                    finally
                    {

                    }
                }
            }
            return DriverID;
        }
    
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            int rowsAffect = 0;
            string Query = @"UPDATE Drivers
                           SET PersonID = @PersonID
                              ,CreatedByUserID = @CreatedByUserID
                              ,CreatedDate = @CreatedDate
                         WHERE DriverID = @DriverID;";

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        Command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        Command.Parameters.AddWithValue("@DriverID", DriverID);

                        rowsAffect = Command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            return rowsAffect > 0;
        }

        public static DataTable GetAllDriver()
        {
            DataTable dt = new DataTable();

            string Query = "select * from Drivers_View order by FullName;";

            using (SqlConnection Connection = new SqlConnection( clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (SqlException ex) { }
                }
            }
            return dt;
        }

    }
}
