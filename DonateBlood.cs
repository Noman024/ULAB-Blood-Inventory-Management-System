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
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            String querry = "select * from DonorTable";
            SqlDataAdapter sda = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
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
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void DonateBlood_Load(object sender, EventArgs e)
        {

        }

        private void DonorsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DonorsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DNameTb_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Reset()
        {
            DNameTb.Text = "";
            DBloodGroupTb.Text = "";
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "")
            {
                MessageBox.Show("Select a Donor!");
            }
            else
            {
                try
                {
                    int stock = oldstock + 1;
                    String querry = "update BloodTable set BStock=" + stock + " where BGroup='"+ DBloodGroupTb.Text +"';";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Blood Donation Successful!");
                    Con.Close();
                    Reset();
                    //populate();
                    bloodStock();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            //Helps to get the actual stock of blood based on particular blood group

            Con.Open();
            string querry = "select * from BloodTable where BGroup = '" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(querry, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());

            }
            Con.Close();
        }
        private void DonorsDGV_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorsDGV.SelectedRows[0].Cells[1].Value.ToString();
            DBloodGroupTb.Text = DonorsDGV.SelectedRows[0].Cells[8].Value.ToString();
            GetStock(DBloodGroupTb.Text);
        }

        private void DBloodGroupCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            BloodStock ob = new BloodStock();
            ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
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
