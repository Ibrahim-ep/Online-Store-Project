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
    public partial class frmItems : Form
    {
        public frmItems()
        {
            InitializeComponent();
        }

        private void _RefreshItemsList()
        {
            dgvAllItems.DataSource = clsItem.GetAllItems();

            lblNumberOfItems.Text = dgvAllItems.RowCount.ToString();
        }

        private void _SearchByID()
        {
            DataTable DT = clsItem.GetAllItems();

            string SearchText = txtSearchByItemID.Text.Trim();

            if (int.TryParse(SearchText, out int ItemID))
            {
                DT.DefaultView.RowFilter = $"ItemID = {ItemID}";
            }
            else
            {
                DT.DefaultView.RowFilter = "";
            }

            dgvAllItems.DataSource = DT;

            lblNumberOfItems.Text = dgvAllItems.RowCount.ToString();
        }

        private void txtSearchByItemID_TextChanged(object sender, EventArgs e)
        {
            _SearchByID();
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            _RefreshItemsList();
        }
    }
}
