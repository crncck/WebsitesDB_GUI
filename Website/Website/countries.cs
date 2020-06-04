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
    public partial class countries : Form
    {
        MySqlConnection mysqlCon = new MySqlConnection(@"server=localhost;user id=root;database=websitedb;password=;");
        public countries()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxWebsiteID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxWebsite_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            using (mysqlCon)
            {

                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM countries", mysqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridView1.DataSource = dtbl;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand saveCommand = new MySqlCommand("INSERT INTO countries (country) values (@p1)", mysqlCon);
            saveCommand.Parameters.AddWithValue("@p1", textBoxCountries.Text);
            saveCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The country was added successfully");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM countries where country_id=@p1", mysqlCon);
            deleteCommand.Parameters.AddWithValue("@p1", textBoxCountryID.Text);
            deleteCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The country was deleted successfully");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand updateCommand = new MySqlCommand("UPDATE countries set country=@p1 where country_id=@p2", mysqlCon);
            updateCommand.Parameters.AddWithValue("@p1", textBoxCountries.Text);
            updateCommand.Parameters.AddWithValue("@p2", textBoxCountryID.Text);
            updateCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The country was updated successfully");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBoxCountryID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxCountries.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
