using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class CustomerProfile: Form
    {
        private Profile currentUser;
        private UpdateProfile updateProfile;
        public CustomerProfile()
        {
            InitializeComponent();
            string userID = Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userID);

            updateProfile = new UpdateProfile();
            if (currentUser != null)
            {
                txtUsername.Text = currentUser.Username;
                txtEmail.Text = currentUser.EmailAddress;
                txtMobile.Text = currentUser.ContactNo;
                txtPassword.Text = currentUser.Passwords;

                label01.Text = currentUser.Username;

                label02.Text = currentUser.UserID;

                label03.Text = currentUser.GetRoleName();
            }
        }

        private void CustomerProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmCustomer().Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            currentUser.Username = txtUsername.Text.Trim();
            currentUser.Passwords = txtPassword.Text.Trim();
            currentUser.EmailAddress = txtEmail.Text.Trim();
            currentUser.ContactNo = txtMobile.Text.Trim();


            bool updateSuccess = updateProfile.UpdateUserProfile(currentUser);

            if (updateSuccess)
            {
                // Refresh the labels with updated information
                txtUsername.Text = currentUser.Username;
                txtPassword.Text = currentUser.Passwords;
                txtEmail.Text = currentUser.EmailAddress;
                txtMobile.Text = currentUser.ContactNo;



                MessageBox.Show($"Profile updated!\nNew Username: {currentUser.Username}\nNew Password: {currentUser.Passwords}");
            }
            else
            {
                MessageBox.Show("Failed to update profile.");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Browse functionality is not implemented yet. Stay tuned!");
        }
    }
}
