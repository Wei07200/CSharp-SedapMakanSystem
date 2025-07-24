namespace OOP
{
    partial class MenuManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuManagement));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.cbBeverages = new System.Windows.Forms.CheckBox();
            this.cbLocal = new System.Windows.Forms.CheckBox();
            this.cbWest = new System.Windows.Forms.CheckBox();
            this.cbItalian = new System.Windows.Forms.CheckBox();
            this.cbVege = new System.Windows.Forms.CheckBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoFilter = new System.Windows.Forms.PictureBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelbtns = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblMenuManagement = new System.Windows.Forms.Label();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.picBase = new System.Windows.Forms.PictureBox();
            this.sidePanel.SuspendLayout();
            this.gbCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelbtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBase)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.sidePanel.Controls.Add(this.gbCategory);
            this.sidePanel.Controls.Add(this.lblCategory);
            this.sidePanel.Controls.Add(this.panel1);
            this.sidePanel.Controls.Add(this.logoFilter);
            this.sidePanel.Controls.Add(this.lblSearch);
            this.sidePanel.Controls.Add(this.picProfile);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.ForeColor = System.Drawing.Color.Black;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(381, 1145);
            this.sidePanel.TabIndex = 1;
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.cbBeverages);
            this.gbCategory.Controls.Add(this.cbLocal);
            this.gbCategory.Controls.Add(this.cbWest);
            this.gbCategory.Controls.Add(this.cbItalian);
            this.gbCategory.Controls.Add(this.cbVege);
            this.gbCategory.Location = new System.Drawing.Point(45, 329);
            this.gbCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCategory.Size = new System.Drawing.Size(254, 278);
            this.gbCategory.TabIndex = 12;
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
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Nirmala Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.White;
            this.lblCategory.Location = new System.Drawing.Point(39, 275);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(167, 32);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "By categories";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(381, 151);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1506, 994);
            this.panel1.TabIndex = 10;
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
            this.mainPanel.Controls.Add(this.btnLogOut);
            this.mainPanel.Controls.Add(this.btnOrders);
            this.mainPanel.Controls.Add(this.btnMenu);
            this.mainPanel.Controls.Add(this.btnDashboard);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(381, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1337, 152);
            this.mainPanel.TabIndex = 2;
            // 
            // btnLogOut
            // 
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(1079, 5);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(266, 142);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "LOGOUT";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.Color.White;
            this.btnOrders.Location = new System.Drawing.Point(688, 5);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(266, 142);
            this.btnOrders.TabIndex = 2;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(274, 5);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(405, 142);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Menu Management";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
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
            this.btnDashboard.Size = new System.Drawing.Size(266, 142);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelbtns);
            this.panel2.Controls.Add(this.lblMenuManagement);
            this.panel2.Controls.Add(this.dgvMenu);
            this.panel2.Controls.Add(this.picBase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(381, 152);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1337, 993);
            this.panel2.TabIndex = 3;
            // 
            // panelbtns
            // 
            this.panelbtns.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelbtns.Controls.Add(this.btnAdd);
            this.panelbtns.Controls.Add(this.btnDelete);
            this.panelbtns.Controls.Add(this.btnEdit);
            this.panelbtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbtns.Location = new System.Drawing.Point(0, 896);
            this.panelbtns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelbtns.Name = "panelbtns";
            this.panelbtns.Size = new System.Drawing.Size(1337, 97);
            this.panelbtns.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnAdd.Location = new System.Drawing.Point(1119, 30);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 48);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.FlatAppearance.BorderSize = 3;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnDelete.Location = new System.Drawing.Point(929, 31);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 46);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnEdit.FlatAppearance.BorderSize = 3;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnEdit.Location = new System.Drawing.Point(747, 33);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 46);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblMenuManagement
            // 
            this.lblMenuManagement.AutoSize = true;
            this.lblMenuManagement.Font = new System.Drawing.Font("Nirmala Text", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuManagement.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMenuManagement.Location = new System.Drawing.Point(62, 29);
            this.lblMenuManagement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuManagement.Name = "lblMenuManagement";
            this.lblMenuManagement.Size = new System.Drawing.Size(585, 81);
            this.lblMenuManagement.TabIndex = 5;
            this.lblMenuManagement.Text = "Menu Management";
            // 
            // dgvMenu
            // 
            this.dgvMenu.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Location = new System.Drawing.Point(75, 194);
            this.dgvMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersWidth = 62;
            this.dgvMenu.Size = new System.Drawing.Size(1233, 515);
            this.dgvMenu.TabIndex = 2;
            this.dgvMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellContentClick);
            // 
            // picBase
            // 
            this.picBase.BackColor = System.Drawing.Color.Transparent;
            this.picBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBase.Image = ((System.Drawing.Image)(resources.GetObject("picBase.Image")));
            this.picBase.Location = new System.Drawing.Point(0, 0);
            this.picBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picBase.Name = "picBase";
            this.picBase.Size = new System.Drawing.Size(1337, 993);
            this.picBase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBase.TabIndex = 1;
            this.picBase.TabStop = false;
            // 
            // MenuManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1718, 1145);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MenuManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Management";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.gbCategory.ResumeLayout(false);
            this.gbCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelbtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox logoFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.CheckBox cbBeverages;
        private System.Windows.Forms.CheckBox cbLocal;
        private System.Windows.Forms.CheckBox cbWest;
        private System.Windows.Forms.CheckBox cbItalian;
        private System.Windows.Forms.CheckBox cbVege;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picBase;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.Label lblMenuManagement;
        private System.Windows.Forms.Panel panelbtns;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
    }
}