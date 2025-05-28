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

namespace OOP
{
    public partial class frmM: Form
    {
        private Profile currentUser;
        private UpdateProfile profilem;
        private FeedbackManager feedbackManager;
        public frmM()
        {
            InitializeComponent();
            LoadCurrentUser();
            profilem = new UpdateProfile();
            feedbackManager = new FeedbackManager();
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

        private void LoadCurrentUser()
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
                                currentUser = new Profile();
                                {
                                    currentUser.UserID = reader["UserID"].ToString();
                                    currentUser.Username = reader["Username"].ToString();
                                    currentUser.EmailAddress = reader["EmailAddress"].ToString();
                                    currentUser.ContactNo = reader["ContactNo"].ToString();
                                    currentUser.Passwords = reader["Passwords"].ToString();
                                };
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid");
            }
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


        private void frmM_Load(object sender, EventArgs e)
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


        private void pillButton2_Click(object sender, EventArgs e)
        {
            
            currentUser.Username = txtUsername.Text.Trim();
            currentUser.Passwords = txtPassword.Text.Trim();
            currentUser.EmailAddress = txtEmail.Text.Trim();
            currentUser.ContactNo = txtContact.Text.Trim();

            
            bool updateSuccess = profilem.UpdateUserProfile(currentUser);

            if (updateSuccess)
            {
                // 3. 更新界面显示的所有相关标签
                lbluserm.Text = currentUser.Username;
                lblpass.Text = currentUser.Passwords;
                lblmailm.Text = currentUser.EmailAddress;
                lblcontact.Text = currentUser.ContactNo;

                label6.Text = currentUser.Username; // 与 lbluserm 一致

                // 4. 隐藏文本框，显示 Label
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
            Application.Exit();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            profile.Visible = true;
            sidebar.Visible = true;
            view.Visible = false;
            response.Visible = false;
            topup.Visible = false;
            refund.Visible = false;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            view.Visible = true;
            sidebar.Visible= true;
            profile.Visible = false;
            response.Visible = false;
            topup.Visible = false;
            refund.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            view.Visible = false;
            sidebar.Visible = true;
            profile.Visible = false;
            response.Visible = true;
            topup.Visible = false;
            refund.Visible = false;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            view.Visible = false;
            sidebar.Visible = true;
            profile.Visible = false;
            response.Visible = false;
            topup.Visible = true;
            refund.Visible = false;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            view.Visible = false;
            sidebar.Visible = true;
            profile.Visible = false;
            response.Visible = false;
            topup.Visible = false;
            refund.Visible = true;
        }

        private void pillButton3_Click(object sender, EventArgs e)
        {
            view.Visible = true;
            sidebar.Visible = true;
            profile.Visible = false;
            response.Visible = false;
            topup.Visible = false;
            refund.Visible = false;
        }

        private void pillButton5_Click(object sender, EventArgs e)
        {
            view.Visible = false;
            sidebar.Visible = true;
            profile.Visible = false;
            response.Visible = true;
            topup.Visible = false;
            refund.Visible = false;
        }

        private void pillButton4_Click(object sender, EventArgs e)
        {
            view.Visible = false;
            sidebar.Visible = true;
            profile.Visible = false;
            response.Visible = false;
            topup.Visible = true;
            refund.Visible = false;
        }

        private void pillButton7_Click(object sender, EventArgs e)
        {
            view.Visible = false;
            sidebar.Visible = true;
            profile.Visible = false;
            response.Visible = false;
            topup.Visible = false;
            refund.Visible = true;
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
    }
}
