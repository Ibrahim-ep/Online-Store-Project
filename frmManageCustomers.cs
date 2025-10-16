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
    public partial class frmManageCustomers : Form
    {
        public frmManageCustomers()
        {
            InitializeComponent();
        }

        private void _RefreshCustomersList()
        {
            dgvAllCustomers.DataSource = clsCustomer.GetAllCustomers();
            lblNumberOfCustomers.Text = dgvAllCustomers.RowCount.ToString();
        }

        private void _SearchByID()
        {
            DataTable DT = clsCustomer.GetAllCustomers();

            string SearchText = txtSearchUserByID.Text.Trim();

            if (int.TryParse(SearchText, out int ID))
            {
                DT.DefaultView.RowFilter = $"CustomerID = {ID}";
            }
            else
            {
                DT.DefaultView.RowFilter = "";
            }

            dgvAllCustomers.DataSource = DT;
            lblNumberOfCustomers.Text = dgvAllCustomers.RowCount.ToString();
        }

        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            _RefreshCustomersList();
        }

        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            bool isUser = false;

            frmSignup signup = new frmSignup((int)dgvAllCustomers.CurrentRow.Cells[0].Value, isUser);

            signup.ShowDialog();

            _RefreshCustomersList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this Customer : [" + dgvAllCustomers.CurrentRow.Cells[0].Value + "]", "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsCustomer.DeleteCustomer((int)dgvAllCustomers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Customer Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Some thig went wrong");
                }
                _RefreshCustomersList();
            }
        }

        private void txtSearchUserByID_TextChanged(object sender, EventArgs e)
        {
            _SearchByID();
        }
    }
}
