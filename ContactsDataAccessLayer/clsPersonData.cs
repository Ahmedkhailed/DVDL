using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContactsDataAccessLayer
{
    public class clsPersonData
    {

        public static bool GetPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gendor,
            ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFind = false;

            string Query = "select * from People where PersonID = @PersonID;";

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
                                NationalNo = (string)reader["NationalNo"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = (reader["ThirdName"] != DBNull.Value) ? (string)reader["ThirdName"] : "";
                                LastName = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = (short)reader["Gendor"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                Email = (reader["Email"] != DBNull.Value) ? (string)reader["Email"] : "";
                                NationalityCountryID = (int)reader["NationalityCountryID"];
                                ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : ImagePath = "";

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

        public static bool GetPersonByNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gendor,
                   ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = "select * from People where NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFind = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (short)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFind = false;
            }
            finally
            {
                connection.Close();
            }

            return isFind;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, (select case when Gendor = 0 then 'Male' when Gendor = 1 then 'Female' else 'Unkown' End ) as Gendor, People.DateOfBirth, Countries.CountryName, People.Phone, People.Email
                            FROM     People INNER JOIN
                            				  Countries ON People.NationalityCountryID = Countries.CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeletePersonByID(int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"DELETE FROM People
                                WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static bool UpdatePerson(int PersonID,  string NationalNo,  string FirstName,  string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth, short Gendor,
             string Address,  string Phone,  string Email,  int NationalityCountryID,  string ImagePath)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"UPDATE People
                           SET NationalNo = @NationalNo,
                               FirstName = @FirstName,
                               SecondName = @SecondName, 
                               ThirdName = @ThirdName,
                               LastName = @LastName,
                               DateOfBirth = @DateOfBirth,
                               Gendor = @Gendor,
                               Address = @Address,
                               Phone = @Phone,
                               Email = @Email,
                               NationalityCountryID = @NationalityCountryID, 
                               ImagePath = @ImagePath
                         WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("ImagePath", System.DBNull.Value);

            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex0)
            {

            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, short Gendor,
             string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
             
            string Query = @"INSERT INTO People
                                  (NationalNo
                                  ,FirstName
                                  ,SecondName
                                  ,ThirdName
                                  ,LastName
                                  ,DateOfBirth
                                  ,Gendor
                                  ,Address
                                  ,Phone
                                  ,Email
                                  ,NationalityCountryID
                                  ,ImagePath)
                            VALUES
                                  (@NationalNo
                                  ,@FirstName
                                  ,@SecondName
                                  ,@ThirdName
                                  ,@LastName
                                  ,@DateOfBirth
                                  ,@Gendor
                                  ,@Address
                                  ,@Phone
                                  ,@Email
                                  ,@NationalityCountryID
								  ,@ImagePath);
                            select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("ImagePath", System.DBNull.Value);

            try
            {
                Connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }

            }
            catch (Exception ex)
            {
                PersonID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }

        public static bool IsPersonExists(int PersonID)
        {
            bool isExists = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"select found = 1 from People where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                isExists = Reader.HasRows;

                Reader.Close();
            }
            catch (Exception ex0)
            {

            }
            finally
            {
                Connection.Close();
            }

            return isExists;
        }

        public static bool IsPersonExists(string NationalNo)
        {
            bool isExists = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = "select found = 1 from People where NationalNo = @NationalNo;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                using (SqlDataReader reader = Command.ExecuteReader())
                {
                    isExists = reader.HasRows;
                }
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return isExists;
        }

    }
}
