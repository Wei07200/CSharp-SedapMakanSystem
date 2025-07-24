using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP;

namespace OOP
{
    public partial class MyOrders : Form
    {
        private Profile currentUser;
        private MyOrder customerOrder;

        public MyOrders()
        {
            InitializeComponent();

            string userID = Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userID);

            LoadCart();
        }

        private void LoadCart()
        {
            dgvMyOrders.Rows.Clear();
            int no = 1;
            foreach (var item in MyOrder.OrderManage.Cart)
            {
                dgvMyOrders.Rows.Add(no++, item.Name, item.Quantity, item.Price, item.Amount);
            }
            lblRM.Text = $"RM {MyOrder.OrderManage.GetTotal():F2}";
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {

            if (MyOrder.OrderManage.Cart.Count == 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }

            string customerId = currentUser.UserID;

            OrderProcessor processor = new OrderProcessor();
            string orderId = processor.PlaceOrder(customerId);

            if (!string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Order placed successfully!");
                MyOrder.OrderManage.ClearCart();
                LoadCart(); // Refresh cart

                MyOrder.OrderID = orderId;
                MyOrder.OrderStatus = "In Progress";


            }
            else
            {
                MessageBox.Show("Order failed");
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmCustomer dashboard = new frmCustomer();
            dashboard.Show();
            this.Close();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CustomerMenu menu = new CustomerMenu();
            menu.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void picBase_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyOrder.OrderManage.ClearCart();
            LoadCart(); // Refresh cart
        }
    }
}
