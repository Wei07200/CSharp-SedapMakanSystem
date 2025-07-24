using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace OOP
{
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
            CustomerMenuLoader.LoadAvailableMenuItems(flpMenu, OnAddItemClicked);
        }

        public class MenuItemInfo
        {
            public string ItemID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        //method to apply filters based on selected categories
        private void ApplyCategoryFilters()
        {
            List<string> selectedCategories = new List<string>();

            if (cbVege.Checked) selectedCategories.Add("C01");
            if (cbItalian.Checked) selectedCategories.Add("C02");
            if (cbWest.Checked) selectedCategories.Add("C03");
            if (cbLocal.Checked) selectedCategories.Add("C04");
            if (cbBeverages.Checked) selectedCategories.Add("C05");

            CustomerMenuLoader.LoadFilteredMenuItems(flpMenu, selectedCategories, OnAddItemClicked);
        }

        private void OnAddItemClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is MenuItemInfo info)
            {
                MyOrder.OrderManage.AddToCart(info.ItemID, info.Name, info.Price);
                MessageBox.Show($"Added: {info.Name} (RM {info.Price:F2})");
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmCustomer dashboard = new frmCustomer();
            dashboard.Show();
            this.Close();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            MyOrders myOrders = new MyOrders();
            myOrders.Show();
            this.Close();
        }

        private void cbVege_CheckedChanged(object sender, EventArgs e)
        {
            ApplyCategoryFilters();
        }

        private void cbItalian_CheckedChanged(object sender, EventArgs e)
        {
            ApplyCategoryFilters();
        }

        private void cbWest_CheckedChanged(object sender, EventArgs e)
        {
            ApplyCategoryFilters();
        }

        private void cbLocal_CheckedChanged(object sender, EventArgs e)
        {
            ApplyCategoryFilters();
        }

        private void cbBeverages_CheckedChanged(object sender, EventArgs e)
        {
            ApplyCategoryFilters();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerProfile profile = new CustomerProfile();
            profile.Show();
            this.Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void CustomerMenu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flpMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
