using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public class UpdateProfileAdmin
    {
        
            private string connectionString;


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
}
