using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace OOP
{
    public class chef_menu
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();

        public string ItemID { get; set; }
        public string CategoryID { get; set; }
        public string ChefID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string IsAvaiable { get; set; }

        // Construtors for chef_menu

        public chef_menu(string itemID, string categoryID, string chefID, string name, decimal price, string isAvaiable)
        {
            ItemID = itemID;
            CategoryID = categoryID;
            ChefID = chefID;
            Name = name;
            Price = price;
            this.IsAvaiable = isAvaiable;
        }

        public chef_menu()
        {
        }

        // Load all menu items from database
        public static DataTable LoadMenuItems()
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();

            using (SqlConnection menu = new SqlConnection(con))
            {
                menu.Open();

                string query = "SELECT ItemID, CategoryID, ChefID, Name, Price, IsAvailable FROM MenuItems";
                SqlDataAdapter adapter = new SqlDataAdapter(query, menu);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        // Method to add a new menu item
        public bool AddMenuItem(string itemID, string categoryID, string chefID, string name, decimal price, string isAvailable)
        {
            try
            {
                string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO MenuItems (ItemID, CategoryID, ChefID, Name, Price, IsAvailable) VALUES (@ItemID, @CategoryID, @ChefID, @Name, @Price, @IsAvailable)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@ChefID", chefID);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException sq)
            {
                Console.WriteLine("SQL Error: " + sq.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        // Method to update an existing menu item
        public bool UpdateMenuItem(string itemID, string categoryID, string chefID, string name, decimal price, string isAvailable)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE MenuItems SET ItemID = @ItemID, CategoryID = @CategoryID, ChefID = @ChefID, Name = @Name, Price = @Price, IsAvailable = @IsAvailable WHERE ItemID = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@ChefID", chefID);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException sq)
            {
                Console.WriteLine("SQL Error: " + sq.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        // Method to delete a menu item
        public bool DeleteMenuItem(string itemID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM MenuItems WHERE ItemID = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (SqlException sq)
            {
                Console.WriteLine("SQL Error: " + sq.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        // Method to filter menu items based on category ID

        public static DataTable FilterMenu(List<string> categoryID)
        {
            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                if (categoryID.Count == 0)
                {
                    string allItems = "SELECT * FROM MenuItems";
                    SqlDataAdapter allAdapter = new SqlDataAdapter(allItems, conn);
                    DataTable allTable = new DataTable();
                    allAdapter.Fill(allTable);
                    return allTable;
                }

                string query = $"SELECT * FROM MenuItems WHERE CategoryID IN ({string.Join(",", categoryID.Select((_, i) => $"@cat{i}"))})";
                SqlCommand cmd = new SqlCommand(query, conn);

                for (int i = 0; i < categoryID.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@cat{i}", categoryID[i]);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
