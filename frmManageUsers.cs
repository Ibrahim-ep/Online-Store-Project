using OnlineStorBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineStorDataAccessLayer;


namespace OnlineStore
{
    public partial class frmManageUsers : Form
    {
        int ID;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUsersList()
        {
            dgvAllUsers.DataSource = clsUser.GetAllUsers();
            lblNumberOfUsers.Text = dgvAllUsers.RowCount.ToString();
        }

        private void _SearchUserByID()
        {
            DataTable DT = clsUser.GetAllUsers();

            string searchText = txtSearchUserByID.Text.Trim();

            if (int.TryParse(searchText, out int userId))
            {
                DT.DefaultView.RowFilter = $"UserID = {userId}";
            }
            else
            {
                DT.DefaultView.RowFilter = "";
            }

            dgvAllUsers.DataSource = DT;
            lblNumberOfUsers.Text = DT.DefaultView.Count.ToString();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }

        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            bool isUser = true;

            frmSignup frm = new frmSignup((int)dgvAllUsers.CurrentRow.Cells[0].Value, isUser);

            frm.ShowDialog();

            _RefreshUsersList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this User : ["+ dgvAllUsers.CurrentRow.Cells[0].Value +"]","Are you sure?",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfuly");
                }
                else
                    MessageBox.Show("User is not deleted");

                _RefreshUsersList();
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmSignup signup = new frmSignup(-1, true);

            signup.ShowDialog();

            _RefreshUsersList();
        }

        private void txtSearchUserByID_TextChanged(object sender, EventArgs e)
        {
            _SearchUserByID();
        }

       
    }
}
