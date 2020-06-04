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
    public partial class hostages : Form
    {

        MySqlConnection mysqlCon = new MySqlConnection(@"server=localhost;user id=root;database=websitedb;password=;");

        public hostages()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            using (mysqlCon)
            {

                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM hostages", mysqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridView1.DataSource = dtbl;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand saveCommand = new MySqlCommand("INSERT INTO hostages (website_id, Location, Hosted_by, Registrant) values (@p1, @p2, @p3, @p4)", mysqlCon);
            saveCommand.Parameters.AddWithValue("@p1", textBoxWebsiteID.Text);
            saveCommand.Parameters.AddWithValue("@p2", textBoxLocation.Text);
            saveCommand.Parameters.AddWithValue("@p3", textBoxHostage.Text);
            saveCommand.Parameters.AddWithValue("@p4", textBoxRegistrant.Text);
            saveCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The hostage was added successfully");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM hostages where Hosted_id=@p1", mysqlCon);
            deleteCommand.Parameters.AddWithValue("@p1", textBoxHostageID.Text);
            deleteCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The hostage was deleted successfully");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand updateCommand = new MySqlCommand("UPDATE websites set website_id=@p1, Location=@p2, Hosted_by=@p3, Registrant=@p4 where Hosted_id=@p5", mysqlCon);
            updateCommand.Parameters.AddWithValue("@p1", textBoxWebsiteID.Text);
            updateCommand.Parameters.AddWithValue("@p2", textBoxLocation.Text);
            updateCommand.Parameters.AddWithValue("@p3", textBoxHostage.Text);
            updateCommand.Parameters.AddWithValue("@p4", textBoxRegistrant.Text);
            updateCommand.Parameters.AddWithValue("@p5", textBoxHostageID.Text);
            updateCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The hostage was updated successfully");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxHostageID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxWebsiteID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxHostage.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxRegistrant.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
    
}
