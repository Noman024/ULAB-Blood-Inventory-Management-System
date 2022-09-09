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
    public partial class DonorRegistration : Form
    {
        public DonorRegistration()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset()
        {
            DNameTb.Text = "";
            DULABEmailTb.Text = "";
            DIDNoTb.Text = "";
            DPhoneTb.Text = "";
            DLivingAreaCb.SelectedIndex = -1;
            DPersonnelCb.SelectedIndex = -1;
            DGenderCb.SelectedIndex = -1;
            DBloodGroupCb.SelectedIndex = -1;
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text == "" || DULABEmailTb.Text == "" || DIDNoTb.Text == "" || DPhoneTb.Text == "" || DLivingAreaCb.SelectedIndex == -1 || DPersonnelCb.SelectedIndex == -1 || DGenderCb.SelectedIndex == -1 || DBloodGroupCb.SelectedIndex == -1)
            {
                MessageBox.Show("You need to fill up all the required fields!");
            }
            else
            {
                try
                {
                    String querry = "insert into DonorTable values('" + DNameTb.Text + "','" + DULABEmailTb.Text + "','" + DIDNoTb.Text + "','" + DPhoneTb.Text + "','" + DLivingAreaCb.SelectedItem.ToString() + "','" + DPersonnelCb.SelectedItem.ToString() + "','" + DGenderCb.SelectedItem.ToString() + "','" + DBloodGroupCb.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Registration Successful!");
                    Con.Close();
                    Reset();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DonorRegistration_Load(object sender, EventArgs e)
        {

        }

        private void DonorRegistration_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorsList ob = new DonorsList();
            ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PatientRegistration ob = new PatientRegistration();
            ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            PatientsList ob = new PatientsList();
            ob.Show();
            this.Hide();
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

        private void label8_Click(object sender, EventArgs e)
        {
            ReceiveBlood ob = new ReceiveBlood();
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
