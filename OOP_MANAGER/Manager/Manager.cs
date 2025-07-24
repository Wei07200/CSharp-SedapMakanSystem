using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using static OOP.Profile;
using System.Reflection.Emit;

namespace OOP
{
    public partial class frmM: Form
    {
        private Profile currentUser;
        private UpdateProfile profilem;
        private FeedbackManager feedbackManager;
        private ManageRefund manageRefund;
        private Topup topUp;
        public frmM()
        {
            InitializeComponent();
            
            string userId =Session.CurrentUserID;
            currentUser = Profile.LoadCurrentUser(userId);


            profilem = new UpdateProfile();
            feedbackManager = new FeedbackManager();
            manageRefund = new ManageRefund();
            topUp = new Topup();

            LoadFeedbackData();
            LoadRefundData();
            // Set UI fields
            if (currentUser != null)
            {
                txtUsername.Text = currentUser.Username;
                txtEmail.Text = currentUser.EmailAddress;
                txtContact.Text = currentUser.ContactNo;
                txtPassword.Text = currentUser.Passwords;

                lbluserm.Text = currentUser.Username;
                lblpass.Text = currentUser.Passwords;
                lblmailm.Text = currentUser.EmailAddress;
                lblcontact.Text = currentUser.ContactNo;
                label6.Text = currentUser.Username;

                label07.Text = currentUser.UserID;
                
                label08.Text = currentUser.GetRoleName();
                
            }
            else
            {
                MessageBox.Show("Invalid user or failed to load.");
            }




            btn2.MouseEnter += Button_MouseEnter;
            btn2.MouseLeave += Button_MouseLeave;

            btn3.MouseEnter += Button_MouseEnter;
            btn3.MouseLeave += Button_MouseLeave;

            btn4.MouseEnter += Button_MouseEnter;
            btn4.MouseLeave += Button_MouseLeave;

            btn5.MouseEnter += Button_MouseEnter;
            btn5.MouseLeave += Button_MouseLeave;

            pillButton1.MouseEnter += Button_MouseEnter;
            pillButton1.MouseLeave += Button_MouseLeave;

            btnSave.MouseEnter += Button_MouseEnter;
            btnSave.MouseLeave += Button_MouseLeave2;

        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.FromArgb(251, 236, 206);
        }


        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }
        private void Button_MouseLeave2(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.FromArgb(44, 63, 115);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LoadFeedbackData()
        {
            try
            {
                DataTable data = feedbackManager.GetFeedbackData();
                dataGridView1.DataSource = data;

                dataGridView2.DataSource = data.Copy(); // Use .Copy() if binding to multiple views
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTransactionID()
        {
            Topup topup = new Topup();
            string newId = topup.GenerateTransactionID();
            textBox4.Text = newId; // Set the textbox value
        }

        private void LoadRefundData()
        {
            try
            {
                DataTable data = manageRefund.GetRefundData();
                dataGridView3.DataSource = data;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmM_Load(object sender, EventArgs e)
        {
            LoadTransactionID(); // Load the new TransactionID when the form loads  
        }
        private void ShowSection(Panel active)
        {
            view.Visible = false;
            profile.Visible = false;
            response.Visible = false;
            topup.Visible = false;
            refund.Visible = false;

            sidebar.Visible = true;
            active.Visible = true;
        }



        private void pillButton2_Click(object sender, EventArgs e)
        {
            
            currentUser.Username = txtUsername.Text.Trim();
            currentUser.Passwords = txtPassword.Text.Trim();
            currentUser.EmailAddress = txtEmail.Text.Trim();
            currentUser.ContactNo = txtContact.Text.Trim();

            
            bool updateSuccess = profilem.UpdateUserProfile(currentUser);

            if (!IsValidEmail(currentUser.EmailAddress))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            if (updateSuccess)
            {
                // Refresh the labels with updated information
                lbluserm.Text = currentUser.Username;
                lblpass.Text = currentUser.Passwords;
                lblmailm.Text = currentUser.EmailAddress;
                lblcontact.Text = currentUser.ContactNo;

                label6.Text = currentUser.Username; // same as lblusername

                // Hide the textbox after changed and display the latest label information
                txtUsername.Visible = false;
                txtPassword.Visible = false;
                txtEmail.Visible = false;
                txtContact.Visible = false;

                lbluserm.Visible = true;
                lblpass.Visible = true;
                lblmailm.Visible = true;
                lblcontact.Visible = true;

                MessageBox.Show($"Profile updated!\nNew Username: {currentUser.Username}\nNew Password: {currentUser.Passwords}");
            }
            else
            {
                MessageBox.Show("Failed to update profile.");
            }



        }
        private void button3_Click(object sender, EventArgs e)
        {
            txtUsername.Visible = false;
            txtPassword.Visible = false;
            txtContact.Visible = false;
            txtEmail.Visible = false;   

        }

        private void pillButton1_Click(object sender, EventArgs e)
        {
            txtUsername.Visible = true;
            txtPassword.Visible = true;
            txtEmail.Visible = true;
            txtContact.Visible = true;

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Close();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ShowSection(profile);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
           ShowSection(view);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ShowSection(response);

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ShowSection(topup);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ShowSection(refund);

        }

        private void pillButton3_Click(object sender, EventArgs e)
        {
            ShowSection(view);
        }

        private void pillButton5_Click(object sender, EventArgs e)
        {
            ShowSection(response);
        }

        private void pillButton4_Click(object sender, EventArgs e)
        {
            ShowSection(topup);
        }

        private void pillButton7_Click(object sender, EventArgs e)
        {
            ShowSection(refund);
        }

        private void lblcontactm_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pillButton8_Click(object sender, EventArgs e)
        {
            string refundID = txtRefund.Text.Trim();
            string status = "";

            if (radioButton4.Checked)
            {
                status = "Approved";
            }
            else if (radioButton5.Checked)
            {
                status = "Rejected";
            }
            else
            {
                MessageBox.Show("Please select a status.");
                return;
            }

            if (string.IsNullOrEmpty(refundID))
            {
                MessageBox.Show("Please enter a Refund ID.");
                return;
            }

            try
            {
                manageRefund.ProcessRefund(refundID, status);
                LoadRefundData(); // Refresh the DataGridView after processing

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            txtRefund.Clear();
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            txtRefund.Focus(); // So the user can re-enter a new ID without clicking

         
        }

        private void pillButton13_Click(object sender, EventArgs e)
        {                
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void pillButton11_Click(object sender, EventArgs e)
        {
            string feedbackId = textBox9.Text.Trim();
            string responseText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(feedbackId) || string.IsNullOrEmpty(responseText))
            {
                MessageBox.Show("Please enter both Feedback ID and a response.");
                return;
            }

            try
            {
                bool updated = feedbackManager.UpdateFeedbackResponse(feedbackId, responseText);

                if (updated)
                {
                    MessageBox.Show("Response updated successfully.");
                    // Refresh the DataGridViews
                    DataTable data = feedbackManager.GetFeedbackData();
                    dataGridView1.DataSource = data;
                    dataGridView2.DataSource = data.Copy();
                }
                else
                {
                    MessageBox.Show("Update failed. Check the Feedback ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pillButton12_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox1.Clear();
            textBox9 .Focus(); // So the user can re-enter a new ID without clicking
        }

        private void pillButton10_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            if (radioButton1.Checked)
                radioButton1.Checked = false;
            if (radioButton2.Checked)
                radioButton2.Checked = false;
            if (radioButton3.Checked)
                radioButton3.Checked = false;

        }

        private void pillButton6_Click(object sender, EventArgs e)
        {
            txtRefund.Clear();
            if (radioButton4.Checked)
                radioButton4.Checked = false;
            else if (radioButton5.Checked)
                radioButton5.Checked = false;
       
        }

        private void pillButton9_Click(object sender, EventArgs e)
        {
            string walletId = textBox5.Text.Trim().ToUpper();


            // Check if wallet ID exists
            if (!topUp.WalletExists(walletId))
            {
                MessageBox.Show("Wallet ID does not exist.");
                return;
            }
            string type = radioButton1.Checked ? "Online Banking" :
                          radioButton2.Checked ? "Ewallet" :
                          radioButton3.Checked ? "Cash" : "";

            decimal amount;
            if (!decimal.TryParse(textBox6.Text, out amount))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            Topup topup = new Topup();
            bool success = topup.SaveTransaction(walletId, type, amount);

            if (success)
            {

                MessageBox.Show("Top-up successful!");

              
                LoadTransactionID(); // Refresh the Transaction ID after saving
                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                if (radioButton1.Checked)
                    radioButton4.Checked = false;
                else if (radioButton2.Checked)
                    radioButton5.Checked = false;
                else if (radioButton3.Checked)
                    radioButton3.Checked = false;
            }



            else
            {
                MessageBox.Show("Failed to save. Please check input.");

                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                if (radioButton1.Checked)
                    radioButton4.Checked = false;
                else if (radioButton2.Checked)
                    radioButton5.Checked = false;
                else if (radioButton3.Checked)
                    radioButton3.Checked = false;
            }
            
           

        }

        private void label07_Click(object sender, EventArgs e)
        {

        }

        private void lbluserm_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
