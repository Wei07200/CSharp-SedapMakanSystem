using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class CustomerRefund : Form
    {
        private Profile currentUser;
        private CustomerView customerView;
        
        public CustomerRefund()
        {
            InitializeComponent();
            customerView = new CustomerView();
            string userID = Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userID);


        }

        private void CustomerRefund_Load(object sender, EventArgs e)
        {
   
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmCustomer().Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string orderId = textBox1.Text.Trim();
            string userId = currentUser.UserID;
            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Please enter an Order ID.");
                return;
            }
            // 1. Check if the order exists and belongs to the current user
            DataTable orderDetails = customerView.GetOrderID(orderId, userId);

            if (orderDetails.Rows.Count == 0)
            {
                MessageBox.Show("Order not found or doesn't belong to this user.");
                return;
            }

            // 2. Check if a refund has already been requested for this order
            DataTable existingRefund = customerView.GetRefundByOrderID(orderId, userId);
            if (existingRefund.Rows.Count > 0)
            {
                MessageBox.Show("A refund has already been requested for this order.");
                return;
            }

            // 3. Insert new refund
            bool isInserted = customerView.InsertRefundRequest(orderId, userId);
            if (isInserted)
            {
                MessageBox.Show("Refund request submitted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to submit refund request.");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string orderId = textBox1.Text.Trim();
            string userId = currentUser.UserID;

            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Please enter an Order ID.");
                return;
            }


            DataTable orderDetails = customerView.GetOrderID(orderId, userId);

            if (orderDetails.Rows.Count > 0)
            {
                // Display the order data in the DataGridView
                dataGridView1.DataSource = orderDetails;

                // Get total amount and display in label2
                decimal total = Convert.ToDecimal(orderDetails.Rows[0]["TotalAmount"]);
                label2.Text = total.ToString("C"); // ex: 00.00"
            }
            else
            {
                MessageBox.Show("No matching order found for this user.");
                dataGridView1.DataSource = null;
                label2.Text = "0.00";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
