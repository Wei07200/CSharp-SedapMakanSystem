using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace OOP
{
    public partial class Form1 : Form
    {
        private Profile currentUser;
        private UpdateProfileAdmin profileManager = new UpdateProfileAdmin();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
         

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            currentUser = LoadCurrentUser();
            if (currentUser != null)
            {
                lbluserm.Text = currentUser.Username;
                lblusern.Text = currentUser.Username;
                lbluserid.Text = currentUser.UserID;
                lblroles.Text = currentUser.RoleID;
                lblmailm.Text = currentUser.EmailAddress;
                lblcontact.Text = currentUser.ContactNo;
                lbluserid.Text = currentUser.UserID;
            }
            else
            {
                MessageBox.Show("Failed to load user profile.");
            }
        }

        public Profile LoadCurrentUser()
        {
            string userId = Session.CurrentUserID;

            if (!string.IsNullOrEmpty(userId))
            {
                string connStr = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE UserID = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Profile
                                {
                                    UserID = reader["UserID"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    Passwords = reader["Passwords"].ToString(),
                                    EmailAddress = reader["EmailAddress"].ToString(),
                                    RoleID = reader["RoleID"].ToString(),
                                    ContactNo = reader["ContactNo"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            MessageBox.Show("User not found.");
            return null;
        }

        public Profile LoadUserByUserID(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                string connStr = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE UserID = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Profile
                                {
                                    UserID = reader["UserID"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    Passwords = reader["Passwords"].ToString(),
                                    EmailAddress = reader["EmailAddress"].ToString(),
                                    RoleID = reader["RoleID"].ToString(),
                                    ContactNo = reader["ContactNo"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            MessageBox.Show("User not found.");
            return null;
        }

        public static class ReportRepository
        {
            private static readonly string connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;

            public static DataTable LoadWalletReport()
            {
                string query = "SELECT * FROM WalletReport";
                return ExecuteQuery(query);
            }

            public static DataTable LoadSalesReport()
            {
                string query = "SELECT * FROM SalesReport";
                return ExecuteQuery(query);
            }

            private static DataTable ExecuteQuery(string query)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
       
        public class Profile
        {
            public string UserID { get; set; }
            public string Username { get; set; }
            public string Passwords { get; set; }
            public string EmailAddress { get; set; }
            public string ContactNo { get; set; }
            public string RoleID { get; set; }
        }

        public static class Session
        {
            public static string CurrentUserID { get; set; }
            public static string Username { get; set; }
        }

        public class UpdateProfileAdmin
        {
            private string connectionString;

            public UpdateProfileAdmin()
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["OOPConnectionString"];
                connectionString = settings.ConnectionString;
            }
            public bool AddUser(Profile user)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Users (UserID, Username, Passwords, EmailAddress, ContactNo, RoleID)
                         VALUES (@UserID, @Username, @Passwords, @EmailAddress, @ContactNo, @RoleID)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Passwords", user.Passwords);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@RoleID", user.RoleID);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            public bool UpdateUserProfileByUserID(string originalUserID, Profile user)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Users
                         SET UserID = @NewUserID,
                             Username = @Username,
                             Passwords = @Passwords,
                             EmailAddress = @EmailAddress,
                             ContactNo = @ContactNo,
                             RoleID = @RoleID
                         WHERE UserID = @OriginalUserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NewUserID", user.UserID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Passwords", user.Passwords);
                    cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@RoleID", user.RoleID);
                    cmd.Parameters.AddWithValue("@OriginalUserID", originalUserID);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void tabSalesReport_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e) //view Wallet report
        {
            tabControl1.SelectedTab = tabWreport;
            
            dgvWallet.DataSource = ReportRepository.LoadWalletReport();
            
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void button61_Click(object sender, EventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void lblroles_Click(object sender, EventArgs e)
        {

        }

        private void tabremove_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabremove;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button22_Click_1(object sender, EventArgs e) // update button
        {
            if (string.IsNullOrWhiteSpace(txtpreid.Text))
            {
                MessageBox.Show("Original UserID is missing.");
                return;
            }

            string originalUserID = txtpreid.Text.Trim(); // for WHERE clause
            string newUserID = txtuserid2.Text.Trim(); // new value to update to

            Profile newUser = new Profile
            {
                UserID = newUserID,
                Username = txtusername2.Text.Trim(),
                Passwords = txtpassword2.Text.Trim(),
                EmailAddress = txtemail2.Text.Trim(),
                ContactNo = txtcontact2.Text.Trim(),
                RoleID = comboRole2.Text.Trim()
            };

            bool result = profileManager.UpdateUserProfileByUserID(originalUserID, newUser);

            if (result)
            {
                MessageBox.Show("User profile updated successfully.");
            }
            else
            {
                MessageBox.Show("Update failed. User may not exist.");
            }
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabupdate;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabupdate;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Profile newUser = new Profile
            {
                UserID = txtUserid.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Passwords = txtPassword.Text.Trim(),
                EmailAddress = txtEmail.Text.Trim(),
                ContactNo = txtContact.Text.Trim(),
                RoleID = comboroles.Text.Trim()
            };

            bool added = profileManager.AddUser(newUser);

            if (added)
            {
                MessageBox.Show("User added successfully!");
                ClearUserFields(); // optional, clear inputs after adding
            }
            else
            {
                MessageBox.Show("Failed to add user.");
            }
        }  
        private void ClearUserFields()
        {
            txtUserid.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            comboroles.SelectedIndex = -1; 
         }

        private void button19_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSalesReport;
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabEWallet;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserManagement;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string userId = txtpreid.Text.Trim(); 

            Profile user = LoadUserByUserID(userId);

            if (user != null)
            {
                txtusername2.Text = user.Username;
                txtuserid2.Text = user.UserID;
                comboRole2.Text = user.RoleID;
                txtemail2.Text = user.EmailAddress;
                txtcontact2.Text = user.ContactNo;
                txtpassword2.Text = user.Passwords;
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click_1(object sender, EventArgs e) //remove button
        {
            string userId = txtuseridremove.Text.Trim();
            string username = txtusernameremove.Text.Trim();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter both UserID and Username.");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE UserID = @UserID AND Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User removed successfully.");
                        txtuseridremove.Clear();
                        txtusernameremove.Clear();
                    }
                    else
                    {
                        MessageBox.Show("User not found or already removed.");
                    }
                }
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnViewreport_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSales;

            dgvSales.DataSource = ReportRepository.LoadSalesReport();

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button17_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void button18_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabDashboard;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
