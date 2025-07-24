using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OOP
{
    public partial class menu_add : Form
    {
        private string editingItemID = null;
        private bool isEditMode = false;

      

        public class Category
        {
            public string CategoryID { get; set; }
            public string Name { get; set; }
        }

        //Load the category combo box
        private void LoadCategoryCombo()
        {
            cbCategory.Items.Clear();
            List<Category> categories = new List<Category>
            {
                new Category { CategoryID = "C01", Name = "Vegetarian" },
                new Category { CategoryID = "C02", Name = "Italian" },
                new Category { CategoryID = "C03", Name = "Western" },
                new Category { CategoryID = "C04", Name = "Local" },
                new Category { CategoryID = "C05", Name = "Beverages" }
            };

            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryID";
        }

        //Load the availability combo box
        private void LoadAvailabilityCombo()
        {
            cbAvailability.Items.Clear();
            cbAvailability.Items.Add("Yes");
            cbAvailability.Items.Add("No");
        }

        // Load the food picture based on the item ID selected by user
        private void LoadFoodPic()
        {
            if (string.IsNullOrEmpty(editingItemID))
                return;

            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "SELECT ImagePath FROM MenuItems WHERE ItemID = @ItemID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemID", editingItemID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string relativePath = reader["ImagePath"].ToString();
                    string fullPath = Path.Combine(Application.StartupPath, relativePath);

                    if (File.Exists(fullPath))
                        picFood.Image = Image.FromFile(fullPath);
                    else
                        picFood.Image = Properties.Resources.Default;
                }
            }
        }


        public menu_add(string itemID, string categoryID, string chefID, string name, decimal price, string isAvailable)
        {
            InitializeComponent();
            LoadCategoryCombo();
            LoadAvailabilityCombo();
            editingItemID = itemID;
            isEditMode = !string.IsNullOrEmpty(itemID);
            LoadFoodPic();

            // Fill the fields with existing values
            txtItemID.Text = itemID;
            cbCategory.SelectedItem = categoryID; 
            txtChefID.Text = chefID;
            txtName.Text = name;
            txtPrice.Text = price.ToString();
            cbAvailability.SelectedItem = isAvailable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuManagement menu= new MenuManagement();
            menu.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtItemID.Text) ||
                string.IsNullOrWhiteSpace(txtChefID.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            chef_menu menu = new chef_menu();

            if (isEditMode)
            {
                bool updated = menu.UpdateMenuItem(
                    txtItemID.Text,
                    cbCategory.SelectedValue.ToString(),
                    txtChefID.Text,
                    txtName.Text,
                    decimal.Parse(txtPrice.Text),
                    cbAvailability.SelectedItem.ToString());

                MessageBox.Show(updated ? "Menu item updated successfully." : "Failed to update menu item.");
            }
            else
            {
                bool added = menu.AddMenuItem(
                    txtItemID.Text,
                    cbCategory.SelectedValue.ToString(),
                    txtChefID.Text,
                    txtName.Text,
                    decimal.Parse(txtPrice.Text),
                    cbAvailability.SelectedItem.ToString());

                MessageBox.Show(added ? "Menu item added successfully." : "Failed to add menu item.");
            }

            this.Close();
        }

        public void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
