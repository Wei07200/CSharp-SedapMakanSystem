using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OOP
{
    public class Profile_chef
    {
        public string connectionString = "Data Source=NE-NB-012;Initial Catalog=OOP;Integrated Security=True;".ToString();

        // To allow read and write access a string value foreach Profile object
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Passwords { get; set; }
        public string RoleID { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }


        // Constructors for Profile class
        public Profile_chef(string userID, string username, string passwords, string roleID, string email, string contact)
        {
            UserID = userID;
            Username = username;
            Passwords = passwords;
            RoleID = roleID;
            EmailAddress = email;
            ContactNo = contact;
        }

        // Constructors for Update Profile
        public Profile_chef(string userID, string username, string email, string contact)
        {
            UserID = userID;
            Username = username;
            EmailAddress = email;
            ContactNo = contact;
        }

        // Method for Update Profile
        public bool UpdateProfile()
        {
            // Validate fields to make sure it is all filled with information and are not empty
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(EmailAddress) || string.IsNullOrEmpty(ContactNo))
            {
                MessageBox.Show("Username, Email Address and Contat Number information must be filled.");
            }

            // Try catch for input validation when updating profile
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE users 
                                     SET username = @Username, 
                                         email = @EmailAddress, 
                                         contact = @ContactNo 
                                     WHERE userid = @UserID"
                    ;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                        cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
                        cmd.Parameters.AddWithValue("@UserID", UserID);

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

        // Method for get profile ID and display it in user profile's
        public static Profile_chef GetProfileByID(string userID)
        {
            string connectionString = "Data Source=NE-NB-012;Initial Catalog=OOP;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT UserID, Username, Email, Contact FROM users WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Profile_chef(
                                    reader["UserID"].ToString(),
                                    reader["Username"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["Contact"].ToString()
                                );
                            }
                        }
                    }
                }
                catch (SqlException sq)
                {
                    Console.WriteLine("SQL Error: " + sq.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return null;
            }
        }
    }
}
