using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorDataAccessLayer
{
    public class clsOrdersDataAccess
    {
        public static bool GetOrderByID(int ID, ref int OrderNumber, ref DateTime OrderDate, ref int Price,
                                    ref string OrderStatus, ref string ShippingMethod)
        {
            bool isFount = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Orders WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    OrderNumber = (int)reader["OrderNumber"];
                    OrderDate = (DateTime)reader["OrderDate"];
                    Price = (int)reader["Price"];

                    if (reader["OrderStatus"] != DBNull.Value)
                    {
                        OrderStatus = (string)reader["OrderStatus"];
                    }
                    else
                    {
                        OrderStatus = "";
                    }

                    if (reader["ShippingMethod"] != DBNull.Value)
                    {
                        ShippingMethod = (string)reader["ShippingMethod"];
                    }
                    else
                    {
                        ShippingMethod = "";
                    }

                }
            }
            catch { }

            finally { connection.Close(); }

            return isFount;
        }

        public static int AddNewOrder(int CustomerID, int OrderNumber, DateTime OrderDate, double Price, string OrderStatus, string ShippingMethod)
        {
            int OrderID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Orders
                            (CustomerID, OrderNumber, OrderDate, Price, OrderStatus, ShippingMethod)
                            VALUES (@CustomerID, @OrderNumber, @OrderDate, @Price, @OrderStatus, @ShippingMethod)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@OrderNumber", OrderNumber);
            command.Parameters.AddWithValue("@OrderDate", OrderDate);
            command.Parameters.AddWithValue("@Price", Price);

            if (OrderStatus != "")
            {
                command.Parameters.AddWithValue("@OrderStatus", OrderStatus);
            }
            else
            {
                command.Parameters.AddWithValue("@OrderStatus", System.DBNull.Value);
            }

            if (ShippingMethod != "")
            {
                command.Parameters.AddWithValue("@ShippingMethod", ShippingMethod);
            }
            else
            {
                command.Parameters.AddWithValue("@ShippingMethod", System.DBNull.Value);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    OrderID = InsertedID;
                }
            }
            catch { }

            finally { connection.Close(); }

            return OrderID;
        }

        public static DataTable GetAllOrders()
        {
            DataTable DataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Orders";

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
