using OnlineStorDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorBusinessLayer
{
    public class clsItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int CategoryID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        public clsItem()
        {
            ItemID = 0;
            ItemName = string.Empty;
            ItemDescription = string.Empty;
            CategoryID = 0; 
            Price = 0;
            Quantity = 0;
            ImagePath = string.Empty;
        }

        private clsItem(int ID, string Name, string Description, int CategoryID, double Price, int Quantity, string ImagePath)
        {
            this.ItemID = ID;
            this.ItemName = Name;
            this.ItemDescription = Description;
            this.CategoryID = CategoryID;
            this.Price = Price;
            this.Quantity = Quantity;
            this.ImagePath = ImagePath;
        }

        private bool _AddNew()
        {
            this.ItemID = clsItemsDataAccess.AddNewItem(this.ItemName,this.ItemDescription,this.CategoryID,this.Price,this.Quantity,this.ImagePath);

            return this.ItemID != -1;
        }

        public bool Save()
        {
            return _AddNew();
        }

        public static clsItem GetItemInfo(int ID)
        {
            string ItemName = "", ImagePath = "", ItemDescription = "";
            int CategoryID = 0, Quantity = 0;
            double Price = 0;

            if (clsItemsDataAccess.GetItemByID(ID, ref ItemName, ref ItemDescription, ref CategoryID, ref Price, ref Quantity, ref ImagePath))
            {
                return new clsItem(ID, ItemName, ItemDescription, CategoryID, Price, Quantity, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsItem GetItemInfo(string ItemName)
        {
            string ImagePath = "", ItemDescription = "";
            int CategoryID = 0, Quantity = 0, ID = 0;
            double Price = 0;

            if (clsItemsDataAccess.GetItemByName(ref ID, ItemName, ref ItemDescription, ref CategoryID, ref Price, ref Quantity, ref ImagePath))
            {
                return new clsItem(ID, ItemName, ItemDescription, CategoryID, Price, Quantity, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllItems()
        {
            return clsItemsDataAccess.GetAllItems();
        }
    }
}
