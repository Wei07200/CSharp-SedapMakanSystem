using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public class AdminProfile
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Passwords { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string RoleID { get; set; }

    }

}
