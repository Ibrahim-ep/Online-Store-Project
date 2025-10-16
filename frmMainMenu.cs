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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        frmMyInfo MyInfo = new frmMyInfo(true);
        frmManageUsers CustomersInfo = new frmManageUsers();
        frmItems Items = new frmItems();
        frmShop shop = new frmShop();
        frmManageOrders ManageOrders = new frmManageOrders();
        frmManageCustomers ManageCustomers = new frmManageCustomers();

        private void btnMyInfo_Click(object sender, EventArgs e)
        {
            MyInfo.MdiParent = this;
            MyInfo.StartPosition = FormStartPosition.Manual;
            MyInfo.Location = new Point(0, 0);
            MyInfo.Show();
            MyInfo.BringToFront();

        }

        private void btnShowCustomersScreen_Click(object sender, EventArgs e)
        {
            CustomersInfo.MdiParent = this;
            CustomersInfo.StartPosition = FormStartPosition.Manual;
            CustomersInfo.Location = new Point(0, 0);
            CustomersInfo.Show();
            CustomersInfo.BringToFront();
        }


        private void btnItems_Click(object sender, EventArgs e)
        {
            Items.MdiParent = this;
            Items.StartPosition = FormStartPosition.Manual;
            Items.Location = new Point(0, 0);
            Items.Show();
            Items.BringToFront();
           
        }

        private void btnManageShop_Click(object sender, EventArgs e)
        {
            shop.MdiParent = this;
            shop.StartPosition = FormStartPosition.Manual;
            shop.Location = new Point(0, 0);
            shop.Show();
            shop.BringToFront();
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            ManageOrders.MdiParent = this;
            ManageOrders.StartPosition = FormStartPosition.Manual;
            ManageOrders.Location = new Point(0, 0);
            ManageOrders.Show();
            ManageOrders.BringToFront();
        }

        private void btnManageCustomersScreen_Click(object sender, EventArgs e)
        {
            ManageCustomers.MdiParent = this;
            ManageCustomers.StartPosition = FormStartPosition.Manual;
            ManageCustomers.Location = new Point(0, 0);
            ManageCustomers.Show();
            ManageCustomers.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

            frmLoginScreen loginScreen = new frmLoginScreen();
            loginScreen.Show();
        }
    }
}
