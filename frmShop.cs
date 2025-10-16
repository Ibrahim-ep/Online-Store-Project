using OnlineStorBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class frmShop : Form
    {
        enum enCategories { Elctronics = 1, Furnitures = 2, Clothes = 3}
        enCategories _Category;
        public frmShop()
        {
            InitializeComponent();

            btnLogout.Visible = false;
        }

        public frmShop(int CategoryID)
        {
            InitializeComponent();

            if (CategoryID == 1)
            {
                _Category = enCategories.Elctronics;
            }
            else if (CategoryID == 2)
            {
                _Category = enCategories.Furnitures;
            }

            else
            {
                _Category = enCategories.Clothes;
            }

            btnLogout.Visible = true;
        }

        private void _LoadItems(int selectedCategory)
        {

            DataTable ItemsDataTable = clsItem.GetAllItems();

            DataRow[] filteredRows = ItemsDataTable.Select($"CategoryID = '{selectedCategory}'");

            if (selectedCategory == (int)enCategories.Elctronics)
            {
                lblCategory.Text = "Elctronic Devices";
            }
            else if (selectedCategory == (int)enCategories.Furnitures)
            {
                lblCategory.Text = "Furnitures";
            }
            else if (selectedCategory == ( int)enCategories.Clothes)
            {
                lblCategory.Text = "Clothes";
            }
            else
            {
                lblCategory.Text = "Categories";
            }

                Button[] buttons = new Button[]
                {
                button1, button2, button3, button4,
                button5, button6, button7
                };

            Label[] labels = new Label[]
            {
                lblItem1, lblItem2, lblItem3, lblItem4, lblItem5, lblItem6, lblItem7
            };
            

            foreach (var btn in buttons)
            {
                btn.BackgroundImage = null;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }

            for (int i = 0; i < buttons.Length && i < filteredRows.Length; i++)
            {
                string imagePath = filteredRows[i]["ImagePath"].ToString();
                string itemID = filteredRows[i]["ItemID"].ToString();
                string itemName = filteredRows[i]["ItemName"].ToString();

                if (File.Exists(imagePath))
                {
                    buttons[i].BackgroundImage = Image.FromFile(imagePath);
                    buttons[i].Tag = itemID;
                    buttons[i].BackgroundImageLayout = ImageLayout.Stretch;
                    labels[i].Text = itemName;
                    
                }
            }

        }

        private void frmShop_Load(object sender, EventArgs e)
        {
            _LoadItems(Convert.ToInt16(_Category));
        }

        private void elctronicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Category = enCategories.Elctronics;

            _LoadItems((int)_Category);
        }

        private void furnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Category = enCategories.Furnitures;

            _LoadItems((int)_Category);
        }

        private void clothesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Category = enCategories.Clothes;

            _LoadItems((int)_Category);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLoginScreen loginScreen = new frmLoginScreen();
            loginScreen.ShowDialog();
        }

        private void btnMyInfo_Click(object sender, EventArgs e)
        {
            frmMyInfo myInfo = new frmMyInfo(false);

            myInfo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmItemShowCase frm = new frmItemShowCase(Convert.ToInt16(button1.Tag));
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmItemShowCase frm = new frmItemShowCase(Convert.ToInt16(button2.Tag));
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmItemShowCase frm = new frmItemShowCase(Convert.ToInt16(button3.Tag));
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmItemShowCase frm = new frmItemShowCase(Convert.ToInt16(button4.Tag));
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmItemShowCase frm = new frmItemShowCase(Convert.ToInt16(button5.Tag));
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmItemShowCase frm = new frmItemShowCase(Convert.ToInt16(button6.Tag));
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmItemShowCase frm = new frmItemShowCase(Convert.ToInt16(button7.Tag));
            frm.Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();

            frmLoginScreen frmLoginScreen = new frmLoginScreen();
            frmLoginScreen.Show();

        }
    }
}
