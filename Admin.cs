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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        private void Reset()
        {
            ANameTb.Text = "";
            APassTb.Text = "";
            key = 0;
        }
        private void populate()
        {
            Con.Open();
            String querry = "select * from AdminTable";
            SqlDataAdapter sda = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AdminsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (ANameTb.Text == "" || APassTb.Text == "")
            {
                MessageBox.Show("You need to fill up all the required fields!");
            }
            else
            {
                try
                {
                    String querry = "insert into AdminTable values('" + ANameTb.Text + "','" + APassTb.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully saved!");
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
        int key = 0;
        private void AdminsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ANameTb.Text = AdminsDGV.SelectedRows[0].Cells[1].Value.ToString();
            APassTb.Text = AdminsDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (ANameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AdminsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select an User to delete!");
            }
            else
            {
                try
                {
                    String querry = "Delete from AdminTable where ANo = " + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deletion Successful!");
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

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (ANameTb.Text == "" || APassTb.Text == "")
            {
                MessageBox.Show("You need to fill up all the required fields!");
            }
            else
            {
                try
                {
                    String querry = "update AdminTable set AID='" + ANameTb.Text + "', APass='" + APassTb.Text + "' where ANo = " + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(querry, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfuly Updated!");
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

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
