namespace OOP
{
    partial class CustomerMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMenu));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.cbBeverages = new System.Windows.Forms.CheckBox();
            this.cbLocal = new System.Windows.Forms.CheckBox();
            this.cbWest = new System.Windows.Forms.CheckBox();
            this.cbItalian = new System.Windows.Forms.CheckBox();
            this.cbVege = new System.Windows.Forms.CheckBox();
            this.logoFilter = new System.Windows.Forms.PictureBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnMyOrders = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblMenu = new System.Windows.Forms.Label();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sidePanel.SuspendLayout();
            this.gbCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.sidePanel.Controls.Add(this.lblCategory);
            this.sidePanel.Controls.Add(this.gbCategory);
            this.sidePanel.Controls.Add(this.logoFilter);
            this.sidePanel.Controls.Add(this.lblSearch);
            this.sidePanel.Controls.Add(this.picProfile);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.ForeColor = System.Drawing.Color.Black;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(339, 962);
            this.sidePanel.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Nirmala Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.White;
            this.lblCategory.Location = new System.Drawing.Point(52, 272);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(167, 32);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "By categories";
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.cbBeverages);
            this.gbCategory.Controls.Add(this.cbLocal);
            this.gbCategory.Controls.Add(this.cbWest);
            this.gbCategory.Controls.Add(this.cbItalian);
            this.gbCategory.Controls.Add(this.cbVege);
            this.gbCategory.Location = new System.Drawing.Point(45, 332);
            this.gbCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCategory.Size = new System.Drawing.Size(254, 278);
            this.gbCategory.TabIndex = 7;
            this.gbCategory.TabStop = false;
            // 
            // cbBeverages
            // 
            this.cbBeverages.AutoSize = true;
            this.cbBeverages.Font = new System.Drawing.Font("Nirmala Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBeverages.ForeColor = System.Drawing.Color.White;
            this.cbBeverages.Location = new System.Drawing.Point(14, 214);
            this.cbBeverages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBeverages.Name = "cbBeverages";
            this.cbBeverages.Size = new System.Drawing.Size(144, 35);
            this.cbBeverages.TabIndex = 4;
            this.cbBeverages.Text = "Beverages";
            this.cbBeverages.UseVisualStyleBackColor = true;
            this.cbBeverages.CheckedChanged += new System.EventHandler(this.cbBeverages_CheckedChanged);
            // 
            // cbLocal
            // 
            this.cbLocal.AutoSize = true;
            this.cbLocal.Font = new System.Drawing.Font("Nirmala Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLocal.ForeColor = System.Drawing.Color.White;
            this.cbLocal.Location = new System.Drawing.Point(14, 168);
            this.cbLocal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLocal.Name = "cbLocal";
            this.cbLocal.Size = new System.Drawing.Size(93, 35);
            this.cbLocal.TabIndex = 3;
            this.cbLocal.Text = "Local";
            this.cbLocal.UseVisualStyleBackColor = true;
            this.cbLocal.CheckedChanged += new System.EventHandler(this.cbLocal_CheckedChanged);
            // 
            // cbWest
            // 
            this.cbWest.AutoSize = true;
            this.cbWest.Font = new System.Drawing.Font("Nirmala Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWest.ForeColor = System.Drawing.Color.White;
            this.cbWest.Location = new System.Drawing.Point(14, 122);
            this.cbWest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbWest.Name = "cbWest";
            this.cbWest.Size = new System.Drawing.Size(123, 35);
            this.cbWest.TabIndex = 2;
            this.cbWest.Text = "Western";
            this.cbWest.UseVisualStyleBackColor = true;
            this.cbWest.CheckedChanged += new System.EventHandler(this.cbWest_CheckedChanged);
            // 
            // cbItalian
            // 
            this.cbItalian.AutoSize = true;
            this.cbItalian.Font = new System.Drawing.Font("Nirmala Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbItalian.ForeColor = System.Drawing.Color.White;
            this.cbItalian.Location = new System.Drawing.Point(14, 75);
            this.cbItalian.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbItalian.Name = "cbItalian";
            this.cbItalian.Size = new System.Drawing.Size(103, 35);
            this.cbItalian.TabIndex = 1;
            this.cbItalian.Text = "Italian";
            this.cbItalian.UseVisualStyleBackColor = true;
            this.cbItalian.CheckedChanged += new System.EventHandler(this.cbItalian_CheckedChanged);
            // 
            // cbVege
            // 
            this.cbVege.AutoSize = true;
            this.cbVege.Font = new System.Drawing.Font("Nirmala Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVege.ForeColor = System.Drawing.Color.White;
            this.cbVege.Location = new System.Drawing.Point(14, 29);
            this.cbVege.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbVege.Name = "cbVege";
            this.cbVege.Size = new System.Drawing.Size(150, 35);
            this.cbVege.TabIndex = 0;
            this.cbVege.Text = "Vegetarian";
            this.cbVege.UseVisualStyleBackColor = true;
            this.cbVege.CheckedChanged += new System.EventHandler(this.cbVege_CheckedChanged);
            // 
            // logoFilter
            // 
            this.logoFilter.Image = ((System.Drawing.Image)(resources.GetObject("logoFilter.Image")));
            this.logoFilter.Location = new System.Drawing.Point(45, 180);
            this.logoFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoFilter.Name = "logoFilter";
            this.logoFilter.Size = new System.Drawing.Size(60, 62);
            this.logoFilter.TabIndex = 2;
            this.logoFilter.TabStop = false;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Nirmala Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(114, 194);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(187, 32);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "SEARCH FILTER";
            // 
            // picProfile
            // 
            this.picProfile.BackColor = System.Drawing.Color.Transparent;
            this.picProfile.Image = ((System.Drawing.Image)(resources.GetObject("picProfile.Image")));
            this.picProfile.Location = new System.Drawing.Point(146, 49);
            this.picProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(60, 62);
            this.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfile.TabIndex = 0;
            this.picProfile.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.mainPanel.Controls.Add(this.btnUpdate);
            this.mainPanel.Controls.Add(this.btnLogOut);
            this.mainPanel.Controls.Add(this.btnMenu);
            this.mainPanel.Controls.Add(this.btnMyOrders);
            this.mainPanel.Controls.Add(this.btnDashboard);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(339, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1355, 157);
            this.mainPanel.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(790, 10);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(215, 142);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Profile";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(1136, 10);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(215, 142);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "LOGOUT";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(526, 5);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(243, 142);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMyOrders
            // 
            this.btnMyOrders.FlatAppearance.BorderSize = 0;
            this.btnMyOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyOrders.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyOrders.ForeColor = System.Drawing.Color.White;
            this.btnMyOrders.Location = new System.Drawing.Point(286, 5);
            this.btnMyOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMyOrders.Name = "btnMyOrders";
            this.btnMyOrders.Size = new System.Drawing.Size(232, 142);
            this.btnMyOrders.TabIndex = 1;
            this.btnMyOrders.Text = "My Orders";
            this.btnMyOrders.UseVisualStyleBackColor = true;
            this.btnMyOrders.Click += new System.EventHandler(this.btnMyOrders_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 5);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(278, 142);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.SystemColors.Window;
            this.lblMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMenu.Font = new System.Drawing.Font("Nirmala Text", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMenu.Location = new System.Drawing.Point(367, 180);
            this.lblMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(196, 81);
            this.lblMenu.TabIndex = 7;
            this.lblMenu.Text = "Menu";
            // 
            // flpMenu
            // 
            this.flpMenu.AutoScroll = true;
            this.flpMenu.BackColor = System.Drawing.Color.MidnightBlue;
            this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenu.Location = new System.Drawing.Point(370, 266);
            this.flpMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(1257, 658);
            this.flpMenu.TabIndex = 12;
            this.flpMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMenu_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OOP.Properties.Resources._base;
            this.pictureBox1.Location = new System.Drawing.Point(339, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1355, 844);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CustomerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 962);
            this.Controls.Add(this.flpMenu);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomerMenu";
            this.Text = "CustomerMenu";
            this.Load += new System.EventHandler(this.CustomerMenu_Load);
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.gbCategory.ResumeLayout(false);
            this.gbCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.PictureBox logoFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnMyOrders;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.CheckBox cbBeverages;
        private System.Windows.Forms.CheckBox cbLocal;
        private System.Windows.Forms.CheckBox cbWest;
        private System.Windows.Forms.CheckBox cbItalian;
        private System.Windows.Forms.CheckBox cbVege;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}