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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\Documents\\ULABBloodInventoryDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetData()
        {
            Con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from DonorTable", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorsLabel.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from ReceiveBloodTable", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            ReceiversLabel.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from AdminTable", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UsersLabel.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("select Sum(BStock) from BloodTable", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLabel.Text = "" + BStock;

            SqlDataAdapter sda4 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "A+" + "'", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            APositiveLabel.Text = dt4.Rows[0][0].ToString();
            double APositivePercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString())/BStock) * 100;
            APositiveProgress.Value = Convert.ToInt32(APositivePercentage);

            SqlDataAdapter sda5 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "A-" + "'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ANegativeLabel.Text = dt5.Rows[0][0].ToString();
            double ANegativePercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
            ANegativeProgress.Value = Convert.ToInt32(ANegativePercentage);

            SqlDataAdapter sda6 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "AB+" + "'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            ABPositiveLabel.Text = dt6.Rows[0][0].ToString();
            double ABPositivePercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
            ABPositiveProgress.Value = Convert.ToInt32(ABPositivePercentage);

            SqlDataAdapter sda7 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "AB-" + "'", Con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABNegativeLabel.Text = dt7.Rows[0][0].ToString();
            double ABNegativePercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / BStock) * 100;
            ABNegativeProgress.Value = Convert.ToInt32(ABNegativePercentage);

            SqlDataAdapter sda8 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "B+" + "'", Con);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            BPositiveLabel.Text = dt8.Rows[0][0].ToString();
            double BPositivePercentage = (Convert.ToDouble(dt8.Rows[0][0].ToString()) / BStock) * 100;
            BPositiveProgress.Value = Convert.ToInt32(BPositivePercentage);

            SqlDataAdapter sda9 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "B-" + "'", Con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            BNegativeLabel.Text = dt9.Rows[0][0].ToString();
            double BNegativePercentage = (Convert.ToDouble(dt9.Rows[0][0].ToString()) / BStock) * 100;
            BNegativeProgress.Value = Convert.ToInt32(BNegativePercentage);

            SqlDataAdapter sda10 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "O+" + "'", Con);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            OPositiveLabel.Text = dt10.Rows[0][0].ToString();
            double OPositivePercentage = (Convert.ToDouble(dt10.Rows[0][0].ToString()) / BStock) * 100;
            OPositiveProgress.Value = Convert.ToInt32(OPositivePercentage);

            SqlDataAdapter sda11 = new SqlDataAdapter("select BStock from BloodTable where BGroup = '" + "O-" + "'", Con);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            ONegativeLabel.Text = dt11.Rows[0][0].ToString();
            double ONegativePercentage = (Convert.ToDouble(dt11.Rows[0][0].ToString()) / BStock) * 100;
            ONegativeProgress.Value = Convert.ToInt32(ONegativePercentage);

            Con.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void DonorsLabel_Click(object sender, EventArgs e)
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
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
