using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OOP
{
    public partial class update_profile : Form
    {
        public static string Username;
        private Profile currentUser;

        public update_profile()
        {
            InitializeComponent();
            string userID = Session.CurrentUserID;
            Profile currentUser = Profile.LoadCurrentUser(userID);
            if (currentUser != null)
            {
                lblID.Text = currentUser.UserID;
                txtUsername.Text = currentUser.Username;
                txtMobile.Text = currentUser.ContactNo;
                txtEmail.Text = currentUser.EmailAddress;
                txtPassword.Text = currentUser.Passwords;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmChef frmChef = new frmChef();
            frmChef.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User currentUser = User.LoadCurrentUser();
            if (currentUser != null)
            {
                currentUser.Username = txtUsername.Text;
                currentUser.ContactNo = txtMobile.Text;
                currentUser.EmailAddress = txtEmail.Text;
                currentUser.Passwords = txtPassword.Text;
                

                bool success = currentUser.UpdateUserProfile(currentUser);
                if (success)
                {
                    MessageBox.Show("Profile updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update profile. Please Make sure all field are filled.");
                }
            }
        }

        private void update_profile_Load(object sender, EventArgs e)
        {
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Browse functionality is not implemented yet. Stay tuned!");
        }
    }
}
