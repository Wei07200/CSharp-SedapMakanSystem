using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class orders : Form
    {

        public orders()
        {
            InitializeComponent();
            OrdersClass orders = new OrdersClass();
            dgvCooking.DataSource = OrdersClass.LoadCookingOrders();
            dgvCompleted.DataSource = OrdersClass.LoadCompletedOrders();
            dgvCancelled.DataSource = OrdersClass.LoadCancelledOrders();
        }

        private void orders_Load(object sender, EventArgs e)
        {
        }

        private void tabCooking_Click(object sender, EventArgs e)
        {
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvCooking.SelectedRows.Count > 0)
            {
                string orderId = dgvCooking.SelectedRows[0].Cells["OrderID"].Value.ToString();
                order_details detailsFrm = new order_details(orderId);
                detailsFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmChef dashboard = new frmChef();
            dashboard.Show();
            this.Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuManagement menu = new MenuManagement();
            menu.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            orders orders = new orders();
            orders.Show();
            this.Hide();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvCooking.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCooking.SelectedRows[0];
                string orderId = selectedRow.Cells["OrderID"].Value.ToString();

                bool updated = OrdersClass.UpdateOrderStatus(orderId, "Completed");

                if (updated)
                {
                    MessageBox.Show("Order marked as completed.");
                    // Refresh all grids
                    dgvCooking.DataSource = OrdersClass.LoadCookingOrders();
                    dgvCompleted.DataSource = OrdersClass.LoadCompletedOrders();
                    dgvCancelled.DataSource = OrdersClass.LoadCancelledOrders(); 
                }
                else
                {
                    MessageBox.Show("Failed to update order status.");
                }
            }
            else
            {
                MessageBox.Show("Please select an order to complete.");
            }
        }

        private void btnDetailsCompleted_Click(object sender, EventArgs e)
        {
            if (dgvCompleted.SelectedRows.Count > 0)
            {
                string orderId = dgvCompleted.SelectedRows[0].Cells["OrderID"].Value.ToString();
                order_details detailsFrm = new order_details(orderId);
                detailsFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }

        private void btnDetailsCancelled_Click(object sender, EventArgs e)
        {
            if (dgvCancelled.SelectedRows.Count > 0)
            {
                string orderId = dgvCancelled.SelectedRows[0].Cells["OrderID"].Value.ToString();
                order_details detailsFrm = new order_details(orderId);
                detailsFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }
    }
}
