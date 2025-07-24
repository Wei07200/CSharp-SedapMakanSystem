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
using static OOP.menu_add;
using System.Xml.Linq;

namespace OOP
{
    public partial class MenuManagement : Form
    {
        private bool isEditMode = false;
        public MenuManagement()
        {
            InitializeComponent();
            dgvMenu.DataSource = chef_menu.LoadMenuItems();
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

            dgvMenu.DataSource = chef_menu.FilterMenu(selectedCategories);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            menu_add add = new menu_add("", "", "", "", 0, "")
            {

            };
            add.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditMode = true;

            if (dgvMenu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMenu.SelectedRows[0];

                string itemID = selectedRow.Cells["ItemID"].Value.ToString();
                string categoryID = selectedRow.Cells["CategoryID"].Value.ToString();
                string chefID = selectedRow.Cells["ChefID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                string isAvailable = selectedRow.Cells["IsAvailable"].Value.ToString();

                menu_add editForm = new menu_add(itemID, categoryID, chefID, name, price, isAvailable);
                editForm.ShowDialog();

                dgvMenu.DataSource = chef_menu.LoadMenuItems();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (dgvMenu.SelectedRows.Count > 0)
            {
                string itemID = dgvMenu.SelectedRows[0].Cells["ItemID"].Value.ToString();

                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    chef_menu menu = new chef_menu();
                    bool isDeleted = menu.DeleteMenuItem(itemID);

                    if (isDeleted)
                    {
                        MessageBox.Show("Menu item deleted successfully.");
                        dgvMenu.DataSource = chef_menu.LoadMenuItems();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete menu item.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            menu_add Add = new menu_add("", "", "", "", 0, "");
            Add.ShowDialog();
            dgvMenu.DataSource = chef_menu.LoadMenuItems();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmChef dashboard = new frmChef();
            dashboard.Show();
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuManagement menu = new MenuManagement();
            menu.Show();
            this.Close();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            orders orders = new orders();
            orders.Show();
            this.Close();
        }

        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
