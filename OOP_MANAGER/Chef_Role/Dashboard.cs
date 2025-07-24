using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static OOP.User;

namespace OOP
{
    public partial class frmChef : Form
    {
        public static string Username;
        public Profile currentUser;

        public frmChef()
        {
            InitializeComponent();
            currentUser = Profile.LoadCurrentUser(Username); 
        }

        public void AddControls(Form f)
        {
            main_panel.Controls.Clear();
            sidePanel.Controls.Clear();
            mainPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            main_panel.Controls.Add(f);
            f.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            picProfile.Show();
            lblWelcome.Text = "Welcome, " + Username + "!";

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
            MenuManagement secondpage = new MenuManagement();
            secondpage.ShowDialog();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmChef firstpage = new frmChef();
            firstpage.Show();
            this.Hide();
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            MenuManagement secondpage = new MenuManagement();
            secondpage.Show();
            this.Hide();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            update_profile frm = new update_profile();
            frm.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Close();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            orders thirdpage = new orders();
            thirdpage.Show();
            this.Hide();
        }

        private void btnOrders2_Click(object sender, EventArgs e)
        {
            orders thirdpage = new orders();
            thirdpage.Show();
            this.Hide();
        }

        private void picBase_Click(object sender, EventArgs e)
        {

        }
    }
}
