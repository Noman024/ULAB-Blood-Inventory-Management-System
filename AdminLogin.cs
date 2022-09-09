using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ULABBloodInventoryManagementSystem
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if(APassTb.Text == "")
            {
                MessageBox.Show("Admin Password Required!");
            }
            else if(APassTb.Text == "noman")
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password! Contact the System Admin.");
                APassTb.Text = "";
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
