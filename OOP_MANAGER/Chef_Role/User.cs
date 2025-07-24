using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public class User
    {
        private string username;
        private string password;
        private string userID;
        private string roleID;
        private string emailAddress;
        private string contactNo;
        static SqlConnection user = new SqlConnection(ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString());

        // Constructor for load current user
        public User(string userID, string username, string passwords, string roleID, string email, string contact)
        {
            UserID = userID;
            Username = username;
            Passwords = passwords;
            RoleID = roleID;
            EmailAddress = email;
            ContactNo = contact;
        }

        // Constructor for login
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        // Constructor for view profile
        public User(string username)
        {
            this.username = username;
        }

        public User() { }

        public string Username { get; set; }
        public string Passwords { get; set; }
        public string UserID { get; set; }
        public string RoleID { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }

        public static class Session
        {
            public static string Username { get; set; }
            public static string CurrentUserID { get; set; }
        }

        public static User LoadCurrentUser()
        {
            string userId = Session.CurrentUserID;

            if (!string.IsNullOrEmpty(userId))
            {
                string connStr = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
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
                                return new User
                                {
                                    UserID = reader["UserID"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    Passwords = reader["Passwords"].ToString(),
                                    EmailAddress = reader["EmailAddress"].ToString(),
                                    ContactNo = reader["ContactNo"].ToString(),
                                    RoleID = reader["RoleID"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            MessageBox.Show("User not found.");
            return null;
        }


        public string login(string username, string password)
        {
            string status = null;
            SqlConnection user = new SqlConnection(ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString());
            user.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@username AND Passwords=@password", user);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            if (count > 0)
            {
                //Command to determine which form to display based on user's role
                SqlCommand cmd2 = new SqlCommand("SELECT UserID, RoleID FROM Users WHERE Username=@username AND Passwords=@password", user);
                cmd2.Parameters.AddWithValue("@username", username);
                cmd2.Parameters.AddWithValue("@password", password);

                object result = cmd2.ExecuteScalar();


                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    string userId = reader["UserID"].ToString();
                    RoleID = reader["RoleID"].ToString();

                    Session.Username = username;
                    Session.CurrentUserID = userId;
                }

                if (RoleID == "R03")
                {
                    OOP.frmChef.Username = username;
                    frmChef frmChef = new frmChef();
                    frmChef.Show();
                }
                else if (RoleID == "R04")
                {
                    //frmCustomer Dashboard = new frmCustomer();
                    //Dashboard.Show();
                }
            }
            else
            {
                status = "Invalid username or password.";
                user.Close();
            }

            return status;
        }

        public static void viewProfile(User obj)
        {
            user.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @username", user);
            cmd.Parameters.AddWithValue("@username", obj.username);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                obj.UserID = reader["UserID"].ToString();
                obj.Username = reader["Username"].ToString();
                obj.Passwords = reader["Passwords"].ToString();
                obj.EmailAddress = reader["EmailAddress"].ToString();
                obj.ContactNo = reader["ContactNo"].ToString();
                obj.RoleID = reader["RoleID"].ToString();
            }
            reader.Close();
            user.Close();

        }

        public bool UpdateUserProfile(User obj)
        {
            user.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Users
                                 SET Username = @Username,
                                     Passwords = @Passwords,
                                     EmailAddress = @EmailAddress,
                                     ContactNo = @ContactNo
                                 WHERE UserID = @UserID", user);

            cmd.Parameters.AddWithValue("@Username", obj.Username);
            cmd.Parameters.AddWithValue("@Passwords", obj.Passwords);
            cmd.Parameters.AddWithValue("@EmailAddress", obj.EmailAddress);
            cmd.Parameters.AddWithValue("@ContactNo", obj.ContactNo);
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            
            int rowsAffected = cmd.ExecuteNonQuery();
            user.Close();
            return rowsAffected > 0;
            }
        }
}
