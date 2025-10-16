using OnlineStorDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorBusinessLayer
{
    public class clsUser : clsPerson
    {
        public enum enMode { Addnew = 0, Update = 1 }
        enMode Mode;

        public int Permissions { get; set; }
        public int UserID { get; set; }
      

        public clsUser() : base()
        {
            this.UserID = -1;
            this.Permissions = 0;
          

            Mode = enMode.Addnew;
        }
        private clsUser(int userID,string FirstName, string LastName, string phone, string Email, string Address,
                        DateTime DateOfBirth, int permissions,string Password, string UserName) 
            : base(FirstName, LastName, phone, Email, Address, DateOfBirth, Password, UserName)
        {
            Permissions = permissions;
            UserID = userID;
           
            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.FirstName, this.LastName, this.Phone, this.Email, 
                this.Address, this.DateOfBirth, this.Permissions, this.Password, this.UserName);

            return this.UserID != -1;
        }

        private bool _Update()
        {
            return clsUserDataAccess.UpdateUser(UserID, this.FirstName, this.LastName, this.Phone, this.Email,
                this.Address, this.DateOfBirth, this.Permissions,this.Password, this.UserName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                {
                    if(_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    { 
                        return false;
                    }
                }
                case enMode.Update:
                {
                    return _Update();
                    
                }
            }
            return false;
        }

        public static clsUser GetUserInfo(int ID)
        {
            string FirstName = "", LastName = "", Phone = "", Email = "", Address = "", UserName = "", Password = "";
            DateTime DateOfBirth = DateTime.MinValue;
            int Permissons = 0;

            if (clsUserDataAccess.GetUserInfoByID(ID, ref FirstName, ref LastName, ref Phone, ref Email, ref Address, ref DateOfBirth, ref Permissons,
                ref Password, ref UserName))
            {
                return new clsUser(ID, FirstName, LastName, Phone, Email, Address, DateOfBirth, Permissons, Password, UserName);
            }
            else
            {
                return null;
            }
        }

        public static clsUser GetUserInfo(string UserName, string Password)
        {
            string FirstName = "", LastName = "", Phone = "", Email = "", Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            int Permissons = 0, ID = 0;

            if (clsUserDataAccess.GetUserInfoByUserNameAndPassword(ref ID, ref FirstName, ref LastName, ref Phone, ref Email, ref Address, ref DateOfBirth, 
                ref Permissons, Password, UserName))
            {
                return new clsUser(ID, FirstName, LastName, Phone, Email, Address, DateOfBirth, Permissons, Password, UserName);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static bool DeleteUser(int ID)
        {
            return clsUserDataAccess.DeleteUser(ID);
        }
    }
}
