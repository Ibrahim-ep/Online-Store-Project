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
    public partial class frmItemShowCase : Form
    {
        clsItem _Item;
        public frmItemShowCase(int ItemID)
        {
            InitializeComponent();


            _Item = clsItem.GetItemInfo(ItemID);

            _LoadItemData();
        }

        private void _LoadItemData()
        {
            pictureBox1.BackgroundImage = Image.FromFile(_Item.ImagePath);

            string Description = _Item.ItemDescription;

          
            Description = Description.Replace(",", Environment.NewLine);
            

            lblDescription.Text = Description; 

            lblItemPrice.Text = _Item.Price.ToString("C");
        }

        private bool _PlaceOrder()
        {
            clsOrder order = new clsOrder();

            Random rand = new Random();

            order.Price = _Item.Price * (int)nudQuantity.Value;
            order.OrderNumber = rand.Next(1,1000000);
            order.OrderDate = DateTime.Now;

            return order.Save(Global.CurrentCustomer.CustomerID);
        }

        private void btnMakeOrder_Click(object sender, EventArgs e)
        {
            if(_PlaceOrder())
            {
                MessageBox.Show("Order Places Successfully");
            }
            else
            {
                MessageBox.Show("Somethig went wrong");
            }
        }
    }
}
