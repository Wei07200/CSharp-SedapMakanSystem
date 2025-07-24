namespace OOP
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnMyOrders = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel_orders = new System.Windows.Forms.Panel();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblMyOrders = new System.Windows.Forms.Label();
            this.panel_eWallet = new System.Windows.Forms.Panel();
            this.btnTopUp = new System.Windows.Forms.Button();
            this.lblRMValue = new System.Windows.Forms.Label();
            this.lblRM = new System.Windows.Forms.Label();
            this.lblWallet = new System.Windows.Forms.Label();
            this.panel_refund = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnArrowRefund = new System.Windows.Forms.Button();
            this.lblRefund2 = new System.Windows.Forms.Label();
            this.lblRefund = new System.Windows.Forms.Label();
            this.panel_feedback = new System.Windows.Forms.Panel();
            this.lblYour = new System.Windows.Forms.Label();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.lblHelpus = new System.Windows.Forms.Label();
            this.picBase = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel_orders.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_eWallet.SuspendLayout();
            this.panel_refund.SuspendLayout();
            this.panel_feedback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBase)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.sidePanel.Controls.Add(this.picProfile);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.ForeColor = System.Drawing.Color.Black;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(232, 805);
            this.sidePanel.TabIndex = 1;
            // 
            // picProfile
            // 
            this.picProfile.BackColor = System.Drawing.Color.Transparent;
            this.picProfile.Image = ((System.Drawing.Image)(resources.GetObject("picProfile.Image")));
            this.picProfile.Location = new System.Drawing.Point(74, 55);
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
            this.mainPanel.Location = new System.Drawing.Point(232, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1046, 137);
            this.mainPanel.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(682, 0);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(172, 132);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Profile";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Nirmala Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(864, 0);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(180, 132);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Nirmala Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(470, 0);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(237, 132);
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
            this.btnMyOrders.Location = new System.Drawing.Point(231, 0);
            this.btnMyOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMyOrders.Name = "btnMyOrders";
            this.btnMyOrders.Size = new System.Drawing.Size(250, 129);
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
            this.btnDashboard.Location = new System.Drawing.Point(8, 0);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(214, 132);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel_orders
            // 
            this.panel_orders.BackColor = System.Drawing.Color.MintCream;
            this.panel_orders.Controls.Add(this.panel2);
            this.panel_orders.Controls.Add(this.lblMyOrders);
            this.panel_orders.Location = new System.Drawing.Point(252, 308);
            this.panel_orders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel_orders.Name = "panel_orders";
            this.panel_orders.Size = new System.Drawing.Size(597, 303);
            this.panel_orders.TabIndex = 5;
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnViewOrder.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnViewOrder.FlatAppearance.BorderSize = 2;
            this.btnViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrder.Font = new System.Drawing.Font("Nirmala Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOrder.Location = new System.Drawing.Point(450, 23);
            this.btnViewOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(129, 35);
            this.btnViewOrder.TabIndex = 7;
            this.btnViewOrder.Text = "View Order";
            this.btnViewOrder.UseVisualStyleBackColor = false;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOrderID);
            this.panel2.Controls.Add(this.btnViewOrder);
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 71);
            this.panel2.TabIndex = 6;
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Nirmala Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblOrderID.Location = new System.Drawing.Point(36, 23);
            this.lblOrderID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(113, 32);
            this.lblOrderID.TabIndex = 5;
            this.lblOrderID.Text = "Order ID";
            this.lblOrderID.Click += new System.EventHandler(this.lblOrderID_Click);
            // 
            // lblMyOrders
            // 
            this.lblMyOrders.AutoSize = true;
            this.lblMyOrders.Font = new System.Drawing.Font("Nirmala Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyOrders.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMyOrders.Location = new System.Drawing.Point(18, 18);
            this.lblMyOrders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMyOrders.Name = "lblMyOrders";
            this.lblMyOrders.Size = new System.Drawing.Size(195, 48);
            this.lblMyOrders.TabIndex = 4;
            this.lblMyOrders.Text = "My Orders";
            // 
            // panel_eWallet
            // 
            this.panel_eWallet.BackColor = System.Drawing.Color.MintCream;
            this.panel_eWallet.Controls.Add(this.btnTopUp);
            this.panel_eWallet.Controls.Add(this.lblRMValue);
            this.panel_eWallet.Controls.Add(this.lblRM);
            this.panel_eWallet.Controls.Add(this.lblWallet);
            this.panel_eWallet.Location = new System.Drawing.Point(867, 308);
            this.panel_eWallet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel_eWallet.Name = "panel_eWallet";
            this.panel_eWallet.Size = new System.Drawing.Size(398, 298);
            this.panel_eWallet.TabIndex = 6;
            // 
            // btnTopUp
            // 
            this.btnTopUp.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTopUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopUp.Font = new System.Drawing.Font("Nirmala Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopUp.ForeColor = System.Drawing.Color.White;
            this.btnTopUp.Image = ((System.Drawing.Image)(resources.GetObject("btnTopUp.Image")));
            this.btnTopUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopUp.Location = new System.Drawing.Point(168, 198);
            this.btnTopUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(208, 80);
            this.btnTopUp.TabIndex = 11;
            this.btnTopUp.Text = "             Top Up";
            this.btnTopUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopUp.UseVisualStyleBackColor = false;
            this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
            // 
            // lblRMValue
            // 
            this.lblRMValue.AutoSize = true;
            this.lblRMValue.Font = new System.Drawing.Font("Nirmala Text", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMValue.ForeColor = System.Drawing.Color.Black;
            this.lblRMValue.Location = new System.Drawing.Point(88, 89);
            this.lblRMValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRMValue.Name = "lblRMValue";
            this.lblRMValue.Size = new System.Drawing.Size(107, 55);
            this.lblRMValue.TabIndex = 10;
            this.lblRMValue.Text = "0.00";
            this.lblRMValue.Click += new System.EventHandler(this.lblRMValue_Click);
            // 
            // lblRM
            // 
            this.lblRM.AutoSize = true;
            this.lblRM.Font = new System.Drawing.Font("Nirmala Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRM.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRM.Location = new System.Drawing.Point(28, 89);
            this.lblRM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRM.Name = "lblRM";
            this.lblRM.Size = new System.Drawing.Size(50, 32);
            this.lblRM.TabIndex = 9;
            this.lblRM.Text = "RM";
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Font = new System.Drawing.Font("Nirmala Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWallet.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblWallet.Location = new System.Drawing.Point(16, 14);
            this.lblWallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(147, 48);
            this.lblWallet.TabIndex = 5;
            this.lblWallet.Text = "EWallet";
            this.lblWallet.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel_refund
            // 
            this.panel_refund.BackColor = System.Drawing.Color.MintCream;
            this.panel_refund.Controls.Add(this.button1);
            this.panel_refund.Controls.Add(this.btnArrowRefund);
            this.panel_refund.Controls.Add(this.lblRefund2);
            this.panel_refund.Controls.Add(this.lblRefund);
            this.panel_refund.Location = new System.Drawing.Point(248, 622);
            this.panel_refund.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel_refund.Name = "panel_refund";
            this.panel_refund.Size = new System.Drawing.Size(602, 154);
            this.panel_refund.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala Text Semilight", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(429, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 48);
            this.button1.TabIndex = 13;
            this.button1.Text = "View Refund status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnArrowRefund
            // 
            this.btnArrowRefund.BackColor = System.Drawing.Color.Transparent;
            this.btnArrowRefund.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnArrowRefund.FlatAppearance.BorderSize = 0;
            this.btnArrowRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowRefund.Font = new System.Drawing.Font("Nirmala Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrowRefund.ForeColor = System.Drawing.Color.White;
            this.btnArrowRefund.Image = ((System.Drawing.Image)(resources.GetObject("btnArrowRefund.Image")));
            this.btnArrowRefund.Location = new System.Drawing.Point(303, 58);
            this.btnArrowRefund.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnArrowRefund.Name = "btnArrowRefund";
            this.btnArrowRefund.Size = new System.Drawing.Size(74, 68);
            this.btnArrowRefund.TabIndex = 12;
            this.btnArrowRefund.UseVisualStyleBackColor = false;
            this.btnArrowRefund.Click += new System.EventHandler(this.btnArrowRefund_Click);
            // 
            // lblRefund2
            // 
            this.lblRefund2.AutoSize = true;
            this.lblRefund2.Font = new System.Drawing.Font("Nirmala Text", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefund2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRefund2.Location = new System.Drawing.Point(20, 72);
            this.lblRefund2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRefund2.Name = "lblRefund2";
            this.lblRefund2.Size = new System.Drawing.Size(254, 36);
            this.lblRefund2.TabIndex = 7;
            this.lblRefund2.Text = "Request refund now!\r\n";
            // 
            // lblRefund
            // 
            this.lblRefund.AutoSize = true;
            this.lblRefund.Font = new System.Drawing.Font("Nirmala Text", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefund.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRefund.Location = new System.Drawing.Point(18, 9);
            this.lblRefund.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRefund.Name = "lblRefund";
            this.lblRefund.Size = new System.Drawing.Size(469, 45);
            this.lblRefund.TabIndex = 6;
            this.lblRefund.Text = "Not satisfied with your order?";
            // 
            // panel_feedback
            // 
            this.panel_feedback.BackColor = System.Drawing.Color.MintCream;
            this.panel_feedback.Controls.Add(this.lblYour);
            this.panel_feedback.Controls.Add(this.btnFeedback);
            this.panel_feedback.Controls.Add(this.lblHelpus);
            this.panel_feedback.Location = new System.Drawing.Point(867, 622);
            this.panel_feedback.Name = "panel_feedback";
            this.panel_feedback.Size = new System.Drawing.Size(398, 154);
            this.panel_feedback.TabIndex = 12;
            // 
            // lblYour
            // 
            this.lblYour.AutoSize = true;
            this.lblYour.Font = new System.Drawing.Font("Nirmala Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYour.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblYour.Location = new System.Drawing.Point(12, 72);
            this.lblYour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYour.Name = "lblYour";
            this.lblYour.Size = new System.Drawing.Size(201, 56);
            this.lblYour.TabIndex = 13;
            this.lblYour.Text = "Your feedback means \r\na lot to us.\r\n";
            // 
            // btnFeedback
            // 
            this.btnFeedback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFeedback.BackgroundImage")));
            this.btnFeedback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFeedback.FlatAppearance.BorderSize = 0;
            this.btnFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedback.Location = new System.Drawing.Point(273, 12);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(116, 126);
            this.btnFeedback.TabIndex = 14;
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // lblHelpus
            // 
            this.lblHelpus.AutoSize = true;
            this.lblHelpus.Font = new System.Drawing.Font("Nirmala Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpus.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblHelpus.Location = new System.Drawing.Point(10, 26);
            this.lblHelpus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelpus.Name = "lblHelpus";
            this.lblHelpus.Size = new System.Drawing.Size(258, 38);
            this.lblHelpus.TabIndex = 13;
            this.lblHelpus.Text = "Help us improved!";
            // 
            // picBase
            // 
            this.picBase.BackColor = System.Drawing.Color.Transparent;
            this.picBase.Image = ((System.Drawing.Image)(resources.GetObject("picBase.Image")));
            this.picBase.Location = new System.Drawing.Point(232, 138);
            this.picBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picBase.Name = "picBase";
            this.picBase.Size = new System.Drawing.Size(1046, 698);
            this.picBase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBase.TabIndex = 3;
            this.picBase.TabStop = false;
            this.picBase.Click += new System.EventHandler(this.picBase_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(252, 178);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 108);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala Text", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(18, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 74);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dashboard";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 805);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_feedback);
            this.Controls.Add(this.panel_refund);
            this.Controls.Add(this.panel_eWallet);
            this.Controls.Add(this.panel_orders);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.picBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDashboard";
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.panel_orders.ResumeLayout(false);
            this.panel_orders.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_eWallet.ResumeLayout(false);
            this.panel_eWallet.PerformLayout();
            this.panel_refund.ResumeLayout(false);
            this.panel_refund.PerformLayout();
            this.panel_feedback.ResumeLayout(false);
            this.panel_feedback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBase)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnMyOrders;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.PictureBox picBase;
        private System.Windows.Forms.Panel panel_orders;
        private System.Windows.Forms.Panel panel_eWallet;
        private System.Windows.Forms.Panel panel_refund;
        private System.Windows.Forms.Label lblMyOrders;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.Label lblRefund;
        private System.Windows.Forms.Label lblRefund2;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.Button btnTopUp;
        private System.Windows.Forms.Label lblRMValue;
        private System.Windows.Forms.Label lblRM;
        private System.Windows.Forms.Button btnArrowRefund;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel_feedback;
        private System.Windows.Forms.Label lblYour;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Label lblHelpus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}