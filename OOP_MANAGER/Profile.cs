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
    }
}