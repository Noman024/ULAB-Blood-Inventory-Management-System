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

namespace ULABBloodInventoryManagementSystem
{
    public partial class ReceiveBlood : Form
    {
        public ReceiveBlood()
        {
            InitializeComponent();
            fillPatientCb();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillPatientCb()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PNo from PatientTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PNo", typeof(int));
            dt.Load(rdr);
            PIDNoCb.ValueMember = "PNo";
            PIDNoCb.DataSource = dt;
            Con.Close();
        }
        private void GetData()
        {
            Con.Open();
            string querry = "select * from PatientTable where PNo = " + PIDNoCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(querry, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PNameTb.Text = dr["PName"].ToString();
                PBloodGroupTb.Text = dr["PBloodGroup"].ToString();
            }
            Con.Close();
        }
        int stock = 0;
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
                stock = Convert.ToInt32(dr["BStock"].ToString());

            }
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReceiveBlood_Load(object sender, EventArgs e)
        {

        }

        /*
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
         */

        private void PIDNoCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(PBloodGroupTb.Text);
            if(stock > 0)
            {
                ReceiveButton.Visible = true;
                AvailableButton.Text = "Available Stock!";
                AvailableButton.Visible = true;
            }
            else
            {
                AvailableButton.Text = "Sorry! Stock not Available.";
                AvailableButton.Visible = true;
            }
        }
        private void Reset()
        {
            PNameTb.Text = "";
            //PIDNoCb.SelectedIndex = -1;
            PBloodGroupTb.Text = "";
            AvailableButton.Visible = false;
            ReceiveButton.Visible = false;
        }
        private void updateStock()
        {
            int newStock = stock - 1;
            try
            {
                String querry = "update BloodTable set BStock=" + newStock + " where BGroup = '" + PBloodGroupTb.Text + "';";
                Con.Open();
                SqlCommand cmd = new SqlCommand(querry, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Patient Update Successful!");
                Con.Close();
                //Reset();
                //populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" )
            {
                MessageBox.Show("You need to fill up all the required fields!");
            }
            else
            {
                try
                {
                    String querry = "insert into ReceiveBloodTable values('" + PNameTb.Text + "','" + PBloodGroupTb.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Blood Receive Successful!");
                    Con.Close();
                    GetStock(PBloodGroupTb.Text);
                    updateStock();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PatientRegistration PR = new PatientRegistration();
            PR.Show();
            this.Hide();
        }

        private void PBloodGroupTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock BS = new BloodStock();
            BS.Show();
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

        private void label5_Click(object sender, EventArgs e)
        {
            PatientsList ob = new PatientsList();
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
