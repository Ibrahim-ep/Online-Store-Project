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
    public partial class frmManageOrders : Form
    {
        public frmManageOrders()
        {
            InitializeComponent();
        }

        private void _RefreshOrdersList()
        {
            dgvAllOrders.DataSource = clsOrder.GetAllOrders();
            lblNumberOfOrders.Text = dgvAllOrders.RowCount.ToString();
        }

        private void _SearchByID()
        {
            DataTable DT = clsOrder.GetAllOrders();

            string SeachText = txtSearchByOrderID.Text.Trim();

            if (int.TryParse(SeachText, out int OrderID))
            {
                DT.DefaultView.RowFilter = $"OrderID = {OrderID}";
            }
            else
                DT.DefaultView.RowFilter = "";

            dgvAllOrders.DataSource = DT;
            lblNumberOfOrders.Text = DT.Rows.Count.ToString();
        }

        private void frmManageOrders_Load(object sender, EventArgs e)
        {
            _RefreshOrdersList();
        }

        private void txtSearchByOrderID_TextChanged(object sender, EventArgs e)
        {
            _SearchByID();
        }
    }
}
