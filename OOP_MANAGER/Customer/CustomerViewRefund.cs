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
    public partial class frmViewR: Form
    {
        private Profile currentUser;
        public frmViewR()
        {
            InitializeComponent();
            string userID = Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userID);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmC_Load(object sender, EventArgs e)
        {
 

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmCustomer().Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string orderId = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(orderId))
            {
                MessageBox.Show("Please enter a valid Order ID.");
                return;
            }

            CustomerView customerView = new CustomerView();
            DataTable refundData = customerView.GetRefundByOrderID(orderId,currentUser.UserID);

            if (refundData.Rows.Count > 0)
            {
                dataGridView1.DataSource = refundData;
            }
            else
            {
                MessageBox.Show("No refund record found for this Order ID.");
                dataGridView1.DataSource = null;
            }
        }

        private void lblRefund_Click(object sender, EventArgs e)
        {

        }
    }
}
