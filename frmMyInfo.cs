using OnlineStorBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class frmMyInfo : Form
    {
        private enum enCheckisUserOrCustomer { User = 0, Customer = 1 };
        enCheckisUserOrCustomer _UserOrCustomer;

        public frmMyInfo(bool isUser)
        {
            InitializeComponent();

            if (isUser)
            {
                _UserOrCustomer = enCheckisUserOrCustomer.User;
                btnExit.Visible = false;
            }
            else
            {
                _UserOrCustomer= enCheckisUserOrCustomer.Customer;
            }
        }
        
        
       
        clsCustomer Customer = Global.CurrentCustomer;

        private void frmMyInfo_Load(object sender, EventArgs e)
        {
            if (_UserOrCustomer == enCheckisUserOrCustomer.User)
            {
                lblPermissions.Visible = true; 
                lblFixedPermissionLable.Visible = true;

                clsUser User = Global.CurrentUser;

                lblID.Text = User.UserID.ToString();
                lblUserName.Text = User.UserName;
             
                lblAddress.Text = User.Address;
                lblPermissions.Text = User.Permissions.ToString();
                lblEmail.Text = User.Email;
                lblPhone.Text = User.Phone;
            }
            else
            {
                label8.Visible = true;
                label9.Visible = true;
                lblTotalExpenses.Visible = true;
                lblTotalOrders.Visible = true;

                clsCustomer Customer = Global.CurrentCustomer;

                lblID.Text = Customer.CustomerID.ToString();
                lblUserName.Text = Customer.UserName;
                lblAddress.Text = Customer.Address;
              
                lblEmail.Text = Customer.Email;
                lblPhone.Text = Customer.Phone;
                lblTotalExpenses.Text = Customer.TotalExpenses.ToString();
                lblTotalOrders.Text = Customer.TotalOrders.ToString();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
