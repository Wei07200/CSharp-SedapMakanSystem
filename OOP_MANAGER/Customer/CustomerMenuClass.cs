using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OOP.CustomerMenu;

namespace OOP
{
    public class CustomerMenuLoader
    {
        public static void LoadAvailableMenuItems(FlowLayoutPanel container, EventHandler onAddClick)
        {
            container.Controls.Clear();

            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "SELECT ItemID, Name, Price, ImagePath FROM MenuItems WHERE IsAvailable = 'Yes'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string relativePath = reader["ImagePath"].ToString(); 
                    string fullPath = Path.Combine(Application.StartupPath, relativePath);
                    string itemId = reader["ItemID"].ToString();
                    string name = reader["Name"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);

                    Panel itemPanel = new Panel
                    {
                        Width = 180,
                        Height = 200,
                        BackColor = Color.MintCream,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = itemId // store the ID for later
                    };

                    Label lblName = new Label
                    {
                        Text = name,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 21,
                        Location = new Point(12, 174),
                        Font = new Font("Nirmala Text", 12)
                    };

                    Label lblPrice = new Label
                    {
                        Text = $"RM {price:F2}",
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 21,
                        Location = new Point(12, 195),
                        Font = new Font("Nirmala Text", 12, FontStyle.Bold)
                    };

                    Button btnAdd = new Button
                    {
                        Width = 35,
                        Height = 35,
                        FlatStyle = FlatStyle.Flat,
                        Image = Properties.Resources.Logo_for_buttons, 
                        Location = new Point(119, 118),
                        BackColor = Color.Transparent,
                        FlatAppearance = { BorderSize = 0 },
                        Cursor = Cursors.Hand,
                        Tag = itemId,
                        Dock = DockStyle.Bottom
                    };
                    btnAdd.Click += (s, e) =>
                    {
                        MyOrder.OrderManage.AddToCart(itemId, name, price);
                        MessageBox.Show($"{name} added to cart!");
                    };
                    itemPanel.Controls.Add(btnAdd);

                    // Layout
                    itemPanel.Controls.Add(btnAdd);
                    itemPanel.Controls.Add(lblPrice);
                    itemPanel.Controls.Add(lblName);


                    PictureBox picture = new PictureBox
                    {
                        Height = 150,
                        Width = 150,
                        Dock = DockStyle.None,
                        Location = new Point(15,14),
                        SizeMode = PictureBoxSizeMode.Zoom 
                    };

                    if (File.Exists(fullPath))
                        picture.Image = Image.FromFile(fullPath);
                    else
                        picture.Image = Properties.Resources.Default;

                    itemPanel.Controls.Add(picture);
                    container.Controls.Add(itemPanel);
                }
            }
        }

        public static void LoadFilteredMenuItems(FlowLayoutPanel container, List<string> categoryFilter, EventHandler onAddClick)
        {
            container.Controls.Clear();

            string con = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query;

                if (categoryFilter.Count > 0)
                {
                    var paramNames = categoryFilter.Select((_, i) => $"@cat{i}").ToArray();
                    query = $"SELECT ItemID, Name, Price, ImagePath FROM MenuItems WHERE IsAvailable = 'Yes' AND CategoryID IN ({string.Join(",", paramNames)})";
                }
                else
                {
                    query = "SELECT ItemID, Name, Price, ImagePath FROM MenuItems WHERE IsAvailable = 'Yes'";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                for (int i = 0; i < categoryFilter.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@cat{i}", categoryFilter[i]);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string itemId = reader["ItemID"].ToString();
                    string name = reader["Name"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    string imagePath = reader["ImagePath"].ToString();

                    Panel itemPanel = new Panel
                    {
                        Width = 180,
                        Height = 200,
                        BackColor = Color.MintCream,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = itemId // store the ID for later
                    };

                    Label lblName = new Label
                    {
                        Text = name,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 21,
                        Location = new Point(12, 174),
                        Font = new Font("Nirmala Text", 12)
                    };

                    Label lblPrice = new Label
                    {
                        Text = $"RM {price:F2}",
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 21,
                        Location = new Point(12, 195),
                        Font = new Font("Nirmala Text", 12, FontStyle.Bold)
                    };

                    PictureBox picture = new PictureBox
                    {
                        Height = 150,
                        Width = 150,
                        Dock = DockStyle.None,
                        Location = new Point(15, 14),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    string fullPath = Path.Combine(Application.StartupPath, imagePath);
                    picture.Image = File.Exists(fullPath) ? Image.FromFile(fullPath) : Properties.Resources.Default;

                    Button btnAdd = new Button
                    {
                        Width = 35,
                        Height = 35,
                        FlatStyle = FlatStyle.Flat,
                        Image = Properties.Resources.Logo_for_buttons,
                        Location = new Point(119, 118),
                        BackColor = Color.Transparent,
                        FlatAppearance = { BorderSize = 0 },
                        Cursor = Cursors.Hand,
                        Tag = itemId,
                        Dock = DockStyle.Bottom
                    };

                    btnAdd.FlatAppearance.BorderSize = 0;
                    btnAdd.Click += onAddClick;

                    btnAdd.Click += (s, e) =>
                    {
                        MyOrder.OrderManage.AddToCart(itemId, name, price);
                        MessageBox.Show($"{name} added to cart!");
                    };
                    itemPanel.Controls.Add(btnAdd);

                    itemPanel.Controls.Add(btnAdd);
                    itemPanel.Controls.Add(lblPrice);
                    itemPanel.Controls.Add(lblName);
                    itemPanel.Controls.Add(picture);

                    container.Controls.Add(itemPanel);
                }
            }
        }



    }
}

