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
    public partial class frmCustomersMenu : Form
    {
        public frmCustomersMenu()
        {
            InitializeComponent();
        }

        private void btnElctronics_Click(object sender, EventArgs e)
        {
            frmShop frm = new frmShop(1);

            frm.Show();

            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmShop frm = new frmShop(3);
            frm.Show();
            this.Close();
        }

        private void btnFurniture_Click(object sender, EventArgs e)
        {
            frmShop frm = new frmShop(2);
            frm.Show();
            this.Close();
        }
    }
}
