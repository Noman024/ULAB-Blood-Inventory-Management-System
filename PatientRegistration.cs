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

namespace ULABBloodInventoryManagementSystem
{
    public partial class PatientRegistration : Form
    {
        public PatientRegistration()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset()
        {
            PNameTb.Text = "";
            PULABEmailTb.Text = "";
            PIDNoTb.Text = "";
            PPhoneTb.Text = "";
            PLivingAreaCb.SelectedIndex = -1;
            PPersonnelCb.SelectedIndex = -1;
            PGenderCb.SelectedIndex = -1;
            PBloodGroupCb.SelectedIndex = -1;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PULABEmailTb.Text == "" || PIDNoTb.Text == "" || PPhoneTb.Text == "" || PLivingAreaCb.SelectedIndex == -1 || PPersonnelCb.SelectedIndex == -1 || PGenderCb.SelectedIndex == -1 || PBloodGroupCb.SelectedIndex == -1)
            {
                MessageBox.Show("You need to fill up all the required fields!");
            }
            else
            {
                try
                {
                    String querry = "insert into PatientTable values('" + PNameTb.Text + "','" + PULABEmailTb.Text + "','" + PIDNoTb.Text + "','" + PPhoneTb.Text + "','" + PLivingAreaCb.SelectedItem.ToString() + "','" + PPersonnelCb.SelectedItem.ToString() + "','" + PGenderCb.SelectedItem.ToString() + "','" + PBloodGroupCb.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Registration Successful!");
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PatientRegistration_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
           PatientsList PL = new PatientsList();
           PL.Show();
           this.Hide();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            ReceiveBlood RB = new ReceiveBlood();
            RB.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DonorRegistration ob = new DonorRegistration();
            ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorsList ob = new DonorsList();
            ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock ob = new BloodStock();
            ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DonateBlood ob = new DonateBlood();
            ob.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
