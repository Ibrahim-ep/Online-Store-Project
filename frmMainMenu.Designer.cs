namespace OnlineStore
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Guna2GradientButton btnMyInfo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            Guna.UI2.WinForms.Guna2GradientButton btnManageItems;
            Guna.UI2.WinForms.Guna2GradientButton btnManageShop;
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnManageOrders = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblWelcom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnManageUsers = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnManageCustomersScreen = new Guna.UI2.WinForms.Guna2GradientButton();
            btnMyInfo = new Guna.UI2.WinForms.Guna2GradientButton();
            btnManageItems = new Guna.UI2.WinForms.Guna2GradientButton();
            btnManageShop = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMyInfo
            // 
            btnMyInfo.Animated = true;
            btnMyInfo.AutoRoundedCorners = true;
            btnMyInfo.BackColor = System.Drawing.Color.Transparent;
            btnMyInfo.BorderRadius = 22;
            btnMyInfo.CheckedState.Parent = btnMyInfo;
            btnMyInfo.CustomImages.Parent = btnMyInfo;
            btnMyInfo.FillColor = System.Drawing.Color.DodgerBlue;
            btnMyInfo.FillColor2 = System.Drawing.Color.LightSteelBlue;
            btnMyInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnMyInfo.ForeColor = System.Drawing.Color.White;
            btnMyInfo.HoverState.Parent = btnMyInfo;
            btnMyInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnMyInfo.Image")));
            btnMyInfo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            btnMyInfo.Location = new System.Drawing.Point(12, 78);
            btnMyInfo.Name = "btnMyInfo";
            btnMyInfo.ShadowDecoration.Parent = btnMyInfo;
            btnMyInfo.Size = new System.Drawing.Size(140, 46);
            btnMyInfo.TabIndex = 4;
            btnMyInfo.Text = "My Info";
            btnMyInfo.Click += new System.EventHandler(this.btnMyInfo_Click);
            // 
            // btnManageItems
            // 
            btnManageItems.Animated = true;
            btnManageItems.AutoRoundedCorners = true;
            btnManageItems.BackColor = System.Drawing.Color.Transparent;
            btnManageItems.BorderRadius = 22;
            btnManageItems.CheckedState.Parent = btnManageItems;
            btnManageItems.CustomImages.Parent = btnManageItems;
            btnManageItems.FillColor = System.Drawing.Color.DodgerBlue;
            btnManageItems.FillColor2 = System.Drawing.Color.LightSteelBlue;
            btnManageItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnManageItems.ForeColor = System.Drawing.Color.White;
            btnManageItems.HoverState.Parent = btnManageItems;
            btnManageItems.Image = ((System.Drawing.Image)(resources.GetObject("btnManageItems.Image")));
            btnManageItems.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            btnManageItems.ImageSize = new System.Drawing.Size(22, 22);
            btnManageItems.Location = new System.Drawing.Point(12, 182);
            btnManageItems.Name = "btnManageItems";
            btnManageItems.ShadowDecoration.Parent = btnManageItems;
            btnManageItems.Size = new System.Drawing.Size(140, 46);
            btnManageItems.TabIndex = 3;
            btnManageItems.Text = "Manage Items";
            btnManageItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnManageShop
            // 
            btnManageShop.Animated = true;
            btnManageShop.AutoRoundedCorners = true;
            btnManageShop.BackColor = System.Drawing.Color.Transparent;
            btnManageShop.BorderRadius = 22;
            btnManageShop.CheckedState.Parent = btnManageShop;
            btnManageShop.CustomImages.Parent = btnManageShop;
            btnManageShop.FillColor = System.Drawing.Color.DodgerBlue;
            btnManageShop.FillColor2 = System.Drawing.Color.LightSteelBlue;
            btnManageShop.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnManageShop.ForeColor = System.Drawing.Color.White;
            btnManageShop.HoverState.Parent = btnManageShop;
            btnManageShop.Image = ((System.Drawing.Image)(resources.GetObject("btnManageShop.Image")));
            btnManageShop.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            btnManageShop.Location = new System.Drawing.Point(12, 130);
            btnManageShop.Name = "btnManageShop";
            btnManageShop.ShadowDecoration.Parent = btnManageShop;
            btnManageShop.Size = new System.Drawing.Size(140, 46);
            btnManageShop.TabIndex = 2;
            btnManageShop.Text = "Manage Shop";
            btnManageShop.Click += new System.EventHandler(this.btnManageShop_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2GradientPanel1.Controls.Add(this.btnManageCustomersScreen);
            this.guna2GradientPanel1.Controls.Add(this.btnLogout);
            this.guna2GradientPanel1.Controls.Add(this.btnManageOrders);
            this.guna2GradientPanel1.Controls.Add(this.lblWelcom);
            this.guna2GradientPanel1.Controls.Add(btnMyInfo);
            this.guna2GradientPanel1.Controls.Add(btnManageItems);
            this.guna2GradientPanel1.Controls.Add(btnManageShop);
            this.guna2GradientPanel1.Controls.Add(this.btnManageUsers);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.CornflowerBlue;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.LightBlue;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(191, 437);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = global::OnlineStore.Properties.Resources.Gemini_Generated_Image_yh2us2yh2us2yh2u;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.CheckedState.Parent = this.btnLogout;
            this.btnLogout.HoverState.Parent = this.btnLogout;
            this.btnLogout.Location = new System.Drawing.Point(142, 385);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.PressedState.Parent = this.btnLogout;
            this.btnLogout.Size = new System.Drawing.Size(46, 49);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageOrders
            // 
            this.btnManageOrders.Animated = true;
            this.btnManageOrders.AutoRoundedCorners = true;
            this.btnManageOrders.BackColor = System.Drawing.Color.Transparent;
            this.btnManageOrders.BorderRadius = 22;
            this.btnManageOrders.CheckedState.Parent = this.btnManageOrders;
            this.btnManageOrders.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManageOrders.CustomImages.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btnManageOrders.CustomImages.Parent = this.btnManageOrders;
            this.btnManageOrders.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnManageOrders.FillColor2 = System.Drawing.Color.LightSteelBlue;
            this.btnManageOrders.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnManageOrders.ForeColor = System.Drawing.Color.White;
            this.btnManageOrders.HoverState.Parent = this.btnManageOrders;
            this.btnManageOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnManageOrders.Image")));
            this.btnManageOrders.Location = new System.Drawing.Point(12, 286);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.ShadowDecoration.Parent = this.btnManageOrders;
            this.btnManageOrders.Size = new System.Drawing.Size(140, 46);
            this.btnManageOrders.TabIndex = 5;
            this.btnManageOrders.Text = "Manage Orders";
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);
            // 
            // lblWelcom
            // 
            this.lblWelcom.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcom.Font = new System.Drawing.Font("Ink Free", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcom.ForeColor = System.Drawing.Color.White;
            this.lblWelcom.Location = new System.Drawing.Point(26, 12);
            this.lblWelcom.Name = "lblWelcom";
            this.lblWelcom.Size = new System.Drawing.Size(111, 45);
            this.lblWelcom.TabIndex = 2;
            this.lblWelcom.Text = "Welcom\r\n";
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Animated = true;
            this.btnManageUsers.AutoRoundedCorners = true;
            this.btnManageUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnManageUsers.BorderRadius = 22;
            this.btnManageUsers.CheckedState.Parent = this.btnManageUsers;
            this.btnManageUsers.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManageUsers.CustomImages.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btnManageUsers.CustomImages.Parent = this.btnManageUsers;
            this.btnManageUsers.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnManageUsers.FillColor2 = System.Drawing.Color.LightSteelBlue;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.HoverState.Parent = this.btnManageUsers;
            this.btnManageUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Image")));
            this.btnManageUsers.Location = new System.Drawing.Point(12, 234);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.ShadowDecoration.Parent = this.btnManageUsers;
            this.btnManageUsers.Size = new System.Drawing.Size(140, 46);
            this.btnManageUsers.TabIndex = 2;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.Click += new System.EventHandler(this.btnShowCustomersScreen_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this.guna2GradientPanel1;
            // 
            // btnManageCustomersScreen
            // 
            this.btnManageCustomersScreen.Animated = true;
            this.btnManageCustomersScreen.AutoRoundedCorners = true;
            this.btnManageCustomersScreen.BackColor = System.Drawing.Color.Transparent;
            this.btnManageCustomersScreen.BorderRadius = 22;
            this.btnManageCustomersScreen.CheckedState.Parent = this.btnManageCustomersScreen;
            this.btnManageCustomersScreen.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnManageCustomersScreen.CustomImages.ImageOffset = new System.Drawing.Point(-3, 0);
            this.btnManageCustomersScreen.CustomImages.Parent = this.btnManageCustomersScreen;
            this.btnManageCustomersScreen.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnManageCustomersScreen.FillColor2 = System.Drawing.Color.LightSteelBlue;
            this.btnManageCustomersScreen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnManageCustomersScreen.ForeColor = System.Drawing.Color.White;
            this.btnManageCustomersScreen.HoverState.Parent = this.btnManageCustomersScreen;
            this.btnManageCustomersScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnManageCustomersScreen.Image")));
            this.btnManageCustomersScreen.Location = new System.Drawing.Point(12, 338);
            this.btnManageCustomersScreen.Name = "btnManageCustomersScreen";
            this.btnManageCustomersScreen.ShadowDecoration.Parent = this.btnManageCustomersScreen;
            this.btnManageCustomersScreen.Size = new System.Drawing.Size(140, 46);
            this.btnManageCustomersScreen.TabIndex = 6;
            this.btnManageCustomersScreen.Text = "Manage Customers";
            this.btnManageCustomersScreen.Click += new System.EventHandler(this.btnManageCustomersScreen_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(954, 437);
            this.Controls.Add(this.guna2GradientPanel1);
            this.IsMdiContainer = true;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientButton btnManageUsers;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcom;
        private Guna.UI2.WinForms.Guna2GradientButton btnManageOrders;
        private Guna.UI2.WinForms.Guna2ImageButton btnLogout;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientButton btnManageCustomersScreen;
    }
}