using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorDataAccessLayer
{
    public class clsUserDataAccess
    {
        public static bool GetUserInfoByID(int ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email,
            ref string Address, ref DateTime DateOfBirth, ref int Permissions, ref string Password, ref string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                            Users.UserID,
                            Users.Permissions,
                            Person.FirstName,
                            Person.LastName,
                            Person.Phone,
                            Person.Email,
                            Person.Address,
                            Person.DateOfBirth,
                            Person.Password,
                            Person.UserName
                         FROM Users 
                         LEFT JOIN Person ON Users.PersonID = Person.PersonID 
                         WHERE Users.UserID = @UserID"; 

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                   
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];

                    if (reader["Phone"] != DBNull.Value)
                    {
                        Phone = (string)reader["Phone"];
                    }
                    else
                    {
                        Phone = "";
                    }

                    Email = (string)reader["Email"];

                    if (reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }

                    Address = (string)reader["Address"];
                    Permissions = Convert.ToInt16( reader["Permissions"]);
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex) { }

            finally { connection.Close(); }

            return isFound;
        }

        public static bool GetUserInfoByUserNameAndPassword(ref int ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email,
            ref string Address, ref DateTime DateOfBirth, ref int Permissions, string Password, string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                            Users.UserID,
                            Users.Permissions,
                            Person.FirstName,
                            Person.LastName,
                            Person.Phone,
                            Person.Email,
                            Person.Address,
                            Person.DateOfBirth,
                            Person.Password,
                            Person.UserName
                         FROM Users 
                         LEFT JOIN Person ON Users.PersonID = Person.PersonID 
                         WHERE Person.UserName = @UserName AND Person.Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    ID = (int)reader["UserID"];

                    if (reader["Phone"] != DBNull.Value)
                    {
                        Phone = (string)reader["Phone"];
                    }
                    else
                    {
                        Phone = "";
                    }

                    Email = (string)reader["Email"];

                    if (reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }

                    Address = (string)reader["Address"];
                    Permissions = Convert.ToInt16(reader["Permissions"]);
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                }
            }
            catch (Exception ex) { }

            finally { connection.Close(); }

            return isFound;
        }

        public static bool UpdateUser(int UserID, string FirstName, string LastName, string Phone, string Email,
            string Address, DateTime DateOfBirth, int Permissions, string Password, string UserName)
        {
            int rowsAffected = 0, PersonrowsAffected = 0;
            int PersonID = -1;

            string getPersonIDQuery = "SELECT PersonID FROM Users WHERE UserID = @UserID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string queryPerson = @"
                                    UPDATE Person
                                    SET 
                                        FirstName = @FirstName,
                                        LastName = @LastName,
                                        Phone = @Phone,
                                        Email = @Email,
                                        Address = @Address,
                                        DateOfBirth = @DateOfBirth,
                                        UserName = @UserName,
                                        Password = @Password
                                    WHERE PersonID = @PersonID;";

            string queryUser = @"
                                    UPDATE Users
                                    SET 
                                        Permissions = @Permissions
                                    WHERE UserID = @UserID;";

           
            SqlCommand cmdPerson = new SqlCommand(queryPerson, connection);
            SqlCommand cmdUser = new SqlCommand(queryUser, connection);
            SqlCommand cmdGetPersonID = new SqlCommand(getPersonIDQuery, connection);

            cmdGetPersonID.Parameters.AddWithValue("@UserID", UserID);
            if (true)
            {
                connection.Open();

                object result = cmdGetPersonID.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedPersonID))
                    PersonID = InsertedPersonID;

                connection.Close();
            }

            cmdPerson.Parameters.AddWithValue("@PersonID", PersonID); 
            cmdPerson.Parameters.AddWithValue("@FirstName", FirstName);
            cmdPerson.Parameters.AddWithValue("@LastName", LastName);
            cmdPerson.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(Phone) ? (object)DBNull.Value : Phone);
            cmdPerson.Parameters.AddWithValue("@Email", Email);
            cmdPerson.Parameters.AddWithValue("@Address", Address);
            cmdPerson.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmdPerson.Parameters.AddWithValue("@UserName", UserName);
            cmdPerson.Parameters.AddWithValue("@Password", Password);

           
            cmdUser.Parameters.AddWithValue("@Permissions", Permissions);
            cmdUser.Parameters.AddWithValue("@UserID", UserID); 


            try
            {
                connection.Open();

                rowsAffected = cmdUser.ExecuteNonQuery();
                PersonrowsAffected = cmdPerson.ExecuteNonQuery();
            }
            catch  { }

            finally { connection.Close(); }

            return (rowsAffected > 0);
        }

        public static int AddNewUser(string FirstName, string LastName, string Phone, string Email,
     string Address, DateTime DateOfBirth, int Permissions, string Password, string UserName)
        {
            int UserID = -1;
            int personID;

            string queryPerson = @"
        INSERT INTO Person (FirstName, LastName, Phone, Email, Address, DateOfBirth, UserName, Password)
        VALUES (@FirstName, @LastName, @Phone, @Email, @Address, @DateOfBirth, @UserName, @Password);
        SELECT SCOPE_IDENTITY();";

            string queryUser = @"
        INSERT INTO Users (Permissions, PersonID)
        VALUES (@Permissions, @PersonID);
        SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
                SqlCommand cmdPerson = new SqlCommand(queryPerson, connection);
                SqlCommand cmdUser = new SqlCommand(queryUser, connection);

                
                cmdPerson.Parameters.AddWithValue("@FirstName", FirstName);
                cmdPerson.Parameters.AddWithValue("@LastName", LastName);
                cmdPerson.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(Phone) ? (object)DBNull.Value : Phone);
                cmdPerson.Parameters.AddWithValue("@Email", Email);
                cmdPerson.Parameters.AddWithValue("@Address", Address);
                cmdPerson.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmdPerson.Parameters.AddWithValue("@UserName", UserName);
                cmdPerson.Parameters.AddWithValue("@Password", Password);

                cmdUser.Parameters.AddWithValue("@Permissions", Permissions);
                cmdUser.Parameters.Add("@PersonID", SqlDbType.Int);

                try
                {
                    connection.Open();

                    
                    object personResult = cmdPerson.ExecuteScalar();
                    if (personResult == null || !int.TryParse(personResult.ToString(), out personID))
                        throw new Exception("Failed to insert Person record.");

                    
                    cmdUser.Parameters["@PersonID"].Value = personID;

                   
                    object userResult = cmdUser.ExecuteScalar();
                    if (userResult != null && int.TryParse(userResult.ToString(), out int insertedUserID))
                        UserID = insertedUserID;
                }
                finally { connection.Close(); }
            

            return UserID;
        }


        public static bool DeleteUser(int ID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch { }

            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static DataTable GetAllUsers()
        {
            DataTable DataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =@"SELECT 
                            Users.UserID,
                            Users.Permissions,
                            Person.PersonID,
                            Person.FirstName,
                            Person.LastName,
                            Person.Phone,
                            Person.Email,
                            Person.Address,
                            Person.DateOfBirth,
                            Person.Password,
                            Person.UserName
                         FROM Users 
                         LEFT JOIN Person ON Users.PersonID = Person.PersonID"; 


            SqlCommand command = new SqlCommand(query,connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable.Load(reader);
                }

                reader.Close();
            }
            catch
            {

            }
            finally { connection.Close(); }

            return DataTable;
        }
    }
}
