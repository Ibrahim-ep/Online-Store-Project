using OnlineStorBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class frmSignup : Form
    {
        public enum enMode { AddNew = 0, Update = 1};
        private enMode _Mode;

        public enum enCheckUserOrCustomer { User = 2, Customer = 3 };
        private enCheckUserOrCustomer _CheckUserOrCustomer;

        int _UserID;
        clsUser _User;

        int _CustomerID;
        clsCustomer _Customer;

        public frmSignup(int ID, bool isUser)
        {
            InitializeComponent();

            if (isUser == true)
            {
                _UserID = ID;

                _CheckUserOrCustomer = enCheckUserOrCustomer.User;

                if (_UserID == -1)
                {
                    _Mode = enMode.AddNew;
                }
                else
                {
                    _Mode = enMode.Update;
                }
            }
            else
            {
                _CustomerID = ID;
                _CheckUserOrCustomer = enCheckUserOrCustomer.Customer;

                if (_CustomerID == -1)
                {
                    _Mode = enMode.AddNew;
                }
                else
                {
                    _Mode = enMode.Update;
                }
            }

            
        }

       private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_CheckUserOrCustomer == enCheckUserOrCustomer.User)
                {
                    lblPermissions.Visible = true;
                    txtSetPermissions.Visible = true;
                    lblSignUp_Update.Text = "ADD USER";

                    _User = new clsUser();
                    return;
                }
                else
                {
                    lblSignUp_Update.Text = "SIGN UP";
                    _Customer = new clsCustomer();
                    return;
                }
            }

            lblSignUp_Update.Text = "UPDATE INFO";
            btnSignUp_Confirm.Text = "Confirm";

            if (_CheckUserOrCustomer == enCheckUserOrCustomer.User)
            {
                lblPermissions.Visible = true;
                txtSetPermissions.Visible = true;
                _User = clsUser.GetUserInfo(_UserID);

                if (_User == null)
                {
                    MessageBox.Show("User Not Found");
                    this.Close();
                }

                txtFirstName.Text = _User.FirstName;
                txtLastName.Text = _User.LastName;
                txtEmail.Text = _User.Email;
                txtPhoeNumber.Text = _User.Phone;
                txtAddress.Text = _User.Address;
                txtPassword.Text = _User.Password;
                txtSetPermissions.Text = Convert.ToString(_User.Permissions);
                txtCofirmPassword.Text = _User.Password;
                mskDateOfBirth.Text = Convert.ToString(_User.DateOfBirth);
            }
            else
            {
                lblTotalExpenses.Visible = true;
                lblTotalOrders.Visible = true;

                txtTotalExpenses.Visible = true;
                txtTotalOrders.Visible = true;

                _Customer = clsCustomer.GetCustomerInfo(_CustomerID);

                if (_Customer == null)
                {
                    MessageBox.Show("Customer Not Found");
                    this.Close();
                }

                txtFirstName.Text= _Customer.FirstName;
                txtLastName.Text= _Customer.LastName;
                txtEmail.Text= _Customer.Email;
                txtAddress.Text= _Customer.Address;
                txtPhoeNumber.Text= _Customer.Phone;
                txtPassword.Text= _Customer.Password;
                txtCofirmPassword.Text = _Customer.Password;
                mskDateOfBirth.Text = Convert.ToString(_Customer.DateOfBirth);
                txtTotalExpenses.Text = _Customer.TotalExpenses.ToString();
                txtTotalOrders.Text = _Customer.TotalOrders.ToString();

            }
        }

        private void _frmCustomer_User_Load()
        {
            _LoadData();
        }
        
        private void btnSignUp_Confirm_Click(object sender, EventArgs e)
        {
            if (_CheckUserOrCustomer == enCheckUserOrCustomer.User)
            {

                if (txtCofirmPassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Passwords not matched");
                }
                else
                {
                    _User.FirstName = txtFirstName.Text;
                    _User.LastName = txtLastName.Text;
                    _User.Email = txtEmail.Text;
                    _User.Password = txtPassword.Text;
                    _User.Phone = txtPhoeNumber.Text;
                    _User.Address = txtAddress.Text;
                    _User.Permissions = Convert.ToInt16(txtSetPermissions.Text);
                    _User.DateOfBirth = Convert.ToDateTime(mskDateOfBirth.Text);
                    _User.UserName = txtFirstName.Text + " " + txtLastName.Text;

                    if (_User.Save())
                    {
                        MessageBox.Show("Data Saved Successfully.");
                        _Mode = enMode.Update;
                    }
                    else
                        MessageBox.Show("Error: Data is not saved successfully.");

                   
                    lblSignUp_Update.Text = "UPDATE INFO";
                }
            }
            else
            {
                if (txtCofirmPassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Passwords not matched");
                }
                else
                {
                    _Customer.FirstName = txtFirstName.Text;
                    _Customer.LastName = txtLastName.Text;
                    _Customer.Email = txtEmail.Text;
                    _Customer.Password = txtPassword.Text;
                    _Customer.Phone = txtPhoeNumber.Text;
                    _Customer.Address = txtAddress.Text;
                    _Customer.DateOfBirth = Convert.ToDateTime(mskDateOfBirth.Text);
                    if (txtTotalExpenses.Text != string.Empty)
                    {
                        _Customer.TotalExpenses = Convert.ToInt16(txtTotalExpenses.Text);
                    }
                    else
                    {
                        _Customer.TotalExpenses = 0;
                    }
                    if (txtTotalOrders.Text != string.Empty)
                    {
                        _Customer.TotalOrders = Convert.ToInt16(txtTotalOrders.Text);
                    }
                    else
                    {
                        _Customer.TotalOrders = 0;
                    }
                        _Customer.UserName = txtFirstName.Text + " " + txtLastName.Text;

                    if (_Customer.Save())
                    {
                        MessageBox.Show("Data Saved Successfully.");
                        _Mode = enMode.Update;
                    }
                    else
                        MessageBox.Show("Error: Data is not saved successfully.");

                   
                    lblSignUp_Update.Text = "UPDATE INFO";
                  
                }
            }
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {
            _frmCustomer_User_Load();
        }
    }
}
