using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class order_details : Form
    {
        public string orderID { get; set; }
        public order_details(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;

            txtOrderID.Text = orderID;

            // Load order details
            DataTable dt = OrdersClass.LoadOrderDetails(orderID);
            lbOrders.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string menuItem = row["MenuItemName"].ToString();
                string qty = row["Quantity"].ToString();
                lbOrders.Items.Add($"{menuItem} (Quantity: {qty})");
            }

            // Check status
            string status = OrdersClass.GetOrderStatus(orderID);
            btnCompleted.Visible = (status == "Cooking");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            orders orderspage = new orders();
            orderspage.Show();

        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["OOP"].ToString();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Orders SET OrderStatus = 'Completed' WHERE OrderID = @OrderID", conn);
                cmd.Parameters.AddWithValue("@OrderID", orderID);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Order marked as Completed.");
                    btnCompleted.Visible = false; // hide button
                }
                else
                {
                    MessageBox.Show("Failed to update order.");
                }
            }
        }
    }
}
