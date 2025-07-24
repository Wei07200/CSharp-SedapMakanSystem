using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP;

namespace OOP
{
    
    public partial class frmCustomer : Form
    {
        private Profile currentUser;
        private MyOrder customerOrder;
        
        public frmCustomer()
        {
            InitializeComponent();
            customerOrder = new MyOrder();

            string userId = Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userId);

            if (currentUser != null)
            {
                lblRMValue.Text = currentUser.GetBalance().ToString("C2");
            }

            lblOrderID.Text = MyOrder.OrderID;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
          
            CustomerMenu CustomerMenu = new CustomerMenu();
            CustomerMenu.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            CustomerProfile CustomerProfile = new CustomerProfile();
            CustomerProfile.Show();
            this.Hide();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            viewOrder frm = new viewOrder();
            frm.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Close();
        }

        private void btnArrowRefund_Click(object sender, EventArgs e)
        {
            CustomerRefund frm = new CustomerRefund();
            frm.Show();
            this.Close();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            CustomerFeedback frm = new CustomerFeedback();
            frm.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void lblRMValue_Click(object sender, EventArgs e)
        {
            lblRMValue.Text = currentUser.GetBalance().ToString("C2");
        }

        private void picBase_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmViewR frm = new frmViewR();
            frm.Show();
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            CustomerTopUp cusTop = new CustomerTopUp();
            cusTop.Show();
            this.Hide();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            MyOrders Orders = new MyOrders();
            Orders.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmCustomer Dashboard = new frmCustomer();
            Dashboard.Show();
            this.Hide();
        }

        private void lblOrderID_Click(object sender, EventArgs e)
        {

        }
    }
}
