using OnlineStorDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorBusinessLayer
{
    public class clsOrder
    {
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingMethod { get; set; }

        public clsOrder()
        {
            this.OrderID = -1;
            this.OrderNumber = 0;
            this.OrderDate = DateTime.MinValue;
            this.Price = 0;
            this.OrderStatus = string.Empty;
            this.ShippingMethod = string.Empty;
        }

        private clsOrder(int orderID, int orderNumber, DateTime orderDate, int price, string orderStatus, string shippingMethod)
        {
            OrderID = orderID;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Price = price;
            OrderStatus = orderStatus;
            ShippingMethod = shippingMethod;
        }

        private bool _AddNew(int CustomerID)
        {
            this.OrderID = clsOrdersDataAccess.AddNewOrder(CustomerID,this.OrderNumber,this.OrderDate,this.Price,this.OrderStatus,this.ShippingMethod);

            return this.OrderID != -1;
        }

        public bool AddNewOrder(int CustomerID) 
            {
                return _AddNew(CustomerID);
            }

        public static clsOrder GetOrderInfo(int OrderID)
        {
            int OrderNumber = 0, Price = 0;
            DateTime OrderDate = DateTime.MinValue;
            string OrderStatus = string.Empty, ShipingMethod = string.Empty;

            if (clsOrdersDataAccess.GetOrderByID(OrderID, ref OrderNumber, ref OrderDate, ref Price, ref OrderStatus, ref ShipingMethod))
            {
                return new clsOrder(OrderID, OrderNumber, OrderDate, Price, OrderStatus, ShipingMethod);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllOrders()
        {
            return clsOrdersDataAccess.GetAllOrders();
        }

        public bool Save(int CustomerID)
        {
            return _AddNew(CustomerID);
        }
    }
}
