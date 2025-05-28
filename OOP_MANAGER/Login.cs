using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using OOP;
using static System.Collections.Specialized.BitVector32;

namespace OOP
{
    public partial class frmlogin: Form
    {
        public frmlogin()
        {
            InitializeComponent();
            this.pillButton02 = new PillButton();
            this.pillButton01 = new PillButton();
            this.pillButton3 = new PillButton();
            this.pillButton4 = new PillButton();
            this.pillButton5 = new PillButton();
            this.pillButton6 = new PillButton();


            button3.MouseEnter += Button_MouseEnter;
            button3.MouseLeave += Button_MouseLeave;

            button4.MouseEnter += Button_MouseEnter;
            button4.MouseLeave += Button_MouseLeave;


            button6.MouseEnter += Button_MouseEnter;
            button6.MouseLeave += Button_MouseLeave;

   


            pillButton02.MouseEnter += Button_MouseEnter;
            pillButton02.MouseLeave += Button_MouseLeave;

            pillButton01.MouseEnter += Button_MouseEnter;
            pillButton01.MouseLeave += Button_MouseLeave2;
        }



        private void frmlogin_Load_1(object sender, EventArgs e)
        {
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox2;
            label2.BackColor = Color.Transparent;

            Username.Parent = pictureBox2;
            Username.BackColor = Color.Transparent;
            Password.Parent = pictureBox2;
            Password.BackColor = Color.Transparent;

            button9.Parent = pictureBox2;
            button9.BackColor = Color.Transparent;

            panel1.Parent = pictureBox02;
            panel1.BackColor = Color.Transparent;

            panel2.Parent = pictureBox9;
            panel2.BackColor = Color.Transparent;


            


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
            button.ForeColor = Color.FromArgb(44,63,115);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home.Visible = true;
            sidebar.Visible = true;
            Contact.Visible = false;
            login.Visible = false;
            roles.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Home.Visible = true;
            Contact.Visible = false;
            login.Visible = false;
            roles.Visible = false;
            sidebar.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Contact.Visible = false;
            login.Visible = false;
            roles.Visible = true;
            sidebar.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Contact.Visible = true;
            login.Visible = false;
            roles.Visible = false;
            sidebar.Visible = true;
        }

        private void pillButton2_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Contact.Visible = false;
            login.Visible = true;
            roles.Visible = false;
            sidebar.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pillButton3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pillButton02_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["OOPConnectionString"];

            using (SqlConnection conn = new SqlConnection(settings.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT UserID,RoleID FROM Users 
                            WHERE LOWER(Username) = LOWER(@username) AND Passwords = @password";

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string userId = reader.GetString(0);   
                        string roleId = reader.GetString(1);   

                        Session.CurrentUserID = userId;        

                        this.Hide();

                        // ✅ 跳转到不同窗体
                        switch (roleId)
                        {
                            case "R01":
                                //frmAdmin adminForm = new frmAdmin();
                                //adminForm.ShowDialog();
                                break;
                            case "R02":
                                frmM managerForm = new frmM();
                                managerForm.ShowDialog();
                                break;
                            case "R03":
                                //frmChef chefForm = new frmChef();
                                //chefForm.ShowDialog();
                                break;
                            case "R04":
                                //frmCustomer customerForm = new frmCustomer();
                                //customerForm.ShowDialog();
                                break;
                            default:
                                MessageBox.Show("Unknown role.");
                                this.Show();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
