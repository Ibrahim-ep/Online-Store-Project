using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineStore
{
    public partial class frmLoginScreen : Form
    {
        private string UserName;
        private string Password;
        private byte FailedLoginCount = 3;
        public frmLoginScreen()
        {
            InitializeComponent();
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {


            clsUser User;
            clsCustomer Customer = null;

            UserName = txtUserName.Text;
            Password = txtPassword.Text;

            User = clsUser.GetUserInfo(UserName, Password);


            if (FailedLoginCount != 0)
            {

                if (User != null)
                {
                    Global.CurrentUser = User;
                    frmMainMenu frm = new frmMainMenu();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    Customer = clsCustomer.GetCustomerInfo(UserName, Password);

                    if (Customer != null)
                    {
                        Global.CurrentCustomer = Customer;

                        frmCustomersMenu frm = new frmCustomersMenu();
                        frm.Show();
                        this.Hide();
                    }
                }

                if ((User == null && Customer == null) && FailedLoginCount != 0)
                {
                    FailedLoginCount--;

                    lblWrongUserNamePasswordMessage.Visible = true;
                    lblRemainingAttemptsCount.Visible = true;
                    lblRemainingAttemptsCount.Text = Convert.ToString(FailedLoginCount);

                    if (FailedLoginCount == 0)
                    {
                        btnLogin.Enabled = false;
                        lblWrongUserNamePasswordMessage.Text = "Account Locked Try Agin Later";
                        lblRemainingAttemptsCount.Visible = false;
                    }
                }
            }

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
           
                frmSignup signup = new frmSignup(-1, false);
                signup.ShowDialog();
            
           
        }
    }
}
