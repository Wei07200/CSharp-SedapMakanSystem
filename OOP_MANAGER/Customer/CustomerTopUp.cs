using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP
{
    public partial class CustomerTopUp : Form
    {
        private Profile currentUser;
        private Topup topUpCustomer;
        public CustomerTopUp()
        {
            InitializeComponent();

            string userId = Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userId);

            topUpCustomer = new Topup();
        }

        private void LoadTransactionID()
        {
            
            string newId = topUpCustomer.GenerateTransactionID();
            textBox1.Text = newId; // Set the textbox value
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.Show();
        }

        private void lblRMValue_Click(object sender, EventArgs e)
        {
            
        }

        private void CustomerTopUp_Load(object sender, EventArgs e)
        {
            lblRMValue.Text = currentUser.GetBalance().ToString("C2");
            LoadTransactionID();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn100_Click(object sender, EventArgs e)
        {
            label2.Text = "RM100.00";
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            label2.Text = "RM10.00";
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            label2.Text = "RM20.00";
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            label2.Text = "RM50.00";
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            // Step 1: Validate combo box (Top-up method)
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please select a top-up method.", "Input Error");
                return;
            }

            // Step 2: Determine top-up amount from label
            decimal amount = 0;
            if (!decimal.TryParse(label2.Text.Replace("RM", "").Trim(), out amount) || amount <= 0)
            {
                MessageBox.Show("Please select a valid top-up amount.", "Input Error");
                return;
            }

            // Step 3: Retrieve wallet ID from current user
            string walletId = currentUser.GetWalletID(); 
            if (string.IsNullOrEmpty(walletId))
            {
                MessageBox.Show("Wallet ID not found for this user.", "Error");
                return;
            }

            string type = comboBox1.Text;

            // Step 4: Save transaction
            bool saved = topUpCustomer.SaveTransaction(walletId, type, amount);
            if (!saved)
            {
                MessageBox.Show("Transaction failed to save. Please try again.", "Error");
                return;
            }

            // Step 5: Update wallet balance
            decimal newBalance = topUpCustomer.AddToWalletBalance(walletId, amount);

            // Step 6: Refresh balance on screen
            lblRMValue.Text = newBalance.ToString("C2");

            // Step 7: Clear selections
            label2.Text = "0.00";
            comboBox1.SelectedIndex = -1;

            // Step 8: Show success message
            MessageBox.Show("Top-up successful!", "Success");

            // Optional: refresh the TransactionID textbox if you’re displaying it
            LoadTransactionID();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
