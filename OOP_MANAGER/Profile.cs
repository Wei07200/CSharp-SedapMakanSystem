using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Profile
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();



        public string UserID { get; set; }
        public string Username { get; set; }
        public string Passwords { get; set; }
        public string RoleID { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }

        public decimal Balance { get; set; }


        public Profile() 
        { 
        }

        public Profile(string userID, string username, string passwords, string roleID, string email, string contact)
        {
            UserID = userID;
            Username = username;
            Passwords = passwords;
            RoleID = roleID;
            EmailAddress = email;
            ContactNo = contact;
        }

        public class Role
        {
            public string RoleID { get; set; }
            public string RoleName { get; set; }
        }

        public class Ewallet
        {
            public string UserID { get; set; }
            public decimal Balance { get; set; }
        }



        public string GetRoleName()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT RoleName FROM Roles WHERE RoleID = @RoleID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Unknown Role";
            }
        }

        // Method to retrieve Balance from Ewallet based on UserID
        public decimal GetBalance()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Balance FROM Ewallet WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0.00M;
            }
        }

        public static Profile LoadCurrentUser(string userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OOPConnectionString"].ToString();
            Profile user = null;

            if (!string.IsNullOrEmpty(userId))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE UserID = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.CommandTimeout = 60;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new Profile
                                {
                                    UserID = reader["UserID"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    EmailAddress = reader["EmailAddress"].ToString(),
                                    ContactNo = reader["ContactNo"].ToString(),
                                    Passwords = reader["Passwords"].ToString(),
                                    RoleID = reader["RoleID"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            return user;
        }
        public string GetWalletID()
        {
            string walletId = null;
          
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT WalletID FROM EWallet WHERE UserID = @UserID"; // Adjust if the actual column is different
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", this.UserID); // Assumes Profile object has a UserID property

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    walletId = result.ToString();
                }
            }

            return walletId;
        }



    }
}