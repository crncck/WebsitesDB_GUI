using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Website
{
    public partial class Form1 : Form
    {
        MySqlConnection mysqlCon = new MySqlConnection(@"server=localhost;user id=root;database=websitedb;password=;");
     

        public Form1()
        {
            InitializeComponent();

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (mysqlCon)
            {

                mysqlCon.Open();
                MySqlCommand command = new MySqlCommand("SELECT websites.website_id, Country_Rank, Website FROM websites JOIN website_countries ON websites.website_id = website_countries.website_id WHERE country_id IN (SELECT country_id FROM countries WHERE country = @p1) ORDER BY Country_Rank", mysqlCon);
                command.Parameters.AddWithValue("@p1", comboBoxCountry.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dtbl = new DataTable();
                da.Fill(dtbl);

                dataGridView1.DataSource = dtbl;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main main1 = new main();
            main1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Country countries1 = new Country();
            countries1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hostages hostage1 = new hostages();
            hostage1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            registrar registrar1 = new registrar();
            registrar1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM countries", mysqlCon);
            MySqlDataReader dr = command1.ExecuteReader();
            while (dr.Read())
            {
                comboBoxCountry.Items.Add(dr["country"]);
            }

            mysqlCon.Close();


           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxWebsiteID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxWebsite.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void textBoxWebsiteID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxWebsiteID_TextChanged_1(object sender, EventArgs e)
        {
            using (mysqlCon)
            {

                mysqlCon.Open();
                MySqlCommand command = new MySqlCommand("SELECT Facebook_likes, Twitter_mentions, Google_pluses, LinkedIn_mentions, Pinterest_pins FROM websites JOIN socialmedia ON websites.website_id = socialmedia.website_id WHERE websites.website_id=@p1", mysqlCon);
                command.Parameters.AddWithValue("@p1", textBoxWebsiteID.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dtbl = new DataTable();
                da.Fill(dtbl);

                dataGridView2.DataSource = dtbl;

            }
        }

        private void textBoxWebsite_TextChanged(object sender, EventArgs e)
        {

        }

        //private void showChart_Click(object sender, EventArgs e)
        //{
        //    mysqlCon.Open();
        //    MySqlCommand command2 = new MySqlCommand("SELECT Facebook_likes, Twitter_mentions, Google_pluses, LinkedIn_mentions, Pinterest_pins FROM socialmedia WHERE website_id=@p1;", mysqlCon);
        //    command2.Parameters.AddWithValue("@p1", textBoxWebsiteID.Text);
        //    MySqlDataReader dr2 = command2.ExecuteReader();
        //    while (dr2.Read())
        //    {
        //        SocialMedia.Series["SocialMedia"].Points.AddXY(dr2[0], dr2[1]);
        //        SocialMedia.Series["SocialMedia"].Points.AddXY(dr2[2], dr2[3]);
        //    }
        //    mysqlCon.Close();
        //}
    }
}
