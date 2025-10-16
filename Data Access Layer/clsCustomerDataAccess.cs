using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorDataAccessLayer
{
    public class clsCustomerDataAccess
    {
        public static bool GetCustomerByID(int ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email,
                                            ref string Address, ref DateTime DateOfBirth, ref string Password, 
                                            ref string UserName, ref int TotalExpanses, ref int TotalOrders )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                            Customers.CustomerID,
                            Customers.TotalExpenses,
                            Customers.TotalOrders,
                            Person.FirstName,
                            Person.LastName,
                            Person.Phone,
                            Person.Email,
                            Person.Address,
                            Person.DateOfBirth,
                            Person.Password,
                            Person.UserName
                         FROM Customers 
                         LEFT JOIN Person ON Customers.PersonID = Person.PersonID 
                         WHERE Customers.CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@CustomerID", ID);

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
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    TotalExpanses = (int)reader["TotalExpenses"];
                    TotalOrders = (int)reader["TotalOrders"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch { }

            finally { connection.Close(); }

            return isFound;
        }

        public static bool GetCustomerByUserNameAndPassword(ref int ID, ref string FirstName, ref string LastName, ref string Phone, ref string Email,
                                            ref string Address, ref DateTime DateOfBirth, string Password,
                                            string UserName, ref int TotalExpanses, ref int TotalOrders)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                            Customers.CustomerID,
                            Customers.TotalExpenses,
                            Customers.TotalOrders,
                            Person.FirstName,
                            Person.LastName,
                            Person.Phone,
                            Person.Email,
                            Person.Address,
                            Person.DateOfBirth,
                            Person.Password,
                            Person.UserName
                         FROM Customers 
                         LEFT JOIN Person ON Customers.PersonID = Person.PersonID 
                         WHERE Person.UserName = @UserName AND Person.Password = @Password;";

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

                    ID = (int)reader["CustomerID"];

                    if (reader["Phone"] != DBNull.Value)
                    {
                        Phone = (string)reader["Phone"];
                    }
                    else
                    {
                        Phone = "";
                    }

                    Email = (string)reader["Email"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    TotalExpanses = (int)reader["TotalExpenses"];
                    TotalOrders = (int)reader["TotalOrders"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
         

            finally { connection.Close(); }

            return isFound;
        }

        public static bool UpdateCustomer(int CustomerID, string FirstName, string LastName, string Phone, string Email, string Address, DateTime DateOfBirth,
                                            string Password, string UserName, int TotalExpenses, int TotalOrders)
        {
            int PersonRowsAffected = 0, CustomerRowsAffected = 0;
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string GetPersonIDquery = "SELECT PersonID from Customers WHERE Customers.CustomerID = @CustomerID";

            string Personquery = @" UPDATE Person SET 
                                        FirstName = @FirstName,
                                        LastName = @LastName,
                                        Phone = @Phone,
                                        Email = @Email,
                                        Address = @Address,
                                        DateOfBirth = @DateOfBirth,
                                        UserName = @UserName,
                                        Password = @Password
                                    WHERE PersonID = @PersonID;";

            string Customerquery = @"UPDATE Customers SET
                                        TotalExpenses = @TotalExpenses,
                                        TotalOrders = @TotalOrders
                                        WHERE Customers.CustomerID = @CustomerID";

            SqlCommand cmdPerson = new SqlCommand(Personquery, connection);
            SqlCommand cmdCustomer = new SqlCommand(Customerquery, connection);
            SqlCommand cmdGetPersonID = new SqlCommand(GetPersonIDquery, connection);

            cmdGetPersonID.Parameters.AddWithValue("@CustomerID", CustomerID);

            try 
            {
                connection.Open();

                object result = cmdGetPersonID.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedPersonID))
                    PersonID = InsertedPersonID;

            

                cmdPerson.Parameters.AddWithValue("@PersonID", PersonID);
                cmdPerson.Parameters.AddWithValue("@FirstName", FirstName);
                cmdPerson.Parameters.AddWithValue("@LastName", LastName);
                cmdPerson.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(Phone) ? (object)DBNull.Value : Phone);
                cmdPerson.Parameters.AddWithValue("@Email", Email);
                cmdPerson.Parameters.AddWithValue("@Address", Address);
                cmdPerson.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmdPerson.Parameters.AddWithValue("@UserName", UserName);
                cmdPerson.Parameters.AddWithValue("@Password", Password);

                cmdCustomer.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmdCustomer.Parameters.AddWithValue("@TotalExpenses", TotalExpenses);
                cmdCustomer.Parameters.AddWithValue("@TotalOrders", TotalOrders);


                PersonRowsAffected = cmdPerson.ExecuteNonQuery();

                CustomerRowsAffected = cmdCustomer.ExecuteNonQuery();
            }
         
            finally { connection.Close(); }

            return (PersonRowsAffected > 0 && CustomerRowsAffected > 0);

        }

        public static int AddCustomer(string FirstName, string LastName, string Phone, string Email, string Address, DateTime DateOfBirth,
                                            string Password, string UserName, int TotalExpenses = 0, int TotalOrders = 0)
        {
            int CustomerID = -1, PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string queryPerson = @"INSERT INTO Person
                            (FirstName, LastName, Phone, Email,Address, DateOfBirth,
                                            Password, UserName)
                            Values (@FirstName, @LastName, @Phone, @Email, @Address, @DateOfBirth,
                                            @Password, @UserName)
                            SELECT SCOPE_IDENTITY();";

            string queryCustomer = @"INSERT INTO Customers 
                                    (TotalExpenses, TotalOrders, PersonID)
                                    VALUES (@TotalExpenses, @TotalOrders, @PersonID)
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand cmdPerson = new SqlCommand(queryPerson, connection);
            SqlCommand cmdCustomer = new SqlCommand(queryCustomer, connection);

            cmdPerson.Parameters.AddWithValue("@FirstName", FirstName);
            cmdPerson.Parameters.AddWithValue("@LastName", LastName);

            if (Phone != string.Empty)
            {
                cmdPerson.Parameters.AddWithValue("@Phone", Phone);
            }
            else
            {
                cmdPerson.Parameters.AddWithValue("@Phone", System.DBNull.Value);
            }

            cmdPerson.Parameters.AddWithValue("@Email", Email);
            cmdPerson.Parameters.AddWithValue("@Address", Address);
            cmdPerson.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmdPerson.Parameters.AddWithValue("@Password", Password);
            cmdPerson.Parameters.AddWithValue("@UserName", UserName);

            cmdCustomer.Parameters.AddWithValue("@TotalExpenses", TotalExpenses);
            cmdCustomer.Parameters.AddWithValue("@TotalOrders", TotalOrders);
            cmdCustomer.Parameters.Add("@PersonID", SqlDbType.Int);

            try
            {
                connection.Open();

                object PersonResult = cmdPerson.ExecuteScalar();
             
                if (PersonResult != null && int.TryParse(PersonResult.ToString(), out int InsertedPersonID)) 
                {
                    PersonID = InsertedPersonID;
                }

                cmdCustomer.Parameters["@PersonID"].Value = PersonID;

                object CustomerResult = cmdCustomer.ExecuteScalar();

                if (CustomerResult != null && int.TryParse(CustomerResult.ToString(), out int InsertedCustomerID))
                {
                    CustomerID = InsertedCustomerID;
                }
            }

            finally { connection.Close(); }

            return CustomerID;
        }

        public static bool DeleteCustomer(int ID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete FROM Customers WHERE CustomerID = @CustomerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch { }

            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static DataTable GetAllCustomers()
        {
            DataTable DataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                            Customers.CustomerID,
                            Customers.TotalExpenses,
                            Customers.TotalOrders,
                            Person.FirstName,
                            Person.LastName,
                            Person.Phone,
                            Person.Email,
                            Person.Address,
                            Person.DateOfBirth,
                            Person.Password,
                            Person.UserName
                         FROM Customers 
                         LEFT JOIN Person ON Customers.PersonID = Person.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    DataTable.Load(reader);
                }

                reader.Close();
            }
            catch {}

            finally { connection.Close(); }

            return DataTable;
        }
    }
}
