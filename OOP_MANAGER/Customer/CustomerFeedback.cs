using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OOP
{
    public partial class CustomerFeedback : Form
    {
        private Profile currentUser;

        public CustomerFeedback()
        {
            InitializeComponent();
            string userId = Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userId);

            if (currentUser != null)
            {
                txtUserID.Text = currentUser.UserID;
            }
        }

        private void CustomerFeedback_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
               this.Close();
            new frmCustomer().Show();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            string comment = txtComments.Text.Trim();
            int rating;

            // Validate rating input
            if (cmbRating.SelectedItem == null || !int.TryParse(cmbRating.SelectedItem.ToString(), out rating))
            {
                MessageBox.Show("Please select a valid rating (1–5).");
                return;
            }

            // Optional: validate comment
            if (string.IsNullOrWhiteSpace(comment))
            {
                MessageBox.Show("Please enter your feedback comment.");
                return;
            }

            try
            {
                SendFeedback senderObj = new SendFeedback();
                bool success = senderObj.InsertFeedback(userID, rating, comment);

                if (success)
                {
                    MessageBox.Show("Feedback submitted successfully!");
                    txtComments.Clear();
                    cmbRating.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Failed to submit feedback. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void txtOrderID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
