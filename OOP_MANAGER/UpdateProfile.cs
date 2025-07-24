using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP.Profile;

namespace OOP
{
    public class UpdateProfile
    {
        private string connectionString;

        public UpdateProfile()
        {
            // Get connection string from config
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["OOPConnectionString"];
            connectionString = settings.ConnectionString;
        }


        // Update user profile method
        public bool UpdateUserProfile(Profile user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Users
                                 SET Username = @Username,
                                 Passwords = @Passwords,
                                 EmailAddress = @EmailAddress,
                                 ContactNo = @ContactNo
                                 WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Passwords", user.Passwords);
                cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }


        }
    }
}
