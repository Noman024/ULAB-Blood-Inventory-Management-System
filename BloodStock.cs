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
    public partial class BloodStock : Form
    {
        public BloodStock()
        {
            InitializeComponent();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void bloodStock()
        {
            Con.Open();
            String querry = "select * from BloodTable";
            SqlDataAdapter sda = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void BloodStock_Load(object sender, EventArgs e)
        {

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
