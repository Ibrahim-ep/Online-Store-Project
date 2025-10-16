using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorBusinessLayer
{
    public  class clsPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public clsPerson()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            DateOfBirth = DateTime.MinValue;
            UserName = string.Empty;
            Password = string.Empty;
        }

        public clsPerson(string FirstName, string LastName, string Phone, string Email, string Address, DateTime DateOfBirth,

                        string Password, string UserName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
