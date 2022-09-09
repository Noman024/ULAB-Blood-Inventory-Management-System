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
    public partial class PatientsList : Form
    {
        public PatientsList()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            String querry = "select * from PatientTable";
            SqlDataAdapter sda = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
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
            key = 0;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Select a patient to delete!");
            }
            else
            {
                try
                {
                    String querry = "Delete from PatientTable where PNo = "+key+";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Deletion Successful!");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PatientsList_Load(object sender, EventArgs e)
        {

        }

        int key = 0;
        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PatientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            PULABEmailTb.Text = PatientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PIDNoTb.Text = PatientsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PPhoneTb.Text = PatientsDGV.SelectedRows[0].Cells[4].Value.ToString();
            PLivingAreaCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[5].Value.ToString();
            PPersonnelCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[6].Value.ToString();
            PGenderCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[7].Value.ToString();
            PBloodGroupCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[8].Value.ToString();
            if(PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PatientRegistration PR = new PatientRegistration();
            PR.Show();
            this.Hide();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PULABEmailTb.Text == "" || PIDNoTb.Text == "" || PPhoneTb.Text == "" || PLivingAreaCb.SelectedIndex == -1 || PPersonnelCb.SelectedIndex == -1 || PGenderCb.SelectedIndex == -1 || PBloodGroupCb.SelectedIndex == -1)
            {
                MessageBox.Show("You need to fill up all the required fields!");
            }
            else
            {
                try
                {
                    String querry = "update PatientTable set PName='"+PNameTb.Text+"', PULABEmail='"+PULABEmailTb.Text+ "', PIDNo='" + PIDNoTb.Text + "', PPhone='" + PPhoneTb.Text + "', PLivingArea='"+PLivingAreaCb.SelectedItem.ToString()+ "', PPersonnel='" + PPersonnelCb.SelectedItem.ToString() + "', PGender='" + PGenderCb.SelectedItem.ToString() + "', PBloodGroup='" + PBloodGroupCb.SelectedItem.ToString() + "' where PNo="+key+";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfuly updated!");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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
