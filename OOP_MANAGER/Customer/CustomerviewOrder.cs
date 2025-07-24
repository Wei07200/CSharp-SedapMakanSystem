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
    public partial class viewOrder : Form
    {
        private MyOrder myOrder;
        public viewOrder()
        {
            InitializeComponent();

           
            lblDisplayID.Text = MyOrder.OrderID;
            lblStatuss.Text = MyOrder.OrderStatus;
        }

        private void viewOrder_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            frmCustomer customerMenu = new frmCustomer();
            customerMenu.Show();
            this.Hide();
        }
    }
}
