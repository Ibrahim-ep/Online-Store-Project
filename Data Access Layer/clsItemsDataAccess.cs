using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace OnlineStorDataAccessLayer
{
    public class clsItemsDataAccess
    {
        public static bool GetItemByID(int ID, ref string ItemName, ref string ItemDescription, ref int CategoryID, ref double Price
            , ref int Quantity, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Items WHERE ItemID = @ItemID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    ItemName = (string)reader["ItemName"];

                    if (reader["Description"] != DBNull.Value)
                    {
                        ItemDescription = (string)reader["Description"];
                    }
                    else
                    {
                        ItemDescription = "";
                    }

                    CategoryID = (int)reader["CategoryID"];
                    Price = Convert.ToDouble(reader["Price"]);
                    Quantity = Convert.ToInt16(reader["Quantity"]);

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch
            {
                
            }

            finally { connection.Close(); }

            return isFound;
        }

        public static bool GetItemByName(ref int ID, string ItemName, ref string ItemDescription, ref int CategoryID, ref double Price
           , ref int Quantity, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Items WHERE ItemName = @ItemName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemName", ItemName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    ID = (int)reader["ItemID"];

                    if (reader["Description"] != DBNull.Value)
                    {
                        ItemDescription = (string)reader["Description"];
                    }
                    else
                    {
                        ItemDescription = "";
                    }

                    CategoryID = (int)reader["CategoryID"];
                    Price = Convert.ToDouble(reader["Price"]);
                    Quantity = Convert.ToInt16(reader["Quantity"]);

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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


        public static int AddNewItem(string ItemName, string ItemDescription, int CategoryID, double Price
            , int Quantity, string ImagePath)
        {
            int ItemID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert into Items SET
                            (ItemName, ItemDescription, CategoryID, Price
                            , Quantity, ImagePath)
                            Values (@ItemName, @ItemDescription, @CategoryID, @Price
                            , @Quantity, @ImagePath)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemName", ItemName);
            if (ItemDescription != "")
            {
                command.Parameters.AddWithValue("@ItemDescription", ItemDescription);
            }
            else
            {
                command.Parameters.AddWithValue("@ItemDescription", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Quantity", Quantity);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ItemID = InsertedID;
                }
            }
            catch  { }

            finally { connection.Close(); }

            return ItemID;
        }

        public static DataTable GetAllItems()
        {
            DataTable DataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From Items";

            SqlCommand command = new SqlCommand(query, connection);

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

            catch { }

            finally { connection.Close(); }

            return DataTable;
        }
    }
}
