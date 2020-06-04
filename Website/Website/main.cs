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
    public partial class main : Form
    {
        MySqlConnection mysqlCon = new MySqlConnection(@"server=localhost;user id=root;database=websitedb;password=;");
        public main()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            using (mysqlCon)
            {

                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SELECT * FROM websites", mysqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridView1.DataSource = dtbl;

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand saveCommand = new MySqlCommand("INSERT INTO websites (Website) values (@p1)", mysqlCon);
            saveCommand.Parameters.AddWithValue("@p1", textBoxWebsite.Text);
            saveCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The website was added successfully");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxWebsiteID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxWebsite.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM websites where website_id=@p1", mysqlCon);
            deleteCommand.Parameters.AddWithValue("@p1", textBoxWebsiteID.Text);
            deleteCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The website was deleted successfully");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            mysqlCon.Open();
            MySqlCommand updateCommand = new MySqlCommand("UPDATE websites set Website=@p1 where website_id=@p2", mysqlCon);
            updateCommand.Parameters.AddWithValue("@p1", textBoxWebsite.Text);
            updateCommand.Parameters.AddWithValue("@p2", textBoxWebsiteID.Text);
            updateCommand.ExecuteNonQuery();
            mysqlCon.Close();
            MessageBox.Show("The website was updated successfully");
        }
    }
}
